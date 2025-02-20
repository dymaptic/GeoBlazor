import DictionaryRenderer from '@arcgis/core/renderers/DictionaryRenderer';
import DictionaryRendererGenerated from './dictionaryRenderer.gb';

export default class DictionaryRendererWrapper extends DictionaryRendererGenerated {

    constructor(component: DictionaryRenderer) {
        super(component);
    }

}

export async function buildJsDictionaryRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDictionaryRendererGenerated} = await import('./dictionaryRenderer.gb');
    return await buildJsDictionaryRendererGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDictionaryRenderer(jsObject: any): Promise<any> {
    let {buildDotNetDictionaryRendererGenerated} = await import('./dictionaryRenderer.gb');
    return await buildDotNetDictionaryRendererGenerated(jsObject);
}
