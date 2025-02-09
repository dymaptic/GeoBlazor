// override generated code in this file
import PieChartMediaInfoGenerated from './pieChartMediaInfo.gb';
import PieChartMediaInfo from '@arcgis/core/popup/content/PieChartMediaInfo';

export default class PieChartMediaInfoWrapper extends PieChartMediaInfoGenerated {

    constructor(component: PieChartMediaInfo) {
        super(component);
    }
    
}

export async function buildJsPieChartMediaInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartMediaInfoGenerated } = await import('./pieChartMediaInfo.gb');
    return await buildJsPieChartMediaInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartMediaInfo(jsObject: any): Promise<any> {
    let { buildDotNetPieChartMediaInfoGenerated } = await import('./pieChartMediaInfo.gb');
    return await buildDotNetPieChartMediaInfoGenerated(jsObject);
}
