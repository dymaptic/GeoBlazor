// override generated code in this file
import AlgorithmicColorRamp from '@arcgis/core/rest/support/AlgorithmicColorRamp';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";
import {buildDotNetMapColor, buildJsMapColor} from './mapColor';

export function buildJsAlgorithmicColorRamp(dotNetObject: any): any {
    let jsAlgorithmicColorRamp = new AlgorithmicColorRamp();
    if (hasValue(dotNetObject.fromColor)) {
        jsAlgorithmicColorRamp.fromColor = buildJsMapColor(dotNetObject.fromColor) as any;
    }
    if (hasValue(dotNetObject.toColor)) {
        jsAlgorithmicColorRamp.toColor = buildJsMapColor(dotNetObject.toColor) as any;
    }

    if (hasValue(dotNetObject.algorithm)) {
        jsAlgorithmicColorRamp.algorithm = dotNetObject.algorithm;
    }

    let jsObjectRef = DotNet.createJSObjectReference(jsAlgorithmicColorRamp);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsAlgorithmicColorRamp;

    return jsAlgorithmicColorRamp;
}

export function buildDotNetAlgorithmicColorRamp(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetAlgorithmicColorRamp: any = {
                jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.fromColor)) {
        dotNetAlgorithmicColorRamp.fromColor = buildDotNetMapColor(jsObject.fromColor);
    }
    if (hasValue(jsObject.toColor)) {
        dotNetAlgorithmicColorRamp.toColor = buildDotNetMapColor(jsObject.toColor);
    }
    if (hasValue(jsObject.algorithm)) {
        dotNetAlgorithmicColorRamp.algorithm = jsObject.algorithm;
    }
    if (hasValue(jsObject.type)) {
        dotNetAlgorithmicColorRamp.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetAlgorithmicColorRamp.id = k;
                break;
            }
        }
    }

    return dotNetAlgorithmicColorRamp;
}
