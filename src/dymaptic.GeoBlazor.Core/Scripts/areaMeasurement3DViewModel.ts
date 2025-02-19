// override generated code in this file
import AreaMeasurement3DViewModelGenerated from './areaMeasurement3DViewModel.gb';
import AreaMeasurement3DViewModel from '@arcgis/core/widgets/AreaMeasurement3D/AreaMeasurement3DViewModel';

export default class AreaMeasurement3DViewModelWrapper extends AreaMeasurement3DViewModelGenerated {

    constructor(component: AreaMeasurement3DViewModel) {
        super(component);
    }
    
}

export async function buildJsAreaMeasurement3DViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement3DViewModelGenerated } = await import('./areaMeasurement3DViewModel.gb');
    return await buildJsAreaMeasurement3DViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement3DViewModel(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement3DViewModelGenerated } = await import('./areaMeasurement3DViewModel.gb');
    return await buildDotNetAreaMeasurement3DViewModelGenerated(jsObject);
}
