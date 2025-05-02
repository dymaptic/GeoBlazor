// override generated code in this file
import UrbanMeshUtilsGenerated from './urbanMeshUtils.gb';
import UrbanMeshUtils = __esri.UrbanMeshUtils;

export default class UrbanMeshUtilsWrapper extends UrbanMeshUtilsGenerated {

    constructor(component: UrbanMeshUtils) {
        super(component);
    }
    
}

export async function buildJsUrbanMeshUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUrbanMeshUtilsGenerated } = await import('./urbanMeshUtils.gb');
    return await buildJsUrbanMeshUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUrbanMeshUtils(jsObject: any): Promise<any> {
    let { buildDotNetUrbanMeshUtilsGenerated } = await import('./urbanMeshUtils.gb');
    return await buildDotNetUrbanMeshUtilsGenerated(jsObject);
}
