import {buildDotNetBookmarkOptionsScreenshotSettings} from './bookmarkOptionsScreenshotSettings';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBookmarkOptionsScreenshotSettingsGenerated(dotNetObject: any): Promise<any> {
    let jsBookmarkOptionsScreenshotSettings: any = {}
    if (hasValue(dotNetObject.layers)) {
        let {buildJsLayer} = await import('./layer');
        jsBookmarkOptionsScreenshotSettings.layers = await Promise.all(dotNetObject.layers.map(async i => await buildJsLayer(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.area)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedArea} = dotNetObject.area;
        jsBookmarkOptionsScreenshotSettings.area = sanitizedArea;
    }
    if (hasValue(dotNetObject.height)) {
        jsBookmarkOptionsScreenshotSettings.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.width)) {
        jsBookmarkOptionsScreenshotSettings.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBookmarkOptionsScreenshotSettings);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBookmarkOptionsScreenshotSettings;

    let dnInstantiatedObject = await buildDotNetBookmarkOptionsScreenshotSettings(jsBookmarkOptionsScreenshotSettings);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BookmarkOptionsScreenshotSettings', e);
    }

    return jsBookmarkOptionsScreenshotSettings;
}

export async function buildDotNetBookmarkOptionsScreenshotSettingsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBookmarkOptionsScreenshotSettings: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.area)) {
        dotNetBookmarkOptionsScreenshotSettings.area = jsObject.area;
    }
    if (hasValue(jsObject.height)) {
        dotNetBookmarkOptionsScreenshotSettings.height = jsObject.height;
    }
    if (hasValue(jsObject.width)) {
        dotNetBookmarkOptionsScreenshotSettings.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBookmarkOptionsScreenshotSettings.id = k;
                break;
            }
        }
    }

    return dotNetBookmarkOptionsScreenshotSettings;
}

