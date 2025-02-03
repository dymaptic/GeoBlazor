// override generated code in this file
import SimpleRendererGenerated from './simpleRenderer.gb';
import SimpleRenderer from '@arcgis/core/renderers/SimpleRenderer';

export default class SimpleRendererWrapper extends SimpleRendererGenerated {

    constructor(component: SimpleRenderer) {
        super(component);
    }
    
}

export async function buildJsSimpleRenderer(dotNetObject: any): Promise<any> {
    let { buildJsSimpleRendererGenerated } = await import('./simpleRenderer.gb');
    return await buildJsSimpleRendererGenerated(dotNetObject);
}     

export async function buildDotNetSimpleRenderer(jsObject: any): Promise<any> {
    let { buildDotNetSimpleRendererGenerated } = await import('./simpleRenderer.gb');
    return await buildDotNetSimpleRendererGenerated(jsObject);
}
