// override generated code in this file
import PrintServiceGenerated from './printService.gb';
import print = __esri.print;

export default class PrintServiceWrapper extends PrintServiceGenerated {

    constructor(component: print) {
        super(component);
    }
    
}

export async function buildJsPrintService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintServiceGenerated } = await import('./printService.gb');
    return await buildJsPrintServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPrintService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrintServiceGenerated } = await import('./printService.gb');
    return await buildDotNetPrintServiceGenerated(jsObject, layerId, viewId);
}
