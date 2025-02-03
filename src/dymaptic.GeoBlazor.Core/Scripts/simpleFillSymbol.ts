// override generated code in this file
import SimpleFillSymbolGenerated from './simpleFillSymbol.gb';
import SimpleFillSymbol from '@arcgis/core/symbols/SimpleFillSymbol';

export default class SimpleFillSymbolWrapper extends SimpleFillSymbolGenerated {

    constructor(component: SimpleFillSymbol) {
        super(component);
    }
    
}              
export async function buildJsSimpleFillSymbol(dotNetObject: any): Promise<any> {
    let { buildJsSimpleFillSymbolGenerated } = await import('./simpleFillSymbol.gb');
    return await buildJsSimpleFillSymbolGenerated(dotNetObject);
}
export async function buildDotNetSimpleFillSymbol(jsObject: any): Promise<any> {
    let { buildDotNetSimpleFillSymbolGenerated } = await import('./simpleFillSymbol.gb');
    return await buildDotNetSimpleFillSymbolGenerated(jsObject);
}
