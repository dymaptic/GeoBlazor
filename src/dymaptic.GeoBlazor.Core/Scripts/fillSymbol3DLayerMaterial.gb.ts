import {buildDotNetFillSymbol3DLayerMaterial} from './fillSymbol3DLayerMaterial';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFillSymbol3DLayerMaterialGenerated(dotNetObject: any): Promise<any> {
    let jsFillSymbol3DLayerMaterial: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsFillSymbol3DLayerMaterial.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.colorMixMode)) {
        jsFillSymbol3DLayerMaterial.colorMixMode = dotNetObject.colorMixMode;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFillSymbol3DLayerMaterial);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFillSymbol3DLayerMaterial;

    let dnInstantiatedObject = await buildDotNetFillSymbol3DLayerMaterial(jsFillSymbol3DLayerMaterial);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FillSymbol3DLayerMaterial', e);
    }

    return jsFillSymbol3DLayerMaterial;
}

export async function buildDotNetFillSymbol3DLayerMaterialGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFillSymbol3DLayerMaterial: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetFillSymbol3DLayerMaterial.color = buildDotNetMapColor(jsObject.color);
    }
    if (hasValue(jsObject.colorMixMode)) {
        dotNetFillSymbol3DLayerMaterial.colorMixMode = jsObject.colorMixMode;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFillSymbol3DLayerMaterial.id = k;
                break;
            }
        }
    }

    return dotNetFillSymbol3DLayerMaterial;
}

