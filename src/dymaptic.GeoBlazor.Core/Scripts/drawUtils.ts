// override generated code in this file
import DrawUtilsGenerated from './drawUtils.gb';
import drawUtils = __esri.drawUtils;

export default class DrawUtilsWrapper extends DrawUtilsGenerated {

    constructor(component: drawUtils) {
        super(component);
    }
    
}

export async function buildJsDrawUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDrawUtilsGenerated } = await import('./drawUtils.gb');
    return await buildJsDrawUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDrawUtils(jsObject: any): Promise<any> {
    let { buildDotNetDrawUtilsGenerated } = await import('./drawUtils.gb');
    return await buildDotNetDrawUtilsGenerated(jsObject);
}
