// override generated code in this file
import CategoryTypeGenerated from './categoryType.gb';
import type = __esri.type;

export default class CategoryTypeWrapper extends CategoryTypeGenerated {

    constructor(component: type) {
        super(component);
    }
    
}

export async function buildJsCategoryType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCategoryTypeGenerated } = await import('./categoryType.gb');
    return await buildJsCategoryTypeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCategoryType(jsObject: any): Promise<any> {
    let { buildDotNetCategoryTypeGenerated } = await import('./categoryType.gb');
    return await buildDotNetCategoryTypeGenerated(jsObject);
}
