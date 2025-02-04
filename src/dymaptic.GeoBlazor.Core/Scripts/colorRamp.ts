// override generated code in this file
import ColorRampGenerated from './colorRamp.gb';
import ColorRamp from '@arcgis/core/rest/support/ColorRamp';

export default class ColorRampWrapper extends ColorRampGenerated {

    constructor(component: ColorRamp) {
        super(component);
    }
    
}

export async function buildJsColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorRampGenerated } = await import('./colorRamp.gb');
    return await buildJsColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorRamp(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColorRampGenerated } = await import('./colorRamp.gb');
    return await buildDotNetColorRampGenerated(jsObject, layerId, viewId);
}
