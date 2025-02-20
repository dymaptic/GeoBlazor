import {buildDotNetSizeSchemeForPolygonBackground} from './sizeSchemeForPolygonBackground';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeSchemeForPolygonBackgroundGenerated(dotNetObject: any): Promise<any> {
    let jsSizeSchemeForPolygonBackground: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsSizeSchemeForPolygonBackground.color = buildJsMapColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.outline)) {
        let {buildJsSizeSchemeForPolygonBackgroundOutline} = await import('./sizeSchemeForPolygonBackgroundOutline');
        jsSizeSchemeForPolygonBackground.outline = await buildJsSizeSchemeForPolygonBackgroundOutline(dotNetObject.outline, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSizeSchemeForPolygonBackground);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSizeSchemeForPolygonBackground;

    let dnInstantiatedObject = await buildDotNetSizeSchemeForPolygonBackground(jsSizeSchemeForPolygonBackground);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeSchemeForPolygonBackground', e);
    }

    return jsSizeSchemeForPolygonBackground;
}

export async function buildDotNetSizeSchemeForPolygonBackgroundGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeSchemeForPolygonBackground: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetSizeSchemeForPolygonBackground.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.outline)) {
        let {buildDotNetSizeSchemeForPolygonBackgroundOutline} = await import('./sizeSchemeForPolygonBackgroundOutline');
        dotNetSizeSchemeForPolygonBackground.outline = await buildDotNetSizeSchemeForPolygonBackgroundOutline(jsObject.outline);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeSchemeForPolygonBackground.id = k;
                break;
            }
        }
    }

    return dotNetSizeSchemeForPolygonBackground;
}

