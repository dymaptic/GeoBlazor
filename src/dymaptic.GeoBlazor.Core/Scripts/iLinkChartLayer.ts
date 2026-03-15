// override generated code in this file
import ILinkChartLayerGenerated from './iLinkChartLayer.gb';
import LinkChartLayer from '@arcgis/core/layers/LinkChartLayer';

export default class ILinkChartLayerWrapper extends ILinkChartLayerGenerated {

    constructor(layer: LinkChartLayer) {
        super(layer);
    }
    
}

export async function buildJsILinkChartLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsILinkChartLayerGenerated } = await import('./iLinkChartLayer.gb');
    return await buildJsILinkChartLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetILinkChartLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetILinkChartLayerGenerated } = await import('./iLinkChartLayer.gb');
    return await buildDotNetILinkChartLayerGenerated(jsObject, viewId);
}
