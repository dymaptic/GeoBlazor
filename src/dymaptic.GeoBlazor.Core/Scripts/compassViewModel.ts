import CompassViewModel from '@arcgis/core/widgets/Compass/CompassViewModel';
import CompassViewModelGenerated from './compassViewModel.gb';

export default class CompassViewModelWrapper extends CompassViewModelGenerated {

    constructor(component: CompassViewModel) {
        super(component);
    }

}

export async function buildJsCompassViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCompassViewModelGenerated} = await import('./compassViewModel.gb');
    return await buildJsCompassViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCompassViewModel(jsObject: any): Promise<any> {
    let {buildDotNetCompassViewModelGenerated} = await import('./compassViewModel.gb');
    return await buildDotNetCompassViewModelGenerated(jsObject);
}
