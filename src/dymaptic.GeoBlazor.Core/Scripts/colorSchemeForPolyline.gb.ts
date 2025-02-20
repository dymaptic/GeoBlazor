import {buildDotNetColorSchemeForPolyline} from './colorSchemeForPolyline';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorSchemeForPolylineGenerated(dotNetObject: any): Promise<any> {
    let jsColorSchemeForPolyline: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForPolyline.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.colorsForClassBreaks)) {
        let {buildJsColorSchemeForPolylineColorsForClassBreaks} = await import('./colorSchemeForPolylineColorsForClassBreaks');
        jsColorSchemeForPolyline.colorsForClassBreaks = await Promise.all(dotNetObject.colorsForClassBreaks.map(async i => await buildJsColorSchemeForPolylineColorsForClassBreaks(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.noDataColor)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForPolyline.noDataColor = buildJsMapColor(dotNetObject.noDataColor) as any;
    }

    if (hasValue(dotNetObject.colorSchemeForPolylineId)) {
        jsColorSchemeForPolyline.id = dotNetObject.colorSchemeForPolylineId;
    }
    if (hasValue(dotNetObject.name)) {
        jsColorSchemeForPolyline.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsColorSchemeForPolyline.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.tags)) {
        jsColorSchemeForPolyline.tags = dotNetObject.tags;
    }
    if (hasValue(dotNetObject.theme)) {
        jsColorSchemeForPolyline.theme = dotNetObject.theme;
    }
    if (hasValue(dotNetObject.width)) {
        jsColorSchemeForPolyline.width = dotNetObject.width;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSchemeForPolyline);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSchemeForPolyline;

    let dnInstantiatedObject = await buildDotNetColorSchemeForPolyline(jsColorSchemeForPolyline);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSchemeForPolyline', e);
    }

    return jsColorSchemeForPolyline;
}

export async function buildDotNetColorSchemeForPolylineGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorSchemeForPolyline: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForPolyline.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.colorsForClassBreaks)) {
        let {buildDotNetColorSchemeForPolylineColorsForClassBreaks} = await import('./colorSchemeForPolylineColorsForClassBreaks');
        dotNetColorSchemeForPolyline.colorsForClassBreaks = await Promise.all(jsObject.colorsForClassBreaks.map(async i => await buildDotNetColorSchemeForPolylineColorsForClassBreaks(i)));
    }
    if (hasValue(jsObject.noDataColor)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForPolyline.noDataColor = buildDotNetMapColor(jsObject.noDataColor);
    }
    if (hasValue(jsObject.id)) {
        dotNetColorSchemeForPolyline.colorSchemeForPolylineId = jsObject.id;
    }
    if (hasValue(jsObject.name)) {
        dotNetColorSchemeForPolyline.name = jsObject.name;
    }
    if (hasValue(jsObject.opacity)) {
        dotNetColorSchemeForPolyline.opacity = jsObject.opacity;
    }
    if (hasValue(jsObject.tags)) {
        dotNetColorSchemeForPolyline.tags = jsObject.tags;
    }
    if (hasValue(jsObject.theme)) {
        dotNetColorSchemeForPolyline.theme = jsObject.theme;
    }
    if (hasValue(jsObject.width)) {
        dotNetColorSchemeForPolyline.width = jsObject.width;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSchemeForPolyline.id = k;
                break;
            }
        }
    }

    return dotNetColorSchemeForPolyline;
}

