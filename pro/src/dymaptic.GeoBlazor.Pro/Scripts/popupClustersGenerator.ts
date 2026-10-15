// override generated code in this file
import PopupClustersGeneratorGenerated from './popupClustersGenerator.gb';
import popupClusters = __esri.popupClusters;

export default class PopupClustersGeneratorWrapper extends PopupClustersGeneratorGenerated {

    constructor(component: popupClusters) {
        super(component);
    }
    
}

export async function buildJsPopupClustersGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupClustersGeneratorGenerated } = await import('./popupClustersGenerator.gb');
    return await buildJsPopupClustersGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupClustersGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPopupClustersGeneratorGenerated } = await import('./popupClustersGenerator.gb');
    return await buildDotNetPopupClustersGeneratorGenerated(jsObject, layerId, viewId);
}
