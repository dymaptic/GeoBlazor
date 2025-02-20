import {buildDotNetIdentityManagerCredentialCreateEvent} from './identityManagerCredentialCreateEvent';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsIdentityManagerCredentialCreateEventGenerated(dotNetObject: any): Promise<any> {
    let jsIdentityManagerCredentialCreateEvent: any = {}
    if (hasValue(dotNetObject.credential)) {
        let {buildJsCredential} = await import('./credential');
        jsIdentityManagerCredentialCreateEvent.credential = await buildJsCredential(dotNetObject.credential, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsIdentityManagerCredentialCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsIdentityManagerCredentialCreateEvent;

    let dnInstantiatedObject = await buildDotNetIdentityManagerCredentialCreateEvent(jsIdentityManagerCredentialCreateEvent);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for IdentityManagerCredentialCreateEvent', e);
    }

    return jsIdentityManagerCredentialCreateEvent;
}

export async function buildDotNetIdentityManagerCredentialCreateEventGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetIdentityManagerCredentialCreateEvent: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.credential)) {
        let {buildDotNetCredential} = await import('./credential');
        dotNetIdentityManagerCredentialCreateEvent.credential = await buildDotNetCredential(jsObject.credential);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetIdentityManagerCredentialCreateEvent.id = k;
                break;
            }
        }
    }

    return dotNetIdentityManagerCredentialCreateEvent;
}

