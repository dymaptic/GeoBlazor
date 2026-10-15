// override generated code in this file
import PrintViewModelGenerated from './printViewModel.gb';
import PrintViewModel from '@arcgis/core/widgets/Print/PrintViewModel';

export default class PrintViewModelWrapper extends PrintViewModelGenerated {

    constructor(component: PrintViewModel) {
        super(component);
    }
    
}

export async function buildJsPrintViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintViewModelGenerated } = await import('./printViewModel.gb');
    return await buildJsPrintViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrintViewModelGenerated } = await import('./printViewModel.gb');
    return await buildDotNetPrintViewModelGenerated(jsObject, layerId, viewId);
}
