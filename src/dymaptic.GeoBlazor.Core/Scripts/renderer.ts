// override generated code in this file
import RendererGenerated from './renderer.gb';
import Renderer from '@arcgis/core/renderers/Renderer';

export default class RendererWrapper extends RendererGenerated {

    constructor(component: Renderer) {
        super(component);
    }
    
}

export async function buildJsRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRendererGenerated } = await import('./renderer.gb');
    return await buildJsRendererGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRenderer(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'simple':
            let { buildDotNetSimpleRenderer } = await import('./simpleRenderer');
            return await buildDotNetSimpleRenderer(jsObject);
        case 'unique-value':
            let { buildDotNetUniqueValueRenderer } = await import('./uniqueValueRenderer');
            return await buildDotNetUniqueValueRenderer(jsObject);
        case 'pie-chart': // only available in Pro
            // @ts-ignore
            let { buildDotNetPieChartRenderer } = await import('./pieChartRenderer');
            return await buildDotNetPieChartRenderer(jsObject);
        default:
            throw new Error('Unknown renderer type');
    }
}
