import {buildDotNetTextSymbol3DLayerMaterial} from './textSymbol3DLayerMaterial';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTextSymbol3DLayerMaterialGenerated(dotNetObject: any): Promise<any> {
    let jsTextSymbol3DLayerMaterial: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsTextSymbol3DLayerMaterial.color = buildJsMapColor(dotNetObject.color) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTextSymbol3DLayerMaterial);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsTextSymbol3DLayerMaterial;

    let dnInstantiatedObject = await buildDotNetTextSymbol3DLayerMaterial(jsTextSymbol3DLayerMaterial);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TextSymbol3DLayerMaterial', e);
    }

    return jsTextSymbol3DLayerMaterial;
}

export async function buildDotNetTextSymbol3DLayerMaterialGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTextSymbol3DLayerMaterial: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetTextSymbol3DLayerMaterial.color = buildDotNetMapColor(jsObject.color);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTextSymbol3DLayerMaterial.id = k;
                break;
            }
        }
    }

    return dotNetTextSymbol3DLayerMaterial;
}

