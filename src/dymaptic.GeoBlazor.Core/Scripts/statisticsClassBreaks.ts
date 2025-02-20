import statisticsClassBreaks from '@arcgis/core/smartMapping/statistics/classBreaks';
import StatisticsClassBreaksGenerated from './statisticsClassBreaks.gb';

export default class StatisticsClassBreaksWrapper extends StatisticsClassBreaksGenerated {

    constructor(component: statisticsClassBreaks) {
        super(component);
    }

}

export async function buildJsStatisticsClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsStatisticsClassBreaksGenerated} = await import('./statisticsClassBreaks.gb');
    return await buildJsStatisticsClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetStatisticsClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetStatisticsClassBreaksGenerated} = await import('./statisticsClassBreaks.gb');
    return await buildDotNetStatisticsClassBreaksGenerated(jsObject);
}
