import symbologyHeatmap = __esri.symbologyHeatmap;
import SymbologyHeatmapGenerated from './symbologyHeatmap.gb';

export default class SymbologyHeatmapWrapper extends SymbologyHeatmapGenerated {

    constructor(component: symbologyHeatmap) {
        super(component);
    }

}

export async function buildJsSymbologyHeatmap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbologyHeatmapGenerated} = await import('./symbologyHeatmap.gb');
    return await buildJsSymbologyHeatmapGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbologyHeatmap(jsObject: any): Promise<any> {
    let {buildDotNetSymbologyHeatmapGenerated} = await import('./symbologyHeatmap.gb');
    return await buildDotNetSymbologyHeatmapGenerated(jsObject);
}
