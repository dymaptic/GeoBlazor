// override generated code in this file
import RasterFunctionGenerated from './rasterFunction.gb';
import RasterFunction from '@arcgis/core/layers/support/RasterFunction';

export default class RasterFunctionWrapper extends RasterFunctionGenerated {

    constructor(component: RasterFunction) {
        super(component);
    }
    
}              
export async function buildJsRasterFunction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildJsRasterFunctionGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRasterFunction(jsObject: any): Promise<any> {
    let { buildDotNetRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildDotNetRasterFunctionGenerated(jsObject);
}
