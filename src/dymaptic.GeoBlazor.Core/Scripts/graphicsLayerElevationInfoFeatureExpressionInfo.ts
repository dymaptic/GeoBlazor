// override generated code in this file
import GraphicsLayerElevationInfoFeatureExpressionInfoGenerated from './graphicsLayerElevationInfoFeatureExpressionInfo.gb';
import GraphicsLayerElevationInfoFeatureExpressionInfo = __esri.GraphicsLayerElevationInfoFeatureExpressionInfo;

export default class GraphicsLayerElevationInfoFeatureExpressionInfoWrapper extends GraphicsLayerElevationInfoFeatureExpressionInfoGenerated {

    constructor(component: GraphicsLayerElevationInfoFeatureExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject);
}
export async function buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
