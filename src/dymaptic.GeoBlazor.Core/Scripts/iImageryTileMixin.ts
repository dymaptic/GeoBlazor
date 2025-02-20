import ImageryTileMixin = __esri.ImageryTileMixin;
import IImageryTileMixinGenerated from './iImageryTileMixin.gb';

export default class IImageryTileMixinWrapper extends IImageryTileMixinGenerated {

    constructor(component: ImageryTileMixin) {
        super(component);
    }

}

export async function buildJsIImageryTileMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIImageryTileMixinGenerated} = await import('./iImageryTileMixin.gb');
    return await buildJsIImageryTileMixinGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIImageryTileMixin(jsObject: any): Promise<any> {
    let {buildDotNetIImageryTileMixinGenerated} = await import('./iImageryTileMixin.gb');
    return await buildDotNetIImageryTileMixinGenerated(jsObject);
}
