// override generated code in this file
import CSVLayerElevationInfoFeatureExpressionInfoGenerated from './cSVLayerElevationInfoFeatureExpressionInfo.gb';
import CSVLayerElevationInfoFeatureExpressionInfo = __esri.CSVLayerElevationInfoFeatureExpressionInfo;

export default class CSVLayerElevationInfoFeatureExpressionInfoWrapper extends CSVLayerElevationInfoFeatureExpressionInfoGenerated {

    constructor(component: CSVLayerElevationInfoFeatureExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsCSVLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsCSVLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCSVLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./cSVLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetCSVLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
