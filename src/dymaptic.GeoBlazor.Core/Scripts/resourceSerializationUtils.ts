// override generated code in this file
import ResourceSerializationUtilsGenerated from './resourceSerializationUtils.gb';
import resourceSerializationUtils = __esri.resourceSerializationUtils;

export default class ResourceSerializationUtilsWrapper extends ResourceSerializationUtilsGenerated {

    constructor(component: resourceSerializationUtils) {
        super(component);
    }
    
}

export async function buildJsResourceSerializationUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsResourceSerializationUtilsGenerated } = await import('./resourceSerializationUtils.gb');
    return await buildJsResourceSerializationUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetResourceSerializationUtils(jsObject: any): Promise<any> {
    let { buildDotNetResourceSerializationUtilsGenerated } = await import('./resourceSerializationUtils.gb');
    return await buildDotNetResourceSerializationUtilsGenerated(jsObject);
}
