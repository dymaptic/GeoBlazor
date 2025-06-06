// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetIdentityManagerCredentialCreateEvent } from './identityManagerCredentialCreateEvent';

export async function buildJsIdentityManagerCredentialCreateEventGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsIdentityManagerCredentialCreateEvent: any = {};
    if (hasValue(dotNetObject.credential)) {
        let { buildJsCredential } = await import('./credential');
        jsIdentityManagerCredentialCreateEvent.credential = await buildJsCredential(dotNetObject.credential, layerId, viewId) as any;
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsIdentityManagerCredentialCreateEvent);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsIdentityManagerCredentialCreateEvent;
    
    return jsIdentityManagerCredentialCreateEvent;
}


export async function buildDotNetIdentityManagerCredentialCreateEventGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetIdentityManagerCredentialCreateEvent: any = {};
    
    if (hasValue(jsObject.credential)) {
        let { buildDotNetCredential } = await import('./credential');
        dotNetIdentityManagerCredentialCreateEvent.credential = await buildDotNetCredential(jsObject.credential, layerId, viewId);
    }
    

    return dotNetIdentityManagerCredentialCreateEvent;
}

