// override generated code in this file
import GraphicsLayerViewGenerated from './graphicsLayerView.gb';
import GraphicsLayerView = __esri.GraphicsLayerView;
import {hasValue, lookupJsGraphicById} from "./arcGisJsInterop";

export default class GraphicsLayerViewWrapper extends GraphicsLayerViewGenerated {

    constructor(component: GraphicsLayerView) {
        super(component);
    }

    highlightByGeoBlazorId(geoBlazorId: string): any {
        let graphic = lookupJsGraphicById(geoBlazorId, this.layerId, this.viewId);
        if (hasValue(graphic)) {
            return this.component.highlight(graphic!);
        }

        return null;
    }

    highlightByGeoBlazorIds(geoBlazorIds: string[]): any {
        let graphics : any[] = [];
        geoBlazorIds.forEach(i => {
            let graphic = lookupJsGraphicById(i, this.layerId, this.viewId);
            if (hasValue(graphic)) {
                graphics.push(graphic);
            }
        });
        if (graphics.length === 0) {
            return null;
        }
        return this.component.highlight(graphics);
    }
}

export async function buildJsGraphicsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGraphicsLayerViewGenerated } = await import('./graphicsLayerView.gb');
    return await buildJsGraphicsLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGraphicsLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGraphicsLayerViewGenerated } = await import('./graphicsLayerView.gb');
    return await buildDotNetGraphicsLayerViewGenerated(jsObject, viewId);
}
