// override generated code in this file
import ChartMediaInfoValueSeriesGenerated from './chartMediaInfoValueSeries.gb';
import ChartMediaInfoValueSeries from '@arcgis/core/popup/content/support/ChartMediaInfoValueSeries';

export default class ChartMediaInfoValueSeriesWrapper extends ChartMediaInfoValueSeriesGenerated {

    constructor(component: ChartMediaInfoValueSeries) {
        super(component);
    }
    
}              
export async function buildJsChartMediaInfoValueSeries(dotNetObject: any): Promise<any> {
    let { buildJsChartMediaInfoValueSeriesGenerated } = await import('./chartMediaInfoValueSeries.gb');
    return await buildJsChartMediaInfoValueSeriesGenerated(dotNetObject);
}
export async function buildDotNetChartMediaInfoValueSeries(jsObject: any): Promise<any> {
    let { buildDotNetChartMediaInfoValueSeriesGenerated } = await import('./chartMediaInfoValueSeries.gb');
    return await buildDotNetChartMediaInfoValueSeriesGenerated(jsObject);
}
