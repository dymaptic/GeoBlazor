// override generated code in this file
import PromiseUtilsGenerated from './promiseUtils.gb';
import promiseUtils = __esri.promiseUtils;

export default class PromiseUtilsWrapper extends PromiseUtilsGenerated {

    constructor(component: promiseUtils) {
        super(component);
    }
    
}

export async function buildJsPromiseUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPromiseUtilsGenerated } = await import('./promiseUtils.gb');
    return await buildJsPromiseUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPromiseUtils(jsObject: any): Promise<any> {
    let { buildDotNetPromiseUtilsGenerated } = await import('./promiseUtils.gb');
    return await buildDotNetPromiseUtilsGenerated(jsObject);
}
