// override generated code in this file
import ColormapGenerated from './colormap.gb';
import colormap = __esri.colormap;

export default class ColormapWrapper extends ColormapGenerated {

    constructor(component: colormap) {
        super(component);
    }

}

export async function buildJsColormap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColormapGenerated} = await import('./colormap.gb');
    return await buildJsColormapGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColormap(jsObject: any): Promise<any> {
    let {buildDotNetColormapGenerated} = await import('./colormap.gb');
    return await buildDotNetColormapGenerated(jsObject);
}
