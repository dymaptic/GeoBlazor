// override generated code in this file
import IDisplayFilteredLayerGenerated from './iDisplayFilteredLayer.gb';
import DisplayFilteredLayer = __esri.DisplayFilteredLayer;

export async function buildJsIDisplayFilteredLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIDisplayFilteredLayerGenerated } = await import('./iDisplayFilteredLayer.gb');
    return await buildJsIDisplayFilteredLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIDisplayFilteredLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIDisplayFilteredLayerGenerated } = await import('./iDisplayFilteredLayer.gb');
    return await buildDotNetIDisplayFilteredLayerGenerated(jsObject, viewId);
}
