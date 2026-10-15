// override generated code in this file
import OGCFeatureLayerViewGenerated from './oGCFeatureLayerView.gb';
import OGCFeatureLayerView from '@arcgis/core/views/layers/OGCFeatureLayerView';
import {hasValue, lookupJsGraphicById} from './geoBlazorCore';

export default class OGCFeatureLayerViewWrapper extends OGCFeatureLayerViewGenerated {

    constructor(component: OGCFeatureLayerView) {
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

export async function buildJsOGCFeatureLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOGCFeatureLayerViewGenerated } = await import('./oGCFeatureLayerView.gb');
    return await buildJsOGCFeatureLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOGCFeatureLayerView(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOGCFeatureLayerViewGenerated } = await import('./oGCFeatureLayerView.gb');
    return await buildDotNetOGCFeatureLayerViewGenerated(jsObject, layerId, viewId);
}
