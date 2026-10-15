// override generated code in this file
import HeatmapRendererGeneratorGenerated from './heatmapRendererGenerator.gb';
import heatmap = __esri.heatmap;

export default class HeatmapRendererGeneratorWrapper extends HeatmapRendererGeneratorGenerated {

    constructor(component: heatmap) {
        super(component);
    }
    
}

export async function buildJsHeatmapRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapRendererGeneratorGenerated } = await import('./heatmapRendererGenerator.gb');
    return await buildJsHeatmapRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHeatmapRendererGeneratorGenerated } = await import('./heatmapRendererGenerator.gb');
    return await buildDotNetHeatmapRendererGeneratorGenerated(jsObject, layerId, viewId);
}
