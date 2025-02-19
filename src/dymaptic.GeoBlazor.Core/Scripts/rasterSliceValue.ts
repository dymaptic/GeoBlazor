// override generated code in this file
import RasterSliceValueGenerated from './rasterSliceValue.gb';
import RasterSliceValue = __esri.RasterSliceValue;

export default class RasterSliceValueWrapper extends RasterSliceValueGenerated {

    constructor(component: RasterSliceValue) {
        super(component);
    }
    
}              
export async function buildJsRasterSliceValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterSliceValueGenerated } = await import('./rasterSliceValue.gb');
    return await buildJsRasterSliceValueGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRasterSliceValue(jsObject: any): Promise<any> {
    let { buildDotNetRasterSliceValueGenerated } = await import('./rasterSliceValue.gb');
    return await buildDotNetRasterSliceValueGenerated(jsObject);
}
