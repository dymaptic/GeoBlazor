import {hasValue} from "./arcGisJsInterop";
import PortalBasemapsSource from "@arcgis/core/widgets/BasemapGallery/support/PortalBasemapsSource";

export async function buildJsIBasemapGalleryWidgetSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    if (hasValue(dotNetObject.queryString) || hasValue(dotNetObject.queryParams)) {
        let { buildJsPortalBasemapsSource } = await import ('./portalBasemapsSource');
        return await buildJsPortalBasemapsSource(dotNetObject, layerId, viewId);
    }
    
    let { buildJsLocalBasemapsSource } = await import ('./localBasemapsSource');
    return await buildJsLocalBasemapsSource(dotNetObject, layerId, viewId);
}

export async function buildDotNetIBasemapGalleryWidgetSource(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    if (jsObject instanceof PortalBasemapsSource) {
        let { buildDotNetPortalBasemapsSource } = await import('./portalBasemapsSource');
        return await buildDotNetPortalBasemapsSource(jsObject, viewId);
    }
    
    let { buildDotNetLocalBasemapsSource } = await import('./localBasemapsSource');
    return await buildDotNetLocalBasemapsSource(jsObject, viewId);
}
