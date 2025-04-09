// override generated code in this file
import WebLinkChartGenerated from './webLinkChart.gb';
import WebLinkChart from '@arcgis/core/WebLinkChart';

export default class WebLinkChartWrapper extends WebLinkChartGenerated {

    constructor(component: WebLinkChart) {
        super(component);
    }
    
}

export async function buildJsWebLinkChart(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebLinkChartGenerated } = await import('./webLinkChart.gb');
    return await buildJsWebLinkChartGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebLinkChart(jsObject: any): Promise<any> {
    let { buildDotNetWebLinkChartGenerated } = await import('./webLinkChart.gb');
    return await buildDotNetWebLinkChartGenerated(jsObject);
}
