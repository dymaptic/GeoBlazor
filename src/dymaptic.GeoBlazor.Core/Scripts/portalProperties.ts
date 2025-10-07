import {buildDotNetPortalPropertiesGenerated, buildJsPortalPropertiesGenerated} from "./portalProperties.gb";

export function buildJsPortalProperties(dotNetObject: any): any {
    return buildJsPortalPropertiesGenerated(dotNetObject);
}     

export async function buildDotNetPortalProperties(jsObject: any, viewId: string | null): Promise<any> {
    return await buildDotNetPortalPropertiesGenerated(jsObject, viewId);
}
