// override generated code in this file
import ManagedDepthAttachmentGenerated from './managedDepthAttachment.gb';
import ManagedDepthAttachment = __esri.ManagedDepthAttachment;

export default class ManagedDepthAttachmentWrapper extends ManagedDepthAttachmentGenerated {

    constructor(component: ManagedDepthAttachment) {
        super(component);
    }
    
}

export async function buildJsManagedDepthAttachment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsManagedDepthAttachmentGenerated } = await import('./managedDepthAttachment.gb');
    return await buildJsManagedDepthAttachmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetManagedDepthAttachment(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetManagedDepthAttachmentGenerated } = await import('./managedDepthAttachment.gb');
    return await buildDotNetManagedDepthAttachmentGenerated(jsObject, layerId, viewId);
}
