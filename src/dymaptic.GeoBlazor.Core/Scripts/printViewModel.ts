import PrintViewModel from '@arcgis/core/widgets/Print/PrintViewModel';
import PrintViewModelGenerated from './printViewModel.gb';

export default class PrintViewModelWrapper extends PrintViewModelGenerated {

    constructor(component: PrintViewModel) {
        super(component);
    }

}

export async function buildJsPrintViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPrintViewModelGenerated} = await import('./printViewModel.gb');
    return await buildJsPrintViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPrintViewModel(jsObject: any): Promise<any> {
    let {buildDotNetPrintViewModelGenerated} = await import('./printViewModel.gb');
    return await buildDotNetPrintViewModelGenerated(jsObject);
}
