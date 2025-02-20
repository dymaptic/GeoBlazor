// override generated code in this file
import IArcGISImageServiceGenerated from './iArcGISImageService.gb';
import ArcGISImageService = __esri.ArcGISImageService;

export default class IArcGISImageServiceWrapper extends IArcGISImageServiceGenerated {

    constructor(component: ArcGISImageService) {
        super(component);
    }

}

export async function buildJsIArcGISImageService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIArcGISImageServiceGenerated} = await import('./iArcGISImageService.gb');
    return await buildJsIArcGISImageServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIArcGISImageService(jsObject: any): Promise<any> {
    let {buildDotNetIArcGISImageServiceGenerated} = await import('./iArcGISImageService.gb');
    return await buildDotNetIArcGISImageServiceGenerated(jsObject);
}
