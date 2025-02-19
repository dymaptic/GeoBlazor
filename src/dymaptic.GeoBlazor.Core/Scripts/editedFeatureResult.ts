// override generated code in this file
import EditedFeatureResultGenerated from './editedFeatureResult.gb';
import EditedFeatureResult = __esri.EditedFeatureResult;

export default class EditedFeatureResultWrapper extends EditedFeatureResultGenerated {

    constructor(component: EditedFeatureResult) {
        super(component);
    }
    
}              
export async function buildJsEditedFeatureResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditedFeatureResultGenerated } = await import('./editedFeatureResult.gb');
    return await buildJsEditedFeatureResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetEditedFeatureResult(jsObject: any): Promise<any> {
    let { buildDotNetEditedFeatureResultGenerated } = await import('./editedFeatureResult.gb');
    return await buildDotNetEditedFeatureResultGenerated(jsObject);
}
