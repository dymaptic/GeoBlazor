// override generated code in this file
import MeshUtilsGenerated from './meshUtils.gb';
import meshUtils = __esri.meshUtils;

export default class MeshUtilsWrapper extends MeshUtilsGenerated {

    constructor(component: meshUtils) {
        super(component);
    }

}

export async function buildJsMeshUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMeshUtilsGenerated} = await import('./meshUtils.gb');
    return await buildJsMeshUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMeshUtils(jsObject: any): Promise<any> {
    let {buildDotNetMeshUtilsGenerated} = await import('./meshUtils.gb');
    return await buildDotNetMeshUtilsGenerated(jsObject);
}
