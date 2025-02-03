// override generated code in this file
import GraphicsLayerElevationInfoGenerated from './graphicsLayerElevationInfo.gb';
import GraphicsLayerElevationInfo = __esri.GraphicsLayerElevationInfo;

export default class GraphicsLayerElevationInfoWrapper extends GraphicsLayerElevationInfoGenerated {

    constructor(component: GraphicsLayerElevationInfo) {
        super(component);
    }
    
}              
export async function buildJsGraphicsLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildJsGraphicsLayerElevationInfoGenerated(dotNetObject);
}
export async function buildDotNetGraphicsLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetGraphicsLayerElevationInfoGenerated } = await import('./graphicsLayerElevationInfo.gb');
    return await buildDotNetGraphicsLayerElevationInfoGenerated(jsObject);
}
