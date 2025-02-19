// override generated code in this file
import DrawGenerated from './draw.gb';
import Draw from '@arcgis/core/views/draw/Draw';

export default class DrawWrapper extends DrawGenerated {

    constructor(component: Draw) {
        super(component);
    }
    
}

export async function buildJsDraw(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDrawGenerated } = await import('./draw.gb');
    return await buildJsDrawGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDraw(jsObject: any): Promise<any> {
    let { buildDotNetDrawGenerated } = await import('./draw.gb');
    return await buildDotNetDrawGenerated(jsObject);
}
