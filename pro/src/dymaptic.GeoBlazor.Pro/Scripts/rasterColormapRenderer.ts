// override generated code in this file
import RasterColormapRendererGenerated from './rasterColormapRenderer.gb';
import RasterColormapRenderer from '@arcgis/core/renderers/RasterColormapRenderer';

export default class RasterColormapRendererWrapper extends RasterColormapRendererGenerated {

    constructor(component: RasterColormapRenderer) {
        super(component);
    }
    
}

export async function buildJsRasterColormapRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterColormapRendererGenerated } = await import('./rasterColormapRenderer.gb');
    return await buildJsRasterColormapRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterColormapRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterColormapRendererGenerated } = await import('./rasterColormapRenderer.gb');
    return await buildDotNetRasterColormapRendererGenerated(jsObject, layerId, viewId);
}
