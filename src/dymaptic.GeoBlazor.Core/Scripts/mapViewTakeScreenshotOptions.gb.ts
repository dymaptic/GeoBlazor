import {buildDotNetMapViewTakeScreenshotOptions} from './mapViewTakeScreenshotOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsMapViewTakeScreenshotOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsMapViewTakeScreenshotOptions: any = {}
    if (hasValue(dotNetObject.format)) {
        let {buildJsFormat} = await import('./format');
        jsMapViewTakeScreenshotOptions.format = await buildJsFormat(dotNetObject.format, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.layers)) {
        let {buildJsLayer} = await import('./layer');
        jsMapViewTakeScreenshotOptions.layers = await Promise.all(dotNetObject.layers.map(async i => await buildJsLayer(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.area)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedArea} = dotNetObject.area;
        jsMapViewTakeScreenshotOptions.area = sanitizedArea;
    }
    if (hasValue(dotNetObject.height)) {
        jsMapViewTakeScreenshotOptions.height = dotNetObject.height;
    }
    if (hasValue(dotNetObject.ignoreBackground)) {
        jsMapViewTakeScreenshotOptions.ignoreBackground = dotNetObject.ignoreBackground;
    }
    if (hasValue(dotNetObject.ignorePadding)) {
        jsMapViewTakeScreenshotOptions.ignorePadding = dotNetObject.ignorePadding;
    }
    if (hasValue(dotNetObject.quality)) {
        jsMapViewTakeScreenshotOptions.quality = dotNetObject.quality;
    }
    if (hasValue(dotNetObject.width)) {
        jsMapViewTakeScreenshotOptions.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsMapViewTakeScreenshotOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMapViewTakeScreenshotOptions;

    let dnInstantiatedObject = await buildDotNetMapViewTakeScreenshotOptions(jsMapViewTakeScreenshotOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MapViewTakeScreenshotOptions', e);
    }

    return jsMapViewTakeScreenshotOptions;
}

export async function buildDotNetMapViewTakeScreenshotOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMapViewTakeScreenshotOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.format)) {
        let {buildDotNetFormat} = await import('./format');
        dotNetMapViewTakeScreenshotOptions.format = await buildDotNetFormat(jsObject.format);
    }
    if (hasValue(jsObject.area)) {
        dotNetMapViewTakeScreenshotOptions.area = jsObject.area;
    }
    if (hasValue(jsObject.height)) {
        dotNetMapViewTakeScreenshotOptions.height = jsObject.height;
    }
    if (hasValue(jsObject.ignoreBackground)) {
        dotNetMapViewTakeScreenshotOptions.ignoreBackground = jsObject.ignoreBackground;
    }
    if (hasValue(jsObject.ignorePadding)) {
        dotNetMapViewTakeScreenshotOptions.ignorePadding = jsObject.ignorePadding;
    }
    if (hasValue(jsObject.quality)) {
        dotNetMapViewTakeScreenshotOptions.quality = jsObject.quality;
    }
    if (hasValue(jsObject.width)) {
        dotNetMapViewTakeScreenshotOptions.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMapViewTakeScreenshotOptions.id = k;
                break;
            }
        }
    }

    return dotNetMapViewTakeScreenshotOptions;
}

