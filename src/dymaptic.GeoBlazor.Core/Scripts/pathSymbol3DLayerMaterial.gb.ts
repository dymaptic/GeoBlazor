import {buildDotNetPathSymbol3DLayerMaterial} from './pathSymbol3DLayerMaterial';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsPathSymbol3DLayerMaterialGenerated(dotNetObject: any): Promise<any> {
    let jsPathSymbol3DLayerMaterial: any = {}
    if (hasValue(dotNetObject.color)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsPathSymbol3DLayerMaterial.color = buildJsMapColor(dotNetObject.color) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPathSymbol3DLayerMaterial);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPathSymbol3DLayerMaterial;

    let dnInstantiatedObject = await buildDotNetPathSymbol3DLayerMaterial(jsPathSymbol3DLayerMaterial);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PathSymbol3DLayerMaterial', e);
    }

    return jsPathSymbol3DLayerMaterial;
}

export async function buildDotNetPathSymbol3DLayerMaterialGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPathSymbol3DLayerMaterial: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.color)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetPathSymbol3DLayerMaterial.color = buildDotNetMapColor(jsObject.color);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPathSymbol3DLayerMaterial.id = k;
                break;
            }
        }
    }

    return dotNetPathSymbol3DLayerMaterial;
}

