// override generated code in this file
import ImageryLayerViewGenerated from './imageryLayerView.gb';
import ImageryLayerView from '@arcgis/core/views/layers/ImageryLayerView';
import {hasValue, lookupJsGraphicById, graphicsRefs} from "./arcGisJsInterop";

export default class ImageryLayerViewWrapper extends ImageryLayerViewGenerated {

    constructor(component: ImageryLayerView) {
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

export async function buildJsImageryLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageryLayerViewGenerated } = await import('./imageryLayerView.gb');
    return await buildJsImageryLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImageryLayerView(jsObject: any): Promise<any> {
    let { buildDotNetImageryLayerViewGenerated } = await import('./imageryLayerView.gb');
    return await buildDotNetImageryLayerViewGenerated(jsObject);
}
