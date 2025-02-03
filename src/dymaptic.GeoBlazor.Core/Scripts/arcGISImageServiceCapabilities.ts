// override generated code in this file
import ArcGISImageServiceCapabilitiesGenerated from './arcGISImageServiceCapabilities.gb';
import ArcGISImageServiceCapabilities = __esri.ArcGISImageServiceCapabilities;

export default class ArcGISImageServiceCapabilitiesWrapper extends ArcGISImageServiceCapabilitiesGenerated {

    constructor(component: ArcGISImageServiceCapabilities) {
        super(component);
    }
    
}              
export async function buildJsArcGISImageServiceCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildJsArcGISImageServiceCapabilitiesGenerated(dotNetObject);
}
export async function buildDotNetArcGISImageServiceCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesGenerated } = await import('./arcGISImageServiceCapabilities.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesGenerated(jsObject);
}
