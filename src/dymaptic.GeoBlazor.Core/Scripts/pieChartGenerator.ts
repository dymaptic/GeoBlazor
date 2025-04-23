// override generated code in this file
import PieChartGeneratorGenerated from './pieChartGenerator.gb';
import pieChart = __esri.pieChart;

export default class PieChartGeneratorWrapper extends PieChartGeneratorGenerated {

    constructor(component: pieChart) {
        super(component);
    }
    
}

export async function buildJsPieChartGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartGeneratorGenerated } = await import('./pieChartGenerator.gb');
    return await buildJsPieChartGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartGenerator(jsObject: any): Promise<any> {
    let { buildDotNetPieChartGeneratorGenerated } = await import('./pieChartGenerator.gb');
    return await buildDotNetPieChartGeneratorGenerated(jsObject);
}
