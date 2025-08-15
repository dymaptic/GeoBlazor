import BuildingSummaryStatistics from "@arcgis/core/layers/support/BuildingSummaryStatistics";
import BuildingSummaryStatisticsGenerated from './buildingSummaryStatistics.gb';

export async function buildJsBuildingSummaryStatistics(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildJsBuildingSummaryStatisticsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBuildingSummaryStatistics(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingSummaryStatisticsGenerated } = await import('./buildingSummaryStatistics.gb');
    return await buildDotNetBuildingSummaryStatisticsGenerated(jsObject, viewId);
}

export default class BuildingSummaryStatisticsWrapper extends BuildingSummaryStatisticsGenerated {

    constructor(component: BuildingSummaryStatistics) {
        super(component);
    }
    
}

