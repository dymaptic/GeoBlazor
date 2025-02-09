// override generated code in this file
import PortalFolderGenerated from './portalFolder.gb';
import PortalFolder from '@arcgis/core/portal/PortalFolder';

export default class PortalFolderWrapper extends PortalFolderGenerated {

    constructor(component: PortalFolder) {
        super(component);
    }
    
}              
export async function buildJsPortalFolder(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildJsPortalFolderGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPortalFolder(jsObject: any): Promise<any> {
    let { buildDotNetPortalFolderGenerated } = await import('./portalFolder.gb');
    return await buildDotNetPortalFolderGenerated(jsObject);
}
