// override generated code in this file
import MediaPopupContentGenerated from './mediaPopupContent.gb';
import MediaContent = __esri.MediaContent;

export default class MediaPopupContentWrapper extends MediaPopupContentGenerated {

    constructor(component: MediaContent) {
        super(component);
    }
    
}

export async function buildJsMediaPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMediaPopupContentGenerated } = await import('./mediaPopupContent.gb');
    return await buildJsMediaPopupContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMediaPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetMediaPopupContentGenerated } = await import('./mediaPopupContent.gb');
    return await buildDotNetMediaPopupContentGenerated(jsObject);
}
