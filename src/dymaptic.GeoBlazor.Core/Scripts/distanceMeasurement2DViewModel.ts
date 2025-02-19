import DistanceMeasurement2DViewModel from '@arcgis/core/widgets/DistanceMeasurement2D/DistanceMeasurement2DViewModel';
import DistanceMeasurement2DViewModelGenerated from './distanceMeasurement2DViewModel.gb';

export default class DistanceMeasurement2DViewModelWrapper extends DistanceMeasurement2DViewModelGenerated {

    constructor(component: DistanceMeasurement2DViewModel) {
        super(component);
    }
    
}

export async function buildJsDistanceMeasurement2DViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDistanceMeasurement2DViewModelGenerated } = await import('./distanceMeasurement2DViewModel.gb');
    return await buildJsDistanceMeasurement2DViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDistanceMeasurement2DViewModel(jsObject: any): Promise<any> {
    let { buildDotNetDistanceMeasurement2DViewModelGenerated } = await import('./distanceMeasurement2DViewModel.gb');
    return await buildDotNetDistanceMeasurement2DViewModelGenerated(jsObject);
}
