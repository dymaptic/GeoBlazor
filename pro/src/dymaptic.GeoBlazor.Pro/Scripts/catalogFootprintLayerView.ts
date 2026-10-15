// override generated code in this file
import CatalogFootprintLayerViewGenerated from './catalogFootprintLayerView.gb';
import CatalogFootprintLayerView from '@arcgis/core/views/layers/CatalogFootprintLayerView';
import {hasValue, lookupJsGraphicById} from './geoBlazorCore';

export default class CatalogFootprintLayerViewWrapper extends CatalogFootprintLayerViewGenerated {

    constructor(component: CatalogFootprintLayerView) {
        super(component);
    }

    highlight(target: any): any {
        return this.component.highlight(target);
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

export async function buildJsCatalogFootprintLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCatalogFootprintLayerViewGenerated } = await import('./catalogFootprintLayerView.gb');
    return await buildJsCatalogFootprintLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCatalogFootprintLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCatalogFootprintLayerViewGenerated } = await import('./catalogFootprintLayerView.gb');
    return await buildDotNetCatalogFootprintLayerViewGenerated(jsObject, viewId);
}
