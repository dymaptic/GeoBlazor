// override generated code in this file
import PreviewSymbol2DGenerated from './previewSymbol2D.gb';
import previewSymbol2D = __esri.previewSymbol2D;

export default class PreviewSymbol2DWrapper extends PreviewSymbol2DGenerated {

    constructor(component: previewSymbol2D) {
        super(component);
    }
    
}

export async function buildJsPreviewSymbol2D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPreviewSymbol2DGenerated } = await import('./previewSymbol2D.gb');
    return await buildJsPreviewSymbol2DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPreviewSymbol2D(jsObject: any): Promise<any> {
    let { buildDotNetPreviewSymbol2DGenerated } = await import('./previewSymbol2D.gb');
    return await buildDotNetPreviewSymbol2DGenerated(jsObject);
}
