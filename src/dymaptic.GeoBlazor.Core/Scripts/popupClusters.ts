// override generated code in this file
import PopupClustersGenerated from './popupClusters.gb';
import popupClusters = __esri.popupClusters;

export default class PopupClustersWrapper extends PopupClustersGenerated {

    constructor(component: popupClusters) {
        super(component);
    }

}

export async function buildJsPopupClusters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupClustersGenerated} = await import('./popupClusters.gb');
    return await buildJsPopupClustersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupClusters(jsObject: any): Promise<any> {
    let {buildDotNetPopupClustersGenerated} = await import('./popupClusters.gb');
    return await buildDotNetPopupClustersGenerated(jsObject);
}
