import {buildDotNetUnivariateColorSizeContinuousRendererResult} from './univariateColorSizeContinuousRendererResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsUnivariateColorSizeContinuousRendererResultGenerated(dotNetObject: any): Promise<any> {
    let jsunivariateColorSizeContinuousRendererResult: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsContinuousRendererResultColor} = await import('./continuousRendererResultColor');
        jsunivariateColorSizeContinuousRendererResult.color = await buildJsContinuousRendererResultColor(dotNetObject.color, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsClassBreaksRenderer} = await import('./classBreaksRenderer');
        jsunivariateColorSizeContinuousRendererResult.renderer = await buildJsClassBreaksRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.size)) {
        let {buildJsContinuousRendererResultSize} = await import('./continuousRendererResultSize');
        jsunivariateColorSizeContinuousRendererResult.size = await buildJsContinuousRendererResultSize(dotNetObject.size, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.basemapId)) {
        jsunivariateColorSizeContinuousRendererResult.basemapId = dotNetObject.basemapId;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jsunivariateColorSizeContinuousRendererResult.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.defaultValuesUsed)) {
        jsunivariateColorSizeContinuousRendererResult.defaultValuesUsed = dotNetObject.defaultValuesUsed;
    }
    if (hasValue(dotNetObject.statistics)) {
        jsunivariateColorSizeContinuousRendererResult.statistics = dotNetObject.statistics;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsunivariateColorSizeContinuousRendererResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsunivariateColorSizeContinuousRendererResult;

    let dnInstantiatedObject = await buildDotNetUnivariateColorSizeContinuousRendererResult(jsunivariateColorSizeContinuousRendererResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for UnivariateColorSizeContinuousRendererResult', e);
    }

    return jsunivariateColorSizeContinuousRendererResult;
}

export async function buildDotNetUnivariateColorSizeContinuousRendererResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetUnivariateColorSizeContinuousRendererResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetContinuousRendererResultColor} = await import('./continuousRendererResultColor');
        dotNetUnivariateColorSizeContinuousRendererResult.color = await buildDotNetContinuousRendererResultColor(jsObject.color);
    }
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetClassBreaksRenderer} = await import('./classBreaksRenderer');
        dotNetUnivariateColorSizeContinuousRendererResult.renderer = await buildDotNetClassBreaksRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.size)) {
        let {buildDotNetContinuousRendererResultSize} = await import('./continuousRendererResultSize');
        dotNetUnivariateColorSizeContinuousRendererResult.size = await buildDotNetContinuousRendererResultSize(jsObject.size);
    }
    if (hasValue(jsObject.basemapId)) {
        dotNetUnivariateColorSizeContinuousRendererResult.basemapId = jsObject.basemapId;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetUnivariateColorSizeContinuousRendererResult.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.defaultValuesUsed)) {
        dotNetUnivariateColorSizeContinuousRendererResult.defaultValuesUsed = jsObject.defaultValuesUsed;
    }
    if (hasValue(jsObject.statistics)) {
        dotNetUnivariateColorSizeContinuousRendererResult.statistics = jsObject.statistics;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetUnivariateColorSizeContinuousRendererResult.id = k;
                break;
            }
        }
    }

    return dotNetUnivariateColorSizeContinuousRendererResult;
}

