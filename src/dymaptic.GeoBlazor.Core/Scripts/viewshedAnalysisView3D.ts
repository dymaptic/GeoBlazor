import ViewshedAnalysisView3D from '@arcgis/core/views/3d/analysis/ViewshedAnalysisView3D';
import ViewshedAnalysisView3DGenerated from './viewshedAnalysisView3D.gb';

export default class ViewshedAnalysisView3DWrapper extends ViewshedAnalysisView3DGenerated {

    constructor(component: ViewshedAnalysisView3D) {
        super(component);
    }
    
}

export async function buildJsViewshedAnalysisView3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewshedAnalysisView3DGenerated } = await import('./viewshedAnalysisView3D.gb');
    return await buildJsViewshedAnalysisView3DGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetViewshedAnalysisView3D(jsObject: any): Promise<any> {
    let { buildDotNetViewshedAnalysisView3DGenerated } = await import('./viewshedAnalysisView3D.gb');
    return await buildDotNetViewshedAnalysisView3DGenerated(jsObject);
}
