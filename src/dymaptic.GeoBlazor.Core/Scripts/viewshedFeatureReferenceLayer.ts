// override generated code in this file
import ViewshedFeatureReferenceLayerGenerated from './viewshedFeatureReferenceLayer.gb';
import ViewshedFeatureReferenceLayer = __esri.ViewshedFeatureReferenceLayer;

export default class ViewshedFeatureReferenceLayerWrapper extends ViewshedFeatureReferenceLayerGenerated {

    constructor(layer: ViewshedFeatureReferenceLayer) {
        super(layer);
    }
    
}

export async function buildJsViewshedFeatureReferenceLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewshedFeatureReferenceLayerGenerated } = await import('./viewshedFeatureReferenceLayer.gb');
    return await buildJsViewshedFeatureReferenceLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewshedFeatureReferenceLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetViewshedFeatureReferenceLayerGenerated } = await import('./viewshedFeatureReferenceLayer.gb');
    return await buildDotNetViewshedFeatureReferenceLayerGenerated(jsObject, viewId);
}
