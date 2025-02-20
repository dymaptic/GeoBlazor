// override generated code in this file
import ManagedFBOGenerated from './managedFBO.gb';
import ManagedFBO from '@arcgis/core/views/3d/webgl/ManagedFBO';

export default class ManagedFBOWrapper extends ManagedFBOGenerated {

    constructor(component: ManagedFBO) {
        super(component);
    }

}

export async function buildJsManagedFBO(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsManagedFBOGenerated} = await import('./managedFBO.gb');
    return await buildJsManagedFBOGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetManagedFBO(jsObject: any): Promise<any> {
    let {buildDotNetManagedFBOGenerated} = await import('./managedFBO.gb');
    return await buildDotNetManagedFBOGenerated(jsObject);
}
