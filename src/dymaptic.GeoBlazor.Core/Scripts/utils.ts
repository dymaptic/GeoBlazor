// override generated code in this file
import UtilsGenerated from './utils.gb';
import utils = __esri.utils;

export default class UtilsWrapper extends UtilsGenerated {

    constructor(component: utils) {
        super(component);
    }
    
}

export async function buildJsUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUtilsGenerated } = await import('./utils.gb');
    return await buildJsUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUtils(jsObject: any): Promise<any> {
    let { buildDotNetUtilsGenerated } = await import('./utils.gb');
    return await buildDotNetUtilsGenerated(jsObject);
}
