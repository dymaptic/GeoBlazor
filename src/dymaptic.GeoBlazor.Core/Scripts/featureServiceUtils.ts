// override generated code in this file
import FeatureServiceUtilsGenerated from './featureServiceUtils.gb';
import featureServiceUtils = __esri.featureServiceUtils;

export default class FeatureServiceUtilsWrapper extends FeatureServiceUtilsGenerated {

    constructor(component: featureServiceUtils) {
        super(component);
    }

}

export async function buildJsFeatureServiceUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureServiceUtilsGenerated} = await import('./featureServiceUtils.gb');
    return await buildJsFeatureServiceUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureServiceUtils(jsObject: any): Promise<any> {
    let {buildDotNetFeatureServiceUtilsGenerated} = await import('./featureServiceUtils.gb');
    return await buildDotNetFeatureServiceUtilsGenerated(jsObject);
}
