// override generated code in this file
import SmartMappingSupportUtilsGenerated from './smartMappingSupportUtils.gb';
import smartMappingSupportUtils = __esri.smartMappingSupportUtils;

export default class SmartMappingSupportUtilsWrapper extends SmartMappingSupportUtilsGenerated {

    constructor(component: smartMappingSupportUtils) {
        super(component);
    }
    
}

export async function buildJsSmartMappingSupportUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSmartMappingSupportUtilsGenerated } = await import('./smartMappingSupportUtils.gb');
    return await buildJsSmartMappingSupportUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSmartMappingSupportUtils(jsObject: any): Promise<any> {
    let { buildDotNetSmartMappingSupportUtilsGenerated } = await import('./smartMappingSupportUtils.gb');
    return await buildDotNetSmartMappingSupportUtilsGenerated(jsObject);
}
