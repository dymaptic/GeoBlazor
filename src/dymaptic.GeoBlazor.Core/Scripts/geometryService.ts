// override generated code in this file
import GeometryServiceGenerated from './geometryService.gb';
import geometryService = __esri.geometryService;

export default class GeometryServiceWrapper extends GeometryServiceGenerated {

    constructor(component: geometryService) {
        super(component);
    }

}

export async function buildJsGeometryService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeometryServiceGenerated} = await import('./geometryService.gb');
    return await buildJsGeometryServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeometryService(jsObject: any): Promise<any> {
    let {buildDotNetGeometryServiceGenerated} = await import('./geometryService.gb');
    return await buildDotNetGeometryServiceGenerated(jsObject);
}
