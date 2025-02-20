import {buildDotNetColorRampColorsForClassBreaks} from './colorRampColorsForClassBreaks';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorRampColorsForClassBreaksGenerated(dotNetObject: any): Promise<any> {
    let jsColorRampColorsForClassBreaks: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorRampColorsForClassBreaks.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }

    if (hasValue(dotNetObject.numClasses)) {
        jsColorRampColorsForClassBreaks.numClasses = dotNetObject.numClasses;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorRampColorsForClassBreaks);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorRampColorsForClassBreaks;

    let dnInstantiatedObject = await buildDotNetColorRampColorsForClassBreaks(jsColorRampColorsForClassBreaks);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorRampColorsForClassBreaks', e);
    }

    return jsColorRampColorsForClassBreaks;
}

export async function buildDotNetColorRampColorsForClassBreaksGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorRampColorsForClassBreaks: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorRampColorsForClassBreaks.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.numClasses)) {
        dotNetColorRampColorsForClassBreaks.numClasses = jsObject.numClasses;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorRampColorsForClassBreaks.id = k;
                break;
            }
        }
    }

    return dotNetColorRampColorsForClassBreaks;
}

