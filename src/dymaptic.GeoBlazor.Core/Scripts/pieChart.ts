// override generated code in this file
import PieChartGenerated from './pieChart.gb';
import pieChart = __esri.pieChart;

export default class PieChartWrapper extends PieChartGenerated {

    constructor(component: pieChart) {
        super(component);
    }
    
}

export async function buildJsPieChart(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartGenerated } = await import('./pieChart.gb');
    return await buildJsPieChartGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChart(jsObject: any): Promise<any> {
    let { buildDotNetPieChartGenerated } = await import('./pieChart.gb');
    return await buildDotNetPieChartGenerated(jsObject);
}
