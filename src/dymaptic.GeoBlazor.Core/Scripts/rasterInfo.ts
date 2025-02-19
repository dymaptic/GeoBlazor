// override generated code in this file
import RasterInfoGenerated from './rasterInfo.gb';
import RasterInfo from '@arcgis/core/layers/support/RasterInfo';

export default class RasterInfoWrapper extends RasterInfoGenerated {

    constructor(component: RasterInfo) {
        super(component);
    }
    
}              
export async function buildJsRasterInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterInfoGenerated } = await import('./rasterInfo.gb');
    return await buildJsRasterInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRasterInfo(jsObject: any): Promise<any> {
    let { buildDotNetRasterInfoGenerated } = await import('./rasterInfo.gb');
    return await buildDotNetRasterInfoGenerated(jsObject);
}
