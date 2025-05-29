// override generated code in this file
import ViewStateGenerated from './viewState.gb';
import ViewState from '@arcgis/core/views/2d/ViewState';

export default class ViewStateWrapper extends ViewStateGenerated {

    constructor(component: ViewState) {
        super(component);
    }

}

export async function buildJsViewState(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewStateGenerated} = await import('./viewState.gb');
    return await buildJsViewStateGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewState(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetViewStateGenerated} = await import('./viewState.gb');
    return await buildDotNetViewStateGenerated(jsObject, layerId, viewId);
}
