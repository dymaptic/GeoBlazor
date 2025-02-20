import {buildDotNetVisualVariablesResult} from './visualVariablesResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsVisualVariablesResultGenerated(dotNetObject: any): Promise<any> {
    let jsVisualVariablesResult: any = {}
    if (hasValue(dotNetObject.authoringInfo)) {
        let {buildJsAuthoringInfo} = await import('./authoringInfo');
        jsVisualVariablesResult.authoringInfo = await buildJsAuthoringInfo(dotNetObject.authoringInfo, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.color)) {
        let {buildJsVisualVariablesResultColor} = await import('./visualVariablesResultColor');
        jsVisualVariablesResult.color = await buildJsVisualVariablesResultColor(dotNetObject.color, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.size)) {
        let {buildJsVisualVariablesResultSize} = await import('./visualVariablesResultSize');
        jsVisualVariablesResult.size = await buildJsVisualVariablesResultSize(dotNetObject.size, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.basemapId)) {
        jsVisualVariablesResult.basemapId = dotNetObject.basemapId;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jsVisualVariablesResult.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.defaultValuesUsed)) {
        jsVisualVariablesResult.defaultValuesUsed = dotNetObject.defaultValuesUsed;
    }
    if (hasValue(dotNetObject.statistics)) {
        jsVisualVariablesResult.statistics = dotNetObject.statistics;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsVisualVariablesResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsVisualVariablesResult;

    let dnInstantiatedObject = await buildDotNetVisualVariablesResult(jsVisualVariablesResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for VisualVariablesResult', e);
    }

    return jsVisualVariablesResult;
}

export async function buildDotNetVisualVariablesResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetVisualVariablesResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.authoringInfo)) {
        let {buildDotNetAuthoringInfo} = await import('./authoringInfo');
        dotNetVisualVariablesResult.authoringInfo = await buildDotNetAuthoringInfo(jsObject.authoringInfo);
    }
    if (hasValue(jsObject.color)) {
        let {buildDotNetVisualVariablesResultColor} = await import('./visualVariablesResultColor');
        dotNetVisualVariablesResult.color = await buildDotNetVisualVariablesResultColor(jsObject.color);
    }
    if (hasValue(jsObject.size)) {
        let {buildDotNetVisualVariablesResultSize} = await import('./visualVariablesResultSize');
        dotNetVisualVariablesResult.size = await buildDotNetVisualVariablesResultSize(jsObject.size);
    }
    if (hasValue(jsObject.basemapId)) {
        dotNetVisualVariablesResult.basemapId = jsObject.basemapId;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetVisualVariablesResult.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.defaultValuesUsed)) {
        dotNetVisualVariablesResult.defaultValuesUsed = jsObject.defaultValuesUsed;
    }
    if (hasValue(jsObject.statistics)) {
        dotNetVisualVariablesResult.statistics = jsObject.statistics;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetVisualVariablesResult.id = k;
                break;
            }
        }
    }

    return dotNetVisualVariablesResult;
}

