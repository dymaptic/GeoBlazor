// override generated code in this file
import GeoJSONLayerViewGenerated from './geoJSONLayerView.gb';
import GeoJSONLayerView from '@arcgis/core/views/layers/GeoJSONLayerView';
import {hasValue, lookupJsGraphicById, graphicsRefs} from './geoBlazorCore';
import {DotNetQuery} from "./definitions";
import {buildDotNetQuery} from "./query";

export default class GeoJSONLayerViewWrapper extends GeoJSONLayerViewGenerated {

    constructor(component: GeoJSONLayerView) {
        super(component);
    }

    async createQuery(): Promise<DotNetQuery> {
        let jsQuery = this.component.createQuery();
        return await buildDotNetQuery(jsQuery, this.viewId);
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

export async function buildJsGeoJSONLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeoJSONLayerViewGenerated } = await import('./geoJSONLayerView.gb');
    return await buildJsGeoJSONLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeoJSONLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGeoJSONLayerViewGenerated } = await import('./geoJSONLayerView.gb');
    return await buildDotNetGeoJSONLayerViewGenerated(jsObject, viewId);
}
