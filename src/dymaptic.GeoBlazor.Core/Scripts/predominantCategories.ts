// override generated code in this file
import PredominantCategoriesGenerated from './predominantCategories.gb';
import predominantCategories from '@arcgis/core/smartMapping/statistics/predominantCategories';

export default class PredominantCategoriesWrapper extends PredominantCategoriesGenerated {

    constructor(component: predominantCategories) {
        super(component);
    }
    
}

export async function buildJsPredominantCategories(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominantCategoriesGenerated } = await import('./predominantCategories.gb');
    return await buildJsPredominantCategoriesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominantCategories(jsObject: any): Promise<any> {
    let { buildDotNetPredominantCategoriesGenerated } = await import('./predominantCategories.gb');
    return await buildDotNetPredominantCategoriesGenerated(jsObject);
}
