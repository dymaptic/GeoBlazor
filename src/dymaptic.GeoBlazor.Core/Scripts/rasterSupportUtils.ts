// override generated code in this file
import RasterSupportUtilsGenerated from './rasterSupportUtils.gb';
import rasterSupportUtils = __esri.rasterSupportUtils;

export default class RasterSupportUtilsWrapper extends RasterSupportUtilsGenerated {

    constructor(component: rasterSupportUtils) {
        super(component);
    }
    
}

export async function buildJsRasterSupportUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterSupportUtilsGenerated } = await import('./rasterSupportUtils.gb');
    return await buildJsRasterSupportUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterSupportUtils(jsObject: any): Promise<any> {
    let { buildDotNetRasterSupportUtilsGenerated } = await import('./rasterSupportUtils.gb');
    return await buildDotNetRasterSupportUtilsGenerated(jsObject);
}
