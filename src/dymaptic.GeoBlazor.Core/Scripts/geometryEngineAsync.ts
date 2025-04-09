// override generated code in this file
import GeometryEngineAsyncGenerated from './geometryEngineAsync.gb';
import geometryEngineAsync = __esri.geometryEngineAsync;

export default class GeometryEngineAsyncWrapper extends GeometryEngineAsyncGenerated {

    constructor(component: geometryEngineAsync) {
        super(component);
    }
    
}

export async function buildJsGeometryEngineAsync(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeometryEngineAsyncGenerated } = await import('./geometryEngineAsync.gb');
    return await buildJsGeometryEngineAsyncGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeometryEngineAsync(jsObject: any): Promise<any> {
    let { buildDotNetGeometryEngineAsyncGenerated } = await import('./geometryEngineAsync.gb');
    return await buildDotNetGeometryEngineAsyncGenerated(jsObject);
}
