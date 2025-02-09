// override generated code in this file
import ArcGISImageServiceCapabilitiesMensurationGenerated from './arcGISImageServiceCapabilitiesMensuration.gb';
import ArcGISImageServiceCapabilitiesMensuration = __esri.ArcGISImageServiceCapabilitiesMensuration;

export default class ArcGISImageServiceCapabilitiesMensurationWrapper extends ArcGISImageServiceCapabilitiesMensurationGenerated {

    constructor(component: ArcGISImageServiceCapabilitiesMensuration) {
        super(component);
    }
    
}              
export async function buildJsArcGISImageServiceCapabilitiesMensuration(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildJsArcGISImageServiceCapabilitiesMensurationGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetArcGISImageServiceCapabilitiesMensuration(jsObject: any): Promise<any> {
    let { buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated } = await import('./arcGISImageServiceCapabilitiesMensuration.gb');
    return await buildDotNetArcGISImageServiceCapabilitiesMensurationGenerated(jsObject);
}
