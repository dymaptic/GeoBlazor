import {buildDotNetAttributionItem} from './attributionItem';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsAttributionItemGenerated(dotNetObject: any): Promise<any> {
    let jsAttributionItem: any = {}
    if (hasValue(dotNetObject.layer)) {
        let {buildJsLayer} = await import('./layer');
        jsAttributionItem.layer = await buildJsLayer(dotNetObject.layer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.text)) {
        jsAttributionItem.text = dotNetObject.text;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsAttributionItem);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsAttributionItem;

    let dnInstantiatedObject = await buildDotNetAttributionItem(jsAttributionItem);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for AttributionItem', e);
    }

    return jsAttributionItem;
}

export async function buildDotNetAttributionItemGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetAttributionItem: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.text)) {
        dotNetAttributionItem.text = jsObject.text;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetAttributionItem.id = k;
                break;
            }
        }
    }

    return dotNetAttributionItem;
}

