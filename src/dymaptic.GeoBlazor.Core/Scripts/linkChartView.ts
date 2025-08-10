// override generated code in this file
import LinkChartViewGenerated from './linkChartView.gb';
import LinkChartView from '@arcgis/core/views/LinkChartView';

export async function buildJsLinkChartView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinkChartViewGenerated } = await import('./linkChartView.gb');
    return await buildJsLinkChartViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinkChartView(jsObject: any): Promise<any> {
    let { buildDotNetLinkChartViewGenerated } = await import('./linkChartView.gb');
    return await buildDotNetLinkChartViewGenerated(jsObject);
}

export default class LinkChartViewWrapper extends LinkChartViewGenerated {

    constructor(component: LinkChartView) {
        super(component);
    }
    
}

