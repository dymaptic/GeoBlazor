// override generated code in this file
import CSVLayerViewGenerated from './cSVLayerView.gb';
import CSVLayerView from '@arcgis/core/views/layers/CSVLayerView';
import {hasValue, lookupJsGraphicById, graphicsRefs} from "./arcGisJsInterop";

export default class CSVLayerViewWrapper extends CSVLayerViewGenerated {

    constructor(component: CSVLayerView) {
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

export async function buildJsCSVLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerViewGenerated } = await import('./cSVLayerView.gb');
    return await buildJsCSVLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerViewGenerated } = await import('./cSVLayerView.gb');
    return await buildDotNetCSVLayerViewGenerated(jsObject, viewId);
}
