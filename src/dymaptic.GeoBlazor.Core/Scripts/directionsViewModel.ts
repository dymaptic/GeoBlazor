// override generated code in this file
import DirectionsViewModelGenerated from './directionsViewModel.gb';
import DirectionsViewModel from '@arcgis/core/widgets/Directions/DirectionsViewModel';

export default class DirectionsViewModelWrapper extends DirectionsViewModelGenerated {

    constructor(component: DirectionsViewModel) {
        super(component);
    }

}

export async function buildJsDirectionsViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionsViewModelGenerated} = await import('./directionsViewModel.gb');
    return await buildJsDirectionsViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionsViewModel(jsObject: any): Promise<any> {
    let {buildDotNetDirectionsViewModelGenerated} = await import('./directionsViewModel.gb');
    return await buildDotNetDirectionsViewModelGenerated(jsObject);
}
