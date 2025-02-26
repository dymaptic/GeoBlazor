// override generated code in this file
import MultipartColorRamp from '@arcgis/core/rest/support/MultipartColorRamp';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetAlgorithmicColorRamp, buildJsAlgorithmicColorRamp} from './algorithmicColorRamp';


export function buildJsMultipartColorRamp(dotNetObject: any): any {
    let jsMultipartColorRamp = new MultipartColorRamp();
    if (hasValue(dotNetObject.colorRamps)) {
        jsMultipartColorRamp.colorRamps = dotNetObject.colorRamps.map(buildJsAlgorithmicColorRamp) as any;
    }

        let jsObjectRef = DotNet.createJSObjectReference(jsMultipartColorRamp);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsMultipartColorRamp;

    let dnInstantiatedObject = buildDotNetMultipartColorRamp(jsMultipartColorRamp);

    try {
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for MultipartColorRamp', e);
    }

    return jsMultipartColorRamp;
}

export function buildDotNetMultipartColorRamp(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMultipartColorRamp: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colorRamps)) {
        dotNetMultipartColorRamp.colorRamps = jsObject.colorRamps.map(i => buildDotNetAlgorithmicColorRamp(i));
    }
    if (hasValue(jsObject.type)) {
        dotNetMultipartColorRamp.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetMultipartColorRamp.id = k;
                break;
            }
        }
    }

    return dotNetMultipartColorRamp;
}
