// override generated code in this file
import CapabilitiesMetadataGenerated from './capabilitiesMetadata.gb';
import CapabilitiesMetadata = __esri.CapabilitiesMetadata;

export default class CapabilitiesMetadataWrapper extends CapabilitiesMetadataGenerated {

    constructor(component: CapabilitiesMetadata) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesMetadata(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildJsCapabilitiesMetadataGenerated(dotNetObject);
}
export async function buildDotNetCapabilitiesMetadata(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesMetadataGenerated } = await import('./capabilitiesMetadata.gb');
    return await buildDotNetCapabilitiesMetadataGenerated(jsObject);
}
