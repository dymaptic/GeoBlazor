// override generated code in this file
import SummaryStatisticsGenerated from './summaryStatistics.gb';
import summaryStatistics from '@arcgis/core/smartMapping/statistics/summaryStatistics';

export default class SummaryStatisticsWrapper extends SummaryStatisticsGenerated {

    constructor(component: summaryStatistics) {
        super(component);
    }
    
}

export async function buildJsSummaryStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSummaryStatisticsGenerated } = await import('./summaryStatistics.gb');
    return await buildJsSummaryStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSummaryStatistics(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSummaryStatisticsGenerated } = await import('./summaryStatistics.gb');
    return await buildDotNetSummaryStatisticsGenerated(jsObject, layerId, viewId);
}
