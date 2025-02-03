// override generated code in this file
import FeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated from './featureLayerBaseElevationInfoFeatureExpressionInfo.gb';
import FeatureLayerBaseElevationInfoFeatureExpressionInfo = __esri.FeatureLayerBaseElevationInfoFeatureExpressionInfo;

export default class FeatureLayerBaseElevationInfoFeatureExpressionInfoWrapper extends FeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated {

    constructor(component: FeatureLayerBaseElevationInfoFeatureExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildJsFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}
export async function buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated } = await import('./featureLayerBaseElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetFeatureLayerBaseElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
