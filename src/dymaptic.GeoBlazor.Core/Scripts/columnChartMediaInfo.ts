// override generated code in this file
import ColumnChartMediaInfoGenerated from './columnChartMediaInfo.gb';
import ColumnChartMediaInfo from '@arcgis/core/popup/content/ColumnChartMediaInfo';

export default class ColumnChartMediaInfoWrapper extends ColumnChartMediaInfoGenerated {

    constructor(component: ColumnChartMediaInfo) {
        super(component);
    }
    
}

export async function buildJsColumnChartMediaInfo(dotNetObject: any): Promise<any> {
    let { buildJsColumnChartMediaInfoGenerated } = await import('./columnChartMediaInfo.gb');
    return await buildJsColumnChartMediaInfoGenerated(dotNetObject);
}     

export async function buildDotNetColumnChartMediaInfo(jsObject: any): Promise<any> {
    let { buildDotNetColumnChartMediaInfoGenerated } = await import('./columnChartMediaInfo.gb');
    return await buildDotNetColumnChartMediaInfoGenerated(jsObject);
}
