// override generated code in this file
import WFSLayerViewGenerated from './wFSLayerView.gb';
import WFSLayerView from '@arcgis/core/views/layers/WFSLayerView';
import {hasValue, lookupJsGraphicById, graphicsRefs} from './geoBlazorCore';

export default class WFSLayerViewWrapper extends WFSLayerViewGenerated {

    constructor(component: WFSLayerView) {
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

export async function buildJsWFSLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerViewGenerated } = await import('./wFSLayerView.gb');
    return await buildJsWFSLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWFSLayerViewGenerated } = await import('./wFSLayerView.gb');
    return await buildDotNetWFSLayerViewGenerated(jsObject, viewId);
}
