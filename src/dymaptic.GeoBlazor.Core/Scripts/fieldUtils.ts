// override generated code in this file
import FieldUtilsGenerated from './fieldUtils.gb';
import fieldUtils = __esri.fieldUtils;

export default class FieldUtilsWrapper extends FieldUtilsGenerated {

    constructor(component: fieldUtils) {
        super(component);
    }
    
}

export async function buildJsFieldUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFieldUtilsGenerated } = await import('./fieldUtils.gb');
    return await buildJsFieldUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFieldUtils(jsObject: any): Promise<any> {
    let { buildDotNetFieldUtilsGenerated } = await import('./fieldUtils.gb');
    return await buildDotNetFieldUtilsGenerated(jsObject);
}
