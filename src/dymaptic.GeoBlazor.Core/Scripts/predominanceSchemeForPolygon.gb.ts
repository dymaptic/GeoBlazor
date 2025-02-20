import {buildDotNetPredominanceSchemeForPolygon} from './predominanceSchemeForPolygon';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsPredominanceSchemeForPolygonGenerated(dotNetObject: any): Promise<any> {
    let jsPredominanceSchemeForPolygon: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsPredominanceSchemeForPolygon.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.noDataColor)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsPredominanceSchemeForPolygon.noDataColor = buildJsMapColor(dotNetObject.noDataColor) as any;
    }
    if (hasValue(dotNetObject.outline)) {
        let {buildJsPredominanceSchemeForPolygonOutline} = await import('./predominanceSchemeForPolygonOutline');
        jsPredominanceSchemeForPolygon.outline = await buildJsPredominanceSchemeForPolygonOutline(dotNetObject.outline, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.sizeScheme)) {
        let {buildJsSizeSchemeForPolygon} = await import('./sizeSchemeForPolygon');
        jsPredominanceSchemeForPolygon.sizeScheme = await buildJsSizeSchemeForPolygon(dotNetObject.sizeScheme, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.name)) {
        jsPredominanceSchemeForPolygon.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsPredominanceSchemeForPolygon.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.tags)) {
        jsPredominanceSchemeForPolygon.tags = dotNetObject.tags;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPredominanceSchemeForPolygon);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPredominanceSchemeForPolygon;

    let dnInstantiatedObject = await buildDotNetPredominanceSchemeForPolygon(jsPredominanceSchemeForPolygon);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PredominanceSchemeForPolygon', e);
    }

    return jsPredominanceSchemeForPolygon;
}

export async function buildDotNetPredominanceSchemeForPolygonGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPredominanceSchemeForPolygon: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetPredominanceSchemeForPolygon.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.noDataColor)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetPredominanceSchemeForPolygon.noDataColor = buildDotNetMapColor(jsObject.noDataColor);
    }
    if (hasValue(jsObject.outline)) {
        let {buildDotNetPredominanceSchemeForPolygonOutline} = await import('./predominanceSchemeForPolygonOutline');
        dotNetPredominanceSchemeForPolygon.outline = await buildDotNetPredominanceSchemeForPolygonOutline(jsObject.outline);
    }
    if (hasValue(jsObject.sizeScheme)) {
        let {buildDotNetSizeSchemeForPolygon} = await import('./sizeSchemeForPolygon');
        dotNetPredominanceSchemeForPolygon.sizeScheme = await buildDotNetSizeSchemeForPolygon(jsObject.sizeScheme);
    }
    if (hasValue(jsObject.name)) {
        dotNetPredominanceSchemeForPolygon.name = jsObject.name;
    }
    if (hasValue(jsObject.opacity)) {
        dotNetPredominanceSchemeForPolygon.opacity = jsObject.opacity;
    }
    if (hasValue(jsObject.tags)) {
        dotNetPredominanceSchemeForPolygon.tags = jsObject.tags;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPredominanceSchemeForPolygon.id = k;
                break;
            }
        }
    }

    return dotNetPredominanceSchemeForPolygon;
}

