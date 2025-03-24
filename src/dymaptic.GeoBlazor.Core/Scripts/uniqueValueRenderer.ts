// override generated code in this file
import UniqueValueRendererGenerated from './uniqueValueRenderer.gb';
import UniqueValueRenderer from '@arcgis/core/renderers/UniqueValueRenderer';

export default class UniqueValueRendererWrapper extends UniqueValueRendererGenerated {

    constructor(component: UniqueValueRenderer) {
        super(component);
    }

}

export async function buildJsUniqueValueRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUniqueValueRendererGenerated} = await import('./uniqueValueRenderer.gb');
    return await buildJsUniqueValueRendererGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUniqueValueRenderer(jsObject: any): Promise<any> {
    let {buildDotNetUniqueValueRendererGenerated} = await import('./uniqueValueRenderer.gb');
    return await buildDotNetUniqueValueRendererGenerated(jsObject);
}
