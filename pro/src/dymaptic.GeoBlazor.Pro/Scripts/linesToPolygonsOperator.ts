// override generated code in this file
import LinesToPolygonsOperatorGenerated from './linesToPolygonsOperator.gb';
import linesToPolygonsOperator = __esri.linesToPolygonsOperator;

export default class LinesToPolygonsOperatorWrapper extends LinesToPolygonsOperatorGenerated {

    constructor(component: linesToPolygonsOperator) {
        super(component);
    }
    
}

export async function buildJsLinesToPolygonsOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinesToPolygonsOperatorGenerated } = await import('./linesToPolygonsOperator.gb');
    return await buildJsLinesToPolygonsOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinesToPolygonsOperator(jsObject: any): Promise<any> {
    let { buildDotNetLinesToPolygonsOperatorGenerated } = await import('./linesToPolygonsOperator.gb');
    return await buildDotNetLinesToPolygonsOperatorGenerated(jsObject);
}
