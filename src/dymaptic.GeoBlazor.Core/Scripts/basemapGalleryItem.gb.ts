// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import BasemapGalleryItem from '@arcgis/core/widgets/BasemapGallery/support/BasemapGalleryItem';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetBasemapGalleryItem } from './basemapGalleryItem';

export async function buildJsBasemapGalleryItemGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(viewId)) {
        properties.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.basemap)) {
        let { buildJsBasemap } = await import('./basemap');
        properties.basemap = await buildJsBasemap(dotNetObject.basemap, layerId, viewId) as any;
    }

    let jsBasemapGalleryItem = new BasemapGalleryItem(properties);
    
    jsObjectRefs[dotNetObject.id] = jsBasemapGalleryItem;
    arcGisObjectRefs[dotNetObject.id] = jsBasemapGalleryItem;
    
    return jsBasemapGalleryItem;
}


export async function buildDotNetBasemapGalleryItemGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBasemapGalleryItem: any = {};
    
    if (hasValue(jsObject.basemap)) {
        let { buildDotNetBasemap } = await import('./basemap');
        dotNetBasemapGalleryItem.basemap = await buildDotNetBasemap(jsObject.basemap);
    }
    
    if (hasValue(jsObject.error)) {
        dotNetBasemapGalleryItem.error = removeCircularReferences(jsObject.error);
    }
    
    if (hasValue(jsObject.state)) {
        dotNetBasemapGalleryItem.state = removeCircularReferences(jsObject.state);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBasemapGalleryItem.id = geoBlazorId;
    }

    return dotNetBasemapGalleryItem;
}

