import {buildDotNetPopupTemplateCreatorEvent} from './popupTemplateCreatorEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsPopupTemplateCreatorEventGenerated(dotNetObject: any): Promise<any> {
    let jsPopupTemplateCreatorEvent: any = {}
    if (hasValue(dotNetObject.graphic)) {
        let {buildJsGraphic} = await import('./graphic');
        jsPopupTemplateCreatorEvent.graphic = buildJsGraphic(dotNetObject.graphic) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsPopupTemplateCreatorEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsPopupTemplateCreatorEvent;

    let dnInstantiatedObject = await buildDotNetPopupTemplateCreatorEvent(jsPopupTemplateCreatorEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PopupTemplateCreatorEvent', e);
    }

    return jsPopupTemplateCreatorEvent;
}

export async function buildDotNetPopupTemplateCreatorEventGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetPopupTemplateCreatorEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.graphic)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetPopupTemplateCreatorEvent.graphic = buildDotNetGraphic(jsObject.graphic, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetPopupTemplateCreatorEvent.id = k;
                break;
            }
        }
    }

    return dotNetPopupTemplateCreatorEvent;
}

