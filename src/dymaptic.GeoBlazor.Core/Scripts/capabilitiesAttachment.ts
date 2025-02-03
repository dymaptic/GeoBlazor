// override generated code in this file
import CapabilitiesAttachmentGenerated from './capabilitiesAttachment.gb';
import CapabilitiesAttachment = __esri.CapabilitiesAttachment;

export default class CapabilitiesAttachmentWrapper extends CapabilitiesAttachmentGenerated {

    constructor(component: CapabilitiesAttachment) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesAttachment(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesAttachmentGenerated } = await import('./capabilitiesAttachment.gb');
    return await buildJsCapabilitiesAttachmentGenerated(dotNetObject);
}
export async function buildDotNetCapabilitiesAttachment(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesAttachmentGenerated } = await import('./capabilitiesAttachment.gb');
    return await buildDotNetCapabilitiesAttachmentGenerated(jsObject);
}
