// override generated code in this file
import SublayerGenerated from './sublayer.gb';
import Sublayer from '@arcgis/core/layers/support/Sublayer';
import { hasValue } from './geoBlazorCore';

export default class SublayerWrapper extends SublayerGenerated {

    constructor(component: Sublayer) {
        super(component);
    }

    async getFields(): Promise<any> {
               
        if (this.component.loadStatus === 'not-loaded') {
            await this.component.load();
        }

        if (!hasValue(this.component.fields)) {
            return null;
        }

        let { buildDotNetField } = await import('./field');
        return this.component.fields!.map(i => buildDotNetField(i));
    }
}

export async function buildJsSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSublayerGenerated} = await import('./sublayer.gb');
    return await buildJsSublayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSublayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSublayerGenerated} = await import('./sublayer.gb');
    let dnObject = await buildDotNetSublayerGenerated(jsObject, layerId, viewId);
    if (hasValue(jsObject.sublayers) && jsObject.sublayers.items.length > 0) {
        dnObject.sublayers = [];
        for (let i = 0; i < jsObject.sublayers.items.length; i++) {
            const sublayer = jsObject.sublayers.items[i];
            dnObject.sublayers[i] = await buildDotNetSublayer(sublayer, layerId, viewId);
        }
    }
    return dnObject;
}
