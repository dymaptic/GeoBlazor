import {buildDotNetClassedColorSliderViewModelBreaks} from './classedColorSliderViewModelBreaks';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsClassedColorSliderViewModelBreaksGenerated(dotNetObject: any): Promise<any> {
    let jsClassedColorSliderViewModelBreaks: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsClassedColorSliderViewModelBreaks.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.max)) {
        jsClassedColorSliderViewModelBreaks.max = dotNetObject.max;
    }
    if (hasValue(dotNetObject.min)) {
        jsClassedColorSliderViewModelBreaks.min = dotNetObject.min;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsClassedColorSliderViewModelBreaks);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsClassedColorSliderViewModelBreaks;

    let dnInstantiatedObject = await buildDotNetClassedColorSliderViewModelBreaks(jsClassedColorSliderViewModelBreaks);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ClassedColorSliderViewModelBreaks', e);
    }

    return jsClassedColorSliderViewModelBreaks;
}

export async function buildDotNetClassedColorSliderViewModelBreaksGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetClassedColorSliderViewModelBreaks: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetClassedColorSliderViewModelBreaks.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.max)) {
        dotNetClassedColorSliderViewModelBreaks.max = jsObject.max;
    }
    if (hasValue(jsObject.min)) {
        dotNetClassedColorSliderViewModelBreaks.min = jsObject.min;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetClassedColorSliderViewModelBreaks.id = k;
                break;
            }
        }
    }

    return dotNetClassedColorSliderViewModelBreaks;
}

