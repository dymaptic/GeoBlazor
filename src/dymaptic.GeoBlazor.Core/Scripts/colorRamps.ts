// override generated code in this file
import ColorRampsGenerated from './colorRamps.gb';
import colorRamps = __esri.colorRamps;

export default class ColorRampsWrapper extends ColorRampsGenerated {

    constructor(component: colorRamps) {
        super(component);
    }

}

export async function buildJsColorRamps(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorRampsGenerated} = await import('./colorRamps.gb');
    return await buildJsColorRampsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorRamps(jsObject: any): Promise<any> {
    let {buildDotNetColorRampsGenerated} = await import('./colorRamps.gb');
    return await buildDotNetColorRampsGenerated(jsObject);
}
