import IdentityManager from '@arcgis/core/identity/IdentityManager';
import IdentityManagerGenerated from './identityManager.gb';

export default class IdentityManagerWrapper extends IdentityManagerGenerated {

    constructor(component: IdentityManager) {
        super(component);
    }

}

export async function buildJsIdentityManager(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIdentityManagerGenerated} = await import('./identityManager.gb');
    return await buildJsIdentityManagerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIdentityManager(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetIdentityManagerGenerated} = await import('./identityManager.gb');
    return await buildDotNetIdentityManagerGenerated(jsObject, layerId, viewId);
}
