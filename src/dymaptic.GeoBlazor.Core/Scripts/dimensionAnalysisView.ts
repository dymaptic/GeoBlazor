// override generated code in this file
import DimensionAnalysisViewGenerated from './dimensionAnalysisView.gb';
import DimensionAnalysisView from '@arcgis/core/views/analysis/DimensionAnalysisView';

export default class DimensionAnalysisViewWrapper extends DimensionAnalysisViewGenerated {

    constructor(component: DimensionAnalysisView) {
        super(component);
    }
    
}

export async function buildJsDimensionAnalysisView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDimensionAnalysisViewGenerated } = await import('./dimensionAnalysisView.gb');
    return await buildJsDimensionAnalysisViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDimensionAnalysisView(jsObject: any): Promise<any> {
    let { buildDotNetDimensionAnalysisViewGenerated } = await import('./dimensionAnalysisView.gb');
    return await buildDotNetDimensionAnalysisViewGenerated(jsObject);
}
