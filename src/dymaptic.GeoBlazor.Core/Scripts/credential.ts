// override generated code in this file
import CredentialGenerated from './credential.gb';
import Credential from '@arcgis/core/identity/Credential';

export default class CredentialWrapper extends CredentialGenerated {

    constructor(component: Credential) {
        super(component);
    }

}

export async function buildJsCredential(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCredentialGenerated} = await import('./credential.gb');
    return await buildJsCredentialGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCredential(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetCredentialGenerated} = await import('./credential.gb');
    return await buildDotNetCredentialGenerated(jsObject, layerId, viewId);
}
