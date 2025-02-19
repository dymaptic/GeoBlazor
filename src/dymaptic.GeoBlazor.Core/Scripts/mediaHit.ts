// override generated code in this file
import MediaHitGenerated from './mediaHit.gb';
import MediaHit = __esri.MediaHit;

export default class MediaHitWrapper extends MediaHitGenerated {

    constructor(component: MediaHit) {
        super(component);
    }
    
}

export async function buildJsMediaHit(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMediaHitGenerated } = await import('./mediaHit.gb');
    return await buildJsMediaHitGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMediaHit(jsObject: any): Promise<any> {
    let { buildDotNetMediaHitGenerated } = await import('./mediaHit.gb');
    return await buildDotNetMediaHitGenerated(jsObject);
}
