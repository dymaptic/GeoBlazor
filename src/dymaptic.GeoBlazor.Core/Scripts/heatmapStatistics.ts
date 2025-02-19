// override generated code in this file
import HeatmapStatisticsGenerated from './heatmapStatistics.gb';
import heatmapStatistics from '@arcgis/core/smartMapping/statistics/heatmapStatistics';

export default class HeatmapStatisticsWrapper extends HeatmapStatisticsGenerated {

    constructor(component: heatmapStatistics) {
        super(component);
    }
    
}

export async function buildJsHeatmapStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHeatmapStatisticsGenerated } = await import('./heatmapStatistics.gb');
    return await buildJsHeatmapStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHeatmapStatistics(jsObject: any): Promise<any> {
    let { buildDotNetHeatmapStatisticsGenerated } = await import('./heatmapStatistics.gb');
    return await buildDotNetHeatmapStatisticsGenerated(jsObject);
}
