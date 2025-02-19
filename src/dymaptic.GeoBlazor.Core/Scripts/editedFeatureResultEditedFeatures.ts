// override generated code in this file
import EditedFeatureResultEditedFeaturesGenerated from './editedFeatureResultEditedFeatures.gb';
import EditedFeatureResultEditedFeatures = __esri.EditedFeatureResultEditedFeatures;

export default class EditedFeatureResultEditedFeaturesWrapper extends EditedFeatureResultEditedFeaturesGenerated {

    constructor(component: EditedFeatureResultEditedFeatures) {
        super(component);
    }
    
}              
export async function buildJsEditedFeatureResultEditedFeatures(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditedFeatureResultEditedFeaturesGenerated } = await import('./editedFeatureResultEditedFeatures.gb');
    return await buildJsEditedFeatureResultEditedFeaturesGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetEditedFeatureResultEditedFeatures(jsObject: any): Promise<any> {
    let { buildDotNetEditedFeatureResultEditedFeaturesGenerated } = await import('./editedFeatureResultEditedFeatures.gb');
    return await buildDotNetEditedFeatureResultEditedFeaturesGenerated(jsObject);
}
