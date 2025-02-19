// override generated code in this file
import DirectionLineGenerated from './directionLine.gb';
import DirectionLine from '@arcgis/core/rest/support/DirectionLine';

export default class DirectionLineWrapper extends DirectionLineGenerated {

    constructor(component: DirectionLine) {
        super(component);
    }
    
}

export async function buildJsDirectionLine(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionLineGenerated } = await import('./directionLine.gb');
    return await buildJsDirectionLineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionLine(jsObject: any): Promise<any> {
    let { buildDotNetDirectionLineGenerated } = await import('./directionLine.gb');
    return await buildDotNetDirectionLineGenerated(jsObject);
}
