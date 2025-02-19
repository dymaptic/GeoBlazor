// override generated code in this file
import ImageryLayerSaveAsOptionsGenerated from './imageryLayerSaveAsOptions.gb';
import ImageryLayerSaveAsOptions = __esri.ImageryLayerSaveAsOptions;

export default class ImageryLayerSaveAsOptionsWrapper extends ImageryLayerSaveAsOptionsGenerated {

    constructor(component: ImageryLayerSaveAsOptions) {
        super(component);
    }
    
}              
export async function buildJsImageryLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryLayerSaveAsOptionsGenerated } = await import('./imageryLayerSaveAsOptions.gb');
    return await buildJsImageryLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageryLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetImageryLayerSaveAsOptionsGenerated } = await import('./imageryLayerSaveAsOptions.gb');
    return await buildDotNetImageryLayerSaveAsOptionsGenerated(jsObject);
}
