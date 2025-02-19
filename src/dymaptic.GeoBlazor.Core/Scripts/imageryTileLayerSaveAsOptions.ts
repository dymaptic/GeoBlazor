// override generated code in this file
import ImageryTileLayerSaveAsOptionsGenerated from './imageryTileLayerSaveAsOptions.gb';
import ImageryTileLayerSaveAsOptions = __esri.ImageryTileLayerSaveAsOptions;

export default class ImageryTileLayerSaveAsOptionsWrapper extends ImageryTileLayerSaveAsOptionsGenerated {

    constructor(component: ImageryTileLayerSaveAsOptions) {
        super(component);
    }
    
}              
export async function buildJsImageryTileLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryTileLayerSaveAsOptionsGenerated } = await import('./imageryTileLayerSaveAsOptions.gb');
    return await buildJsImageryTileLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageryTileLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetImageryTileLayerSaveAsOptionsGenerated } = await import('./imageryTileLayerSaveAsOptions.gb');
    return await buildDotNetImageryTileLayerSaveAsOptionsGenerated(jsObject);
}
