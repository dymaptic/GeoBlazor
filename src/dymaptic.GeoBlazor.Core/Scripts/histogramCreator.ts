// override generated code in this file
import HistogramCreatorGenerated from './histogramCreator.gb';
import histogram from '@arcgis/core/smartMapping/statistics/histogram';

export default class HistogramCreatorWrapper extends HistogramCreatorGenerated {

    constructor(component: histogram) {
        super(component);
    }
    
}

export async function buildJsHistogramCreator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramCreatorGenerated } = await import('./histogramCreator.gb');
    return await buildJsHistogramCreatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramCreator(jsObject: any): Promise<any> {
    let { buildDotNetHistogramCreatorGenerated } = await import('./histogramCreator.gb');
    return await buildDotNetHistogramCreatorGenerated(jsObject);
}
