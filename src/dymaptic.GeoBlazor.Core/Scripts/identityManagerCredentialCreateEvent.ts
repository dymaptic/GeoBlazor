export async function buildJsIdentityManagerCredentialCreateEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIdentityManagerCredentialCreateEventGenerated} = await import('./identityManagerCredentialCreateEvent.gb');
    return await buildJsIdentityManagerCredentialCreateEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIdentityManagerCredentialCreateEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetIdentityManagerCredentialCreateEventGenerated} = await import('./identityManagerCredentialCreateEvent.gb');
    return await buildDotNetIdentityManagerCredentialCreateEventGenerated(jsObject, layerId, viewId);
}
