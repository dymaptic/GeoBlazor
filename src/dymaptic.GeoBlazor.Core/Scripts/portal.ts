// override generated code in this file
import PortalGenerated, {buildDotNetPortalGenerated, buildJsPortalGenerated} from './portal.gb';
import Portal from '@arcgis/core/portal/Portal';

export default class PortalWrapper extends PortalGenerated {

    constructor(component: Portal) {
        super(component);
    }

}

export function buildJsPortal(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return buildJsPortalGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortal(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    return await buildDotNetPortalGenerated(jsObject, layerId, viewId);
}
