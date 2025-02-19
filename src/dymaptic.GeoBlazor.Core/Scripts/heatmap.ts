// override generated code in this file
import HeatmapGenerated from './heatmap.gb';
import heatmap = __esri.heatmap;

export default class HeatmapWrapper extends HeatmapGenerated {

    constructor(component: heatmap) {
        super(component);
    }
    
}

export async function buildJsHeatmap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapGenerated } = await import('./heatmap.gb');
    return await buildJsHeatmapGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmap(jsObject: any): Promise<any> {
    let { buildDotNetHeatmapGenerated } = await import('./heatmap.gb');
    return await buildDotNetHeatmapGenerated(jsObject);
}
