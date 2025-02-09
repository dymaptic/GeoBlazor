// override generated code in this file
import GraphicsLayerElevationInfoFeatureExpressionInfoGenerated from './graphicsLayerElevationInfoFeatureExpressionInfo.gb';
import GraphicsLayerElevationInfoFeatureExpressionInfo = __esri.GraphicsLayerElevationInfoFeatureExpressionInfo;

export default class GraphicsLayerElevationInfoFeatureExpressionInfoWrapper extends GraphicsLayerElevationInfoFeatureExpressionInfoGenerated {

    constructor(component: GraphicsLayerElevationInfoFeatureExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsGraphicsLayerElevationInfoFeatureExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildJsGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated } = await import('./graphicsLayerElevationInfoFeatureExpressionInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoFeatureExpressionInfoGenerated(jsObject);
}
