import LabelGenerated from './label.gb';
import LabelClass from '@arcgis/core/layers/support/LabelClass';
export async function buildJsLabel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLabelGenerated} = await import('./label.gb');
    return await buildJsLabelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLabel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetLabelGenerated} = await import('./label.gb');
    return await buildDotNetLabelGenerated(jsObject, layerId, viewId);
}

export default class LabelWrapper extends LabelGenerated {

    constructor(component: LabelClass) {
        super(component);
    }
    
}

