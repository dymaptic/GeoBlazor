// override generated code in this file
import DeleteItemsResultGenerated from './deleteItemsResult.gb';
import DeleteItemsResult = __esri.DeleteItemsResult;

export default class DeleteItemsResultWrapper extends DeleteItemsResultGenerated {

    constructor(component: DeleteItemsResult) {
        super(component);
    }
    
}

export async function buildJsDeleteItemsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDeleteItemsResultGenerated } = await import('./deleteItemsResult.gb');
    return await buildJsDeleteItemsResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDeleteItemsResult(jsObject: any): Promise<any> {
    let { buildDotNetDeleteItemsResultGenerated } = await import('./deleteItemsResult.gb');
    return await buildDotNetDeleteItemsResultGenerated(jsObject);
}
