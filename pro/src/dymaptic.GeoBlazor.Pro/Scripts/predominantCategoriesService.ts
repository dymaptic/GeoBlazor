// override generated code in this file
import PredominantCategoriesServiceGenerated from './predominantCategoriesService.gb';
import predominantCategories from '@arcgis/core/smartMapping/statistics/predominantCategories';

export default class PredominantCategoriesServiceWrapper extends PredominantCategoriesServiceGenerated {

    constructor(component: predominantCategories) {
        super(component);
    }
    
}

export async function buildJsPredominantCategoriesService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominantCategoriesServiceGenerated } = await import('./predominantCategoriesService.gb');
    return await buildJsPredominantCategoriesServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominantCategoriesService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPredominantCategoriesServiceGenerated } = await import('./predominantCategoriesService.gb');
    return await buildDotNetPredominantCategoriesServiceGenerated(jsObject, layerId, viewId);
}
