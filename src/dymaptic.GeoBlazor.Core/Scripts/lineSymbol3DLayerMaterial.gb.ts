import {buildDotNetLineSymbol3DLayerMaterial} from './lineSymbol3DLayerMaterial';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsLineSymbol3DLayerMaterialGenerated(dotNetObject: any): Promise<any> {
    let jsLineSymbol3DLayerMaterial: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsLineSymbol3DLayerMaterial.color = buildJsMapColor(dotNetObject.color) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLineSymbol3DLayerMaterial);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLineSymbol3DLayerMaterial;

    let dnInstantiatedObject = await buildDotNetLineSymbol3DLayerMaterial(jsLineSymbol3DLayerMaterial);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LineSymbol3DLayerMaterial', e);
    }

    return jsLineSymbol3DLayerMaterial;
}

export async function buildDotNetLineSymbol3DLayerMaterialGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLineSymbol3DLayerMaterial: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetLineSymbol3DLayerMaterial.color = buildDotNetMapColor(jsObject.color);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLineSymbol3DLayerMaterial.id = k;
                break;
            }
        }
    }

    return dotNetLineSymbol3DLayerMaterial;
}

