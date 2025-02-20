import {buildDotNetOpacitySliderViewModelStopInfo} from './opacitySliderViewModelStopInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsOpacitySliderViewModelStopInfoGenerated(dotNetObject: any): Promise<any> {
    let jsOpacitySliderViewModelStopInfo: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsOpacitySliderViewModelStopInfo.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.offset)) {
        jsOpacitySliderViewModelStopInfo.offset = dotNetObject.offset;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsOpacitySliderViewModelStopInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsOpacitySliderViewModelStopInfo;

    let dnInstantiatedObject = await buildDotNetOpacitySliderViewModelStopInfo(jsOpacitySliderViewModelStopInfo);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for OpacitySliderViewModelStopInfo', e);
    }

    return jsOpacitySliderViewModelStopInfo;
}

export async function buildDotNetOpacitySliderViewModelStopInfoGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetOpacitySliderViewModelStopInfo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetOpacitySliderViewModelStopInfo.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.offset)) {
        dotNetOpacitySliderViewModelStopInfo.offset = jsObject.offset;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetOpacitySliderViewModelStopInfo.id = k;
                break;
            }
        }
    }

    return dotNetOpacitySliderViewModelStopInfo;
}

