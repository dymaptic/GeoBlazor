// override generated code in this file
import ChartMediaInfoValueGenerated from './chartMediaInfoValue.gb';
import ChartMediaInfoValue from '@arcgis/core/popup/content/support/ChartMediaInfoValue';

export default class ChartMediaInfoValueWrapper extends ChartMediaInfoValueGenerated {

    constructor(component: ChartMediaInfoValue) {
        super(component);
    }
    
}              
export async function buildJsChartMediaInfoValue(dotNetObject: any): Promise<any> {
    let { buildJsChartMediaInfoValueGenerated } = await import('./chartMediaInfoValue.gb');
    return await buildJsChartMediaInfoValueGenerated(dotNetObject);
}
export async function buildDotNetChartMediaInfoValue(jsObject: any): Promise<any> {
    let { buildDotNetChartMediaInfoValueGenerated } = await import('./chartMediaInfoValue.gb');
    return await buildDotNetChartMediaInfoValueGenerated(jsObject);
}
