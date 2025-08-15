// override generated code in this file
import AreaMeasurement2DViewModelGenerated from './areaMeasurement2DViewModel.gb';
import AreaMeasurement2DViewModel from '@arcgis/core/widgets/AreaMeasurement2D/AreaMeasurement2DViewModel';

export default class AreaMeasurement2DViewModelWrapper extends AreaMeasurement2DViewModelGenerated {

    constructor(component: AreaMeasurement2DViewModel) {
        super(component);
    }

}

export async function buildJsAreaMeasurement2DViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAreaMeasurement2DViewModelGenerated} = await import('./areaMeasurement2DViewModel.gb');
    return await buildJsAreaMeasurement2DViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAreaMeasurement2DViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetAreaMeasurement2DViewModelGenerated} = await import('./areaMeasurement2DViewModel.gb');
    return await buildDotNetAreaMeasurement2DViewModelGenerated(jsObject, viewId);
}
