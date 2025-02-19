// override generated code in this file
import RasterFunctionUtilsGenerated from './rasterFunctionUtils.gb';
import rasterFunctionUtils = __esri.rasterFunctionUtils;

export default class RasterFunctionUtilsWrapper extends RasterFunctionUtilsGenerated {

    constructor(component: rasterFunctionUtils) {
        super(component);
    }
    
}

export async function buildJsRasterFunctionUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionUtilsGenerated } = await import('./rasterFunctionUtils.gb');
    return await buildJsRasterFunctionUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionUtils(jsObject: any): Promise<any> {
    let { buildDotNetRasterFunctionUtilsGenerated } = await import('./rasterFunctionUtils.gb');
    return await buildDotNetRasterFunctionUtilsGenerated(jsObject);
}
