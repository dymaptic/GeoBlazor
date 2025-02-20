// override generated code in this file
import SymbolServiceGenerated from './symbolService.gb';
import symbolService = __esri.symbolService;

export default class SymbolServiceWrapper extends SymbolServiceGenerated {

    constructor(component: symbolService) {
        super(component);
    }

}

export async function buildJsSymbolService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolServiceGenerated} = await import('./symbolService.gb');
    return await buildJsSymbolServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolService(jsObject: any): Promise<any> {
    let {buildDotNetSymbolServiceGenerated} = await import('./symbolService.gb');
    return await buildDotNetSymbolServiceGenerated(jsObject);
}
