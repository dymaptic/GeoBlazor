import {buildDotNetColorSchemeForPointColorsForClassBreaks} from './colorSchemeForPointColorsForClassBreaks';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorSchemeForPointColorsForClassBreaksGenerated(dotNetObject: any): Promise<any> {
    let jsColorSchemeForPointColorsForClassBreaks: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForPointColorsForClassBreaks.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }

    if (hasValue(dotNetObject.numClasses)) {
        jsColorSchemeForPointColorsForClassBreaks.numClasses = dotNetObject.numClasses;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSchemeForPointColorsForClassBreaks);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSchemeForPointColorsForClassBreaks;

    let dnInstantiatedObject = await buildDotNetColorSchemeForPointColorsForClassBreaks(jsColorSchemeForPointColorsForClassBreaks);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSchemeForPointColorsForClassBreaks', e);
    }

    return jsColorSchemeForPointColorsForClassBreaks;
}

export async function buildDotNetColorSchemeForPointColorsForClassBreaksGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorSchemeForPointColorsForClassBreaks: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForPointColorsForClassBreaks.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.numClasses)) {
        dotNetColorSchemeForPointColorsForClassBreaks.numClasses = jsObject.numClasses;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSchemeForPointColorsForClassBreaks.id = k;
                break;
            }
        }
    }

    return dotNetColorSchemeForPointColorsForClassBreaks;
}

