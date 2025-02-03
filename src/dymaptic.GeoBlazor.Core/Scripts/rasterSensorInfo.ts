// override generated code in this file
import RasterSensorInfoGenerated from './rasterSensorInfo.gb';
import RasterSensorInfo from '@arcgis/core/layers/support/RasterSensorInfo';

export default class RasterSensorInfoWrapper extends RasterSensorInfoGenerated {

    constructor(component: RasterSensorInfo) {
        super(component);
    }
    
}              
export async function buildJsRasterSensorInfo(dotNetObject: any): Promise<any> {
    let { buildJsRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildJsRasterSensorInfoGenerated(dotNetObject);
}
export async function buildDotNetRasterSensorInfo(jsObject: any): Promise<any> {
    let { buildDotNetRasterSensorInfoGenerated } = await import('./rasterSensorInfo.gb');
    return await buildDotNetRasterSensorInfoGenerated(jsObject);
}
