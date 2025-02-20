import ManagedColorAttachment = __esri.ManagedColorAttachment;
import ManagedColorAttachmentGenerated from './managedColorAttachment.gb';

export default class ManagedColorAttachmentWrapper extends ManagedColorAttachmentGenerated {

    constructor(component: ManagedColorAttachment) {
        super(component);
    }

}

export async function buildJsManagedColorAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsManagedColorAttachmentGenerated} = await import('./managedColorAttachment.gb');
    return await buildJsManagedColorAttachmentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetManagedColorAttachment(jsObject: any): Promise<any> {
    let {buildDotNetManagedColorAttachmentGenerated} = await import('./managedColorAttachment.gb');
    return await buildDotNetManagedColorAttachmentGenerated(jsObject);
}
