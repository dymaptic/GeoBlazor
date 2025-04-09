// override generated code in this file
import EsriTimeExtentGenerated from './esriTimeExtent.gb';
import esriTimeExtent from '@arcgis/core/TimeExtent';

export default class EsriTimeExtentWrapper extends EsriTimeExtentGenerated {

    constructor(component: esriTimeExtent) {
        super(component);
    }
    
}

export async function buildJsEsriTimeExtent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEsriTimeExtentGenerated } = await import('./esriTimeExtent.gb');
    return await buildJsEsriTimeExtentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEsriTimeExtent(jsObject: any): Promise<any> {
    let { buildDotNetEsriTimeExtentGenerated } = await import('./esriTimeExtent.gb');
    return await buildDotNetEsriTimeExtentGenerated(jsObject);
}
