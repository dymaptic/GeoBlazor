import summaryStatisticsForAge from '@arcgis/core/smartMapping/statistics/summaryStatisticsForAge';
import SummaryStatisticsForAgeGenerated from './summaryStatisticsForAge.gb';

export default class SummaryStatisticsForAgeWrapper extends SummaryStatisticsForAgeGenerated {

    constructor(component: summaryStatisticsForAge) {
        super(component);
    }
    
}

export async function buildJsSummaryStatisticsForAge(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSummaryStatisticsForAgeGenerated } = await import('./summaryStatisticsForAge.gb');
    return await buildJsSummaryStatisticsForAgeGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSummaryStatisticsForAge(jsObject: any): Promise<any> {
    let { buildDotNetSummaryStatisticsForAgeGenerated } = await import('./summaryStatisticsForAge.gb');
    return await buildDotNetSummaryStatisticsForAgeGenerated(jsObject);
}
