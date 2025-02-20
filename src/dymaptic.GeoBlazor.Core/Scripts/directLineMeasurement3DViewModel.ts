import DirectLineMeasurement3DViewModel
    from '@arcgis/core/widgets/DirectLineMeasurement3D/DirectLineMeasurement3DViewModel';
import DirectLineMeasurement3DViewModelGenerated from './directLineMeasurement3DViewModel.gb';

export default class DirectLineMeasurement3DViewModelWrapper extends DirectLineMeasurement3DViewModelGenerated {

    constructor(component: DirectLineMeasurement3DViewModel) {
        super(component);
    }

}

export async function buildJsDirectLineMeasurement3DViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectLineMeasurement3DViewModelGenerated} = await import('./directLineMeasurement3DViewModel.gb');
    return await buildJsDirectLineMeasurement3DViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectLineMeasurement3DViewModel(jsObject: any): Promise<any> {
    let {buildDotNetDirectLineMeasurement3DViewModelGenerated} = await import('./directLineMeasurement3DViewModel.gb');
    return await buildDotNetDirectLineMeasurement3DViewModelGenerated(jsObject);
}
