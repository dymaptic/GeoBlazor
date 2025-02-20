import symbologyPieChart = __esri.symbologyPieChart;
import SymbologyPieChartGenerated from './symbologyPieChart.gb';

export default class SymbologyPieChartWrapper extends SymbologyPieChartGenerated {

    constructor(component: symbologyPieChart) {
        super(component);
    }

}

export async function buildJsSymbologyPieChart(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbologyPieChartGenerated} = await import('./symbologyPieChart.gb');
    return await buildJsSymbologyPieChartGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbologyPieChart(jsObject: any): Promise<any> {
    let {buildDotNetSymbologyPieChartGenerated} = await import('./symbologyPieChart.gb');
    return await buildDotNetSymbologyPieChartGenerated(jsObject);
}
