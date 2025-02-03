// override generated code in this file
import PortalGenerated from './portal.gb';
import Portal from '@arcgis/core/portal/Portal';

export default class PortalWrapper extends PortalGenerated {

    constructor(component: Portal) {
        super(component);
    }
    
}              
export async function buildJsPortal(dotNetObject: any): Promise<any> {
    let { buildJsPortalGenerated } = await import('./portal.gb');
    return await buildJsPortalGenerated(dotNetObject);
}
export async function buildDotNetPortal(jsObject: any): Promise<any> {
    let { buildDotNetPortalGenerated } = await import('./portal.gb');
    return await buildDotNetPortalGenerated(jsObject);
}
