// override generated code in this file
import CSVLayerViewGenerated from './cSVLayerView.gb';
import CSVLayerView from '@arcgis/core/views/layers/CSVLayerView';

export default class CSVLayerViewWrapper extends CSVLayerViewGenerated {

    constructor(component: CSVLayerView) {
        super(component);
    }
    
}

export async function buildJsCSVLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerViewGenerated } = await import('./cSVLayerView.gb');
    return await buildJsCSVLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerView(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerViewGenerated } = await import('./cSVLayerView.gb');
    return await buildDotNetCSVLayerViewGenerated(jsObject);
}
