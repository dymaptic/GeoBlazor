import DynamicDataLayerFieldsGenerated from "./dynamicDataLayerFields.gb";
import DynamicDataLayerFields = __esri.DynamicDataLayerFields;

export default class DynamicDataLayerFieldsWrapper extends DynamicDataLayerFieldsGenerated {
    constructor(component: DynamicDataLayerFields) {
        super(component);
    }
    
}

export async function buildJsDynamicDataLayerFields(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDynamicDataLayerFieldsGenerated } = await import('./dynamicDataLayerFields.gb');
    return await buildJsDynamicDataLayerFieldsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDynamicDataLayerFields(jsObject: any): Promise<any> {
    let { buildDotNetDynamicDataLayerFieldsGenerated } = await import('./dynamicDataLayerFields.gb');
    return await buildDotNetDynamicDataLayerFieldsGenerated(jsObject);
}