import ManagedDepthAttachment = __esri.ManagedDepthAttachment;
import ManagedDepthAttachmentGenerated from './managedDepthAttachment.gb';

export default class ManagedDepthAttachmentWrapper extends ManagedDepthAttachmentGenerated {

    constructor(component: ManagedDepthAttachment) {
        super(component);
    }
    
}

export async function buildJsManagedDepthAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsManagedDepthAttachmentGenerated } = await import('./managedDepthAttachment.gb');
    return await buildJsManagedDepthAttachmentGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetManagedDepthAttachment(jsObject: any): Promise<any> {
    let { buildDotNetManagedDepthAttachmentGenerated } = await import('./managedDepthAttachment.gb');
    return await buildDotNetManagedDepthAttachmentGenerated(jsObject);
}
