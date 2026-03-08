// override generated code in this file
import PortalGenerated, {buildDotNetPortalGenerated, buildJsPortalGenerated} from './portal.gb';
import Portal from '@arcgis/core/portal/Portal';

export default class PortalWrapper extends PortalGenerated {

    constructor(component: Portal) {
        super(component);
    }

    async load(signal: AbortSignal): Promise<any> {
        let options = {signal: signal};
        let result = await this.component.load(options);
        return await buildDotNetPortal(result, this.layerId, this.viewId);
    }

}

export function buildJsPortal(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return buildJsPortalGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortal(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    return await buildDotNetPortalGenerated(jsObject, layerId, viewId);
}
