import {buildDotNetRasterSliceValue} from './rasterSliceValue';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRasterSliceValueGenerated(dotNetObject: any): Promise<any> {
    let jsRasterSliceValue: any = {}

    if (hasValue(dotNetObject.magdirValue)) {
        jsRasterSliceValue.magdirValue = dotNetObject.magdirValue;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition)) {
        const {
            id,
            dotNetComponentReference,
            layerId,
            viewId,
            ...sanitizedMultidimensionalDefinition
        } = dotNetObject.multidimensionalDefinition;
        jsRasterSliceValue.multidimensionalDefinition = sanitizedMultidimensionalDefinition;
    }
    if (hasValue(dotNetObject.value)) {
        jsRasterSliceValue.value = dotNetObject.value;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsRasterSliceValue);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRasterSliceValue;

    let dnInstantiatedObject = await buildDotNetRasterSliceValue(jsRasterSliceValue);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RasterSliceValue', e);
    }

    return jsRasterSliceValue;
}

export async function buildDotNetRasterSliceValueGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRasterSliceValue: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.magdirValue)) {
        dotNetRasterSliceValue.magdirValue = jsObject.magdirValue;
    }
    if (hasValue(jsObject.multidimensionalDefinition)) {
        dotNetRasterSliceValue.multidimensionalDefinition = jsObject.multidimensionalDefinition;
    }
    if (hasValue(jsObject.value)) {
        dotNetRasterSliceValue.value = jsObject.value;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRasterSliceValue.id = k;
                break;
            }
        }
    }

    return dotNetRasterSliceValue;
}

