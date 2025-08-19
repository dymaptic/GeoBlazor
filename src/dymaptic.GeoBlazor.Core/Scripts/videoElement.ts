// override generated code in this file
import VideoElementGenerated from './videoElement.gb';
import VideoElement from '@arcgis/core/layers/support/VideoElement';

export default class VideoElementWrapper extends VideoElementGenerated {

    constructor(component: VideoElement) {
        super(component);
    }
    
}

export async function buildJsVideoElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoElementGenerated } = await import('./videoElement.gb');
    return await buildJsVideoElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVideoElementGenerated } = await import('./videoElement.gb');
    return await buildDotNetVideoElementGenerated(jsObject, viewId);
}
