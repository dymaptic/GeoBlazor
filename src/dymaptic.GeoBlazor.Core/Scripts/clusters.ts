// override generated code in this file
import ClustersGenerated from './clusters.gb';
import clusters = __esri.clusters;

export default class ClustersWrapper extends ClustersGenerated {

    constructor(component: clusters) {
        super(component);
    }

}

export async function buildJsClusters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClustersGenerated} = await import('./clusters.gb');
    return await buildJsClustersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClusters(jsObject: any): Promise<any> {
    let {buildDotNetClustersGenerated} = await import('./clusters.gb');
    return await buildDotNetClustersGenerated(jsObject);
}
