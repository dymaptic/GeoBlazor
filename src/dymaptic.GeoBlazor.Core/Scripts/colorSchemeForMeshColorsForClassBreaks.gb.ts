import {buildDotNetColorSchemeForMeshColorsForClassBreaks} from './colorSchemeForMeshColorsForClassBreaks';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorSchemeForMeshColorsForClassBreaksGenerated(dotNetObject: any): Promise<any> {
    let jsColorSchemeForMeshColorsForClassBreaks: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForMeshColorsForClassBreaks.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }

    if (hasValue(dotNetObject.numClasses)) {
        jsColorSchemeForMeshColorsForClassBreaks.numClasses = dotNetObject.numClasses;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSchemeForMeshColorsForClassBreaks);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSchemeForMeshColorsForClassBreaks;

    let dnInstantiatedObject = await buildDotNetColorSchemeForMeshColorsForClassBreaks(jsColorSchemeForMeshColorsForClassBreaks);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSchemeForMeshColorsForClassBreaks', e);
    }

    return jsColorSchemeForMeshColorsForClassBreaks;
}

export async function buildDotNetColorSchemeForMeshColorsForClassBreaksGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorSchemeForMeshColorsForClassBreaks: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForMeshColorsForClassBreaks.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.numClasses)) {
        dotNetColorSchemeForMeshColorsForClassBreaks.numClasses = jsObject.numClasses;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSchemeForMeshColorsForClassBreaks.id = k;
                break;
            }
        }
    }

    return dotNetColorSchemeForMeshColorsForClassBreaks;
}

