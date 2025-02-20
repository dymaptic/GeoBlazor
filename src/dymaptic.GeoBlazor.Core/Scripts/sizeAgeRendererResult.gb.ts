import {buildDotNetSizeAgeRendererResult} from './sizeAgeRendererResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSizeAgeRendererResultGenerated(dotNetObject: any): Promise<any> {
    let jssizeAgeRendererResult: any = {}
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsClassBreaksRenderer} = await import('./classBreaksRenderer');
        jssizeAgeRendererResult.renderer = await buildJsClassBreaksRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.visualVariables)) {
        let {buildJsSizeVariable} = await import('./sizeVariable');
        jssizeAgeRendererResult.visualVariables = await Promise.all(dotNetObject.visualVariables.map(async i => await buildJsSizeVariable(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.basemapId)) {
        jssizeAgeRendererResult.basemapId = dotNetObject.basemapId;
    }
    if (hasValue(dotNetObject.basemapTheme)) {
        jssizeAgeRendererResult.basemapTheme = dotNetObject.basemapTheme;
    }
    if (hasValue(dotNetObject.defaultValuesUsed)) {
        jssizeAgeRendererResult.defaultValuesUsed = dotNetObject.defaultValuesUsed;
    }
    if (hasValue(dotNetObject.sizeScheme)) {
        jssizeAgeRendererResult.sizeScheme = dotNetObject.sizeScheme;
    }
    if (hasValue(dotNetObject.statistics)) {
        jssizeAgeRendererResult.statistics = dotNetObject.statistics;
    }
    if (hasValue(dotNetObject.unit)) {
        jssizeAgeRendererResult.unit = dotNetObject.unit;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jssizeAgeRendererResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jssizeAgeRendererResult;

    let dnInstantiatedObject = await buildDotNetSizeAgeRendererResult(jssizeAgeRendererResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SizeAgeRendererResult', e);
    }

    return jssizeAgeRendererResult;
}

export async function buildDotNetSizeAgeRendererResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSizeAgeRendererResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetClassBreaksRenderer} = await import('./classBreaksRenderer');
        dotNetSizeAgeRendererResult.renderer = await buildDotNetClassBreaksRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.visualVariables)) {
        let {buildDotNetSizeVariable} = await import('./sizeVariable');
        dotNetSizeAgeRendererResult.visualVariables = await Promise.all(jsObject.visualVariables.map(async i => await buildDotNetSizeVariable(i)));
    }
    if (hasValue(jsObject.basemapId)) {
        dotNetSizeAgeRendererResult.basemapId = jsObject.basemapId;
    }
    if (hasValue(jsObject.basemapTheme)) {
        dotNetSizeAgeRendererResult.basemapTheme = jsObject.basemapTheme;
    }
    if (hasValue(jsObject.defaultValuesUsed)) {
        dotNetSizeAgeRendererResult.defaultValuesUsed = jsObject.defaultValuesUsed;
    }
    if (hasValue(jsObject.sizeScheme)) {
        dotNetSizeAgeRendererResult.sizeScheme = jsObject.sizeScheme;
    }
    if (hasValue(jsObject.statistics)) {
        dotNetSizeAgeRendererResult.statistics = jsObject.statistics;
    }
    if (hasValue(jsObject.unit)) {
        dotNetSizeAgeRendererResult.unit = jsObject.unit;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSizeAgeRendererResult.id = k;
                break;
            }
        }
    }

    return dotNetSizeAgeRendererResult;
}

