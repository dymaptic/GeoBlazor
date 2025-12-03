// override generated code in this file
import GraphicsLayerGenerated from './graphicsLayer.gb';
import GraphicsLayer from '@arcgis/core/layers/GraphicsLayer';
import {buildEncodedJson, graphicsRefs, hasValue, lookupJsGraphicById} from "./geoBlazorCore";

export default class GraphicsLayerWrapper extends GraphicsLayerGenerated {

    constructor(layer: GraphicsLayer) {
        super(layer);
    }

    async load(options: any): Promise<any> {
        let result = await this.layer.load(options);
        return await buildDotNetGraphicsLayer(result, this.viewId);
    }
    async remove(graphic: any): Promise<void> {
        let jsGraphic = lookupJsGraphicById(graphic.id, this.geoBlazorId, this.viewId);
        if (hasValue(jsGraphic)) {
            this.layer.remove(jsGraphic!);
        }
        delete graphicsRefs[this.geoBlazorId!][graphic.id];
    }

    async removeAll(): Promise<void> {
        this.layer.removeAll();
        graphicsRefs[this.geoBlazorId!] = {};
    }

    async removeMany(graphics: any): Promise<void> {
        let jsGraphics = graphics.map(i => lookupJsGraphicById(i.id, this.geoBlazorId, this.viewId)) as any;
        this.layer.removeMany(jsGraphics);
        graphics.forEach((graphic: any) => {
            delete graphicsRefs[this.geoBlazorId!][graphic.id];
        });
    }
}

export async function buildJsGraphicsLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGraphicsLayerGenerated} = await import('./graphicsLayer.gb');
    let jsObject = await buildJsGraphicsLayerGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.graphics) && dotNetObject.graphics.length > 0) {
        let { buildJsGraphic } = await import('./graphic');
        jsObject.graphics = dotNetObject.graphics.map(i => buildJsGraphic(i)) as any;
    }
    
    return jsObject;
}

export async function buildDotNetGraphicsLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetGraphicsLayerGenerated} = await import('./graphicsLayer.gb');
    return await buildDotNetGraphicsLayerGenerated(jsObject, viewId);
}
