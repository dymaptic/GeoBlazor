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

    let { buildDotNetPortalBasemapsSource } = await import('./portalBasemapsSource');
    let dnInstantiatedObject = await buildDotNetPortalBasemapsSource(jsLocalBasemapsSource);

    try {
        let seenObjects = new WeakMap();
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, JSON.stringify(dnInstantiatedObject, function (key, value) {
                if (key.startsWith('_')) {
                    return undefined;
                }
                if (typeof value === 'object' && value !== null) {
                    if (seenObjects.has(value)) {
                        console.warn(`Circular reference in serializing type LocalBasemapsSource detected at path: ${key}, value: ${value.__proto__?.declaredClass}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                return value;
            }));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LocalBasemapsSource', e);
    }

    return jsLocalBasemapsSource;
}

export async function buildDotNetLocalBasemapsSource(jsObject: any): Promise<any> {
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
