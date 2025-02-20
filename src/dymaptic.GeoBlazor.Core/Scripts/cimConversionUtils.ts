import cimConversionUtils = __esri.cimConversionUtils;
import CimConversionUtilsGenerated from './cimConversionUtils.gb';

export default class CimConversionUtilsWrapper extends CimConversionUtilsGenerated {

    constructor(component: cimConversionUtils) {
        super(component);
    }

}

export async function buildJsCimConversionUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCimConversionUtilsGenerated} = await import('./cimConversionUtils.gb');
    return await buildJsCimConversionUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCimConversionUtils(jsObject: any): Promise<any> {
    let {buildDotNetCimConversionUtilsGenerated} = await import('./cimConversionUtils.gb');
    return await buildDotNetCimConversionUtilsGenerated(jsObject);
}
