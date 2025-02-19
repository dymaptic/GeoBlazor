// override generated code in this file
import JsonUtilsGenerated from './jsonUtils.gb';
import jsonUtils = __esri.jsonUtils;

export default class JsonUtilsWrapper extends JsonUtilsGenerated {

    constructor(component: jsonUtils) {
        super(component);
    }
    
}

export async function buildJsJsonUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsJsonUtilsGenerated } = await import('./jsonUtils.gb');
    return await buildJsJsonUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetJsonUtils(jsObject: any): Promise<any> {
    let { buildDotNetJsonUtilsGenerated } = await import('./jsonUtils.gb');
    return await buildDotNetJsonUtilsGenerated(jsObject);
}
