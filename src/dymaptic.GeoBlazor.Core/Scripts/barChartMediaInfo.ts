// override generated code in this file
import BarChartMediaInfoGenerated from './barChartMediaInfo.gb';
import BarChartMediaInfo from '@arcgis/core/popup/content/BarChartMediaInfo';

export default class BarChartMediaInfoWrapper extends BarChartMediaInfoGenerated {

    constructor(component: BarChartMediaInfo) {
        super(component);
    }
    
}

export async function buildJsBarChartMediaInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBarChartMediaInfoGenerated } = await import('./barChartMediaInfo.gb');
    return await buildJsBarChartMediaInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBarChartMediaInfo(jsObject: any): Promise<any> {
    let { buildDotNetBarChartMediaInfoGenerated } = await import('./barChartMediaInfo.gb');
    return await buildDotNetBarChartMediaInfoGenerated(jsObject);
}
