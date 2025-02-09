// override generated code in this file
import LODGenerated from './lOD.gb';
import LOD from '@arcgis/core/layers/support/LOD';

export default class LODWrapper extends LODGenerated {

    constructor(component: LOD) {
        super(component);
    }
    
}              
export async function buildJsLOD(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLODGenerated } = await import('./lOD.gb');
    return await buildJsLODGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLOD(jsObject: any): Promise<any> {
    let { buildDotNetLODGenerated } = await import('./lOD.gb');
    return await buildDotNetLODGenerated(jsObject);
}
