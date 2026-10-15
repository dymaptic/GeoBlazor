// override generated code in this file
import DotDensityRendererGenerated from './dotDensityRenderer.gb';
import DotDensityRenderer from '@arcgis/core/renderers/DotDensityRenderer';

export default class DotDensityRendererWrapper extends DotDensityRendererGenerated {

    constructor(component: DotDensityRenderer) {
        super(component);
    }
    
}

export async function buildJsDotDensityRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityRendererGenerated } = await import('./dotDensityRenderer.gb');
    return await buildJsDotDensityRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityRenderer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDotDensityRendererGenerated } = await import('./dotDensityRenderer.gb');
    return await buildDotNetDotDensityRendererGenerated(jsObject, layerId, viewId);
}
