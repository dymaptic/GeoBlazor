import LineOfSightViewModel from '@arcgis/core/widgets/LineOfSight/LineOfSightViewModel';
import LineOfSightViewModelGenerated from './lineOfSightViewModel.gb';

export default class LineOfSightViewModelWrapper extends LineOfSightViewModelGenerated {

    constructor(component: LineOfSightViewModel) {
        super(component);
    }

}

export async function buildJsLineOfSightViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLineOfSightViewModelGenerated} = await import('./lineOfSightViewModel.gb');
    return await buildJsLineOfSightViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLineOfSightViewModel(jsObject: any): Promise<any> {
    let {buildDotNetLineOfSightViewModelGenerated} = await import('./lineOfSightViewModel.gb');
    return await buildDotNetLineOfSightViewModelGenerated(jsObject);
}
