import {buildDotNetSchemes} from './schemes';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSchemesGenerated(dotNetObject: any): Promise<any> {
    let jsSchemes: any = {}
    if (hasValue(dotNetObject.primaryScheme)) {
        let {buildJsScheme} = await import('./scheme');
        jsSchemes.primaryScheme = await buildJsScheme(dotNetObject.primaryScheme, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.secondarySchemes)) {
        let {buildJsScheme} = await import('./scheme');
        jsSchemes.secondarySchemes = await Promise.all(dotNetObject.secondarySchemes.map(async i => await buildJsScheme(i, layerId, viewId))) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSchemes);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSchemes;

    let dnInstantiatedObject = await buildDotNetSchemes(jsSchemes);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for Schemes', e);
    }

    return jsSchemes;
}

export async function buildDotNetSchemesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSchemes: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.primaryScheme)) {
        let {buildDotNetScheme} = await import('./scheme');
        dotNetSchemes.primaryScheme = await buildDotNetScheme(jsObject.primaryScheme);
    }
    if (hasValue(jsObject.secondarySchemes)) {
        let {buildDotNetScheme} = await import('./scheme');
        dotNetSchemes.secondarySchemes = await Promise.all(jsObject.secondarySchemes.map(async i => await buildDotNetScheme(i)));
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSchemes.id = k;
                break;
            }
        }
    }

    return dotNetSchemes;
}

