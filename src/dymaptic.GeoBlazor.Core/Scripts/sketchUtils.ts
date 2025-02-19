// override generated code in this file
import SketchUtilsGenerated from './sketchUtils.gb';
import sketchUtils = __esri.sketchUtils;

export default class SketchUtilsWrapper extends SketchUtilsGenerated {

    constructor(component: sketchUtils) {
        super(component);
    }
    
}

export async function buildJsSketchUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchUtilsGenerated } = await import('./sketchUtils.gb');
    return await buildJsSketchUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSketchUtils(jsObject: any): Promise<any> {
    let { buildDotNetSketchUtilsGenerated } = await import('./sketchUtils.gb');
    return await buildDotNetSketchUtilsGenerated(jsObject);
}
