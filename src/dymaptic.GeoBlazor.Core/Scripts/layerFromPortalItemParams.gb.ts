import {buildDotNetLayerFromPortalItemParams} from './layerFromPortalItemParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsLayerFromPortalItemParamsGenerated(dotNetObject: any): Promise<any> {
    let jsLayerFromPortalItemParams: any = {}
    if (hasValue(dotNetObject.portalItem)) {
        let {buildJsPortalItem} = await import('./portalItem');
        jsLayerFromPortalItemParams.portalItem = await buildJsPortalItem(dotNetObject.portalItem, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsLayerFromPortalItemParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsLayerFromPortalItemParams;

    let dnInstantiatedObject = await buildDotNetLayerFromPortalItemParams(jsLayerFromPortalItemParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for LayerFromPortalItemParams', e);
    }

    return jsLayerFromPortalItemParams;
}

export async function buildDotNetLayerFromPortalItemParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetLayerFromPortalItemParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.portalItem)) {
        let {buildDotNetPortalItem} = await import('./portalItem');
        dotNetLayerFromPortalItemParams.portalItem = await buildDotNetPortalItem(jsObject.portalItem);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetLayerFromPortalItemParams.id = k;
                break;
            }
        }
    }

    return dotNetLayerFromPortalItemParams;
}

