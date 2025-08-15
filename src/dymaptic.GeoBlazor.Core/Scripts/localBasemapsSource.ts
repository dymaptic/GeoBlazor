import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import LocalBasemapsSource from "@arcgis/core/widgets/BasemapGallery/support/LocalBasemapsSource";

export async function buildJsLocalBasemapsSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let properties: any = {};
    if (hasValue(dotNetObject.basemaps)) {
        let { buildJsBasemap } = await import('./basemap');
        properties.basemaps = await Promise.all(dotNetObject.basemaps.map(async i => await buildJsBasemap(i, layerId, viewId))) as any;
    }
    
    if (hasValue(dotNetObject.state)) {
        properties.state = dotNetObject.state;
    }
    
    let jsLocalBasemapsSource = new LocalBasemapsSource(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsLocalBasemapsSource);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLocalBasemapsSource;

    return jsLocalBasemapsSource;
}

export async function buildDotNetLocalBasemapsSource(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetLocalBasemapsSource: any = {
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    
    if (hasValue(jsObject.basemaps)) {
        let { buildDotNetBasemap } = await import('./basemap');
        dotNetLocalBasemapsSource.basemaps = await Promise.all(jsObject.basemaps.map(async i => await buildDotNetBasemap(i)));
    }
    
    if (hasValue(jsObject.state)) {
        dotNetLocalBasemapsSource.state = jsObject.state;
    }
    
    return dotNetLocalBasemapsSource;
}
