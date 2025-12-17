// override generated code in this file
// @ts-ignore This exists in ArcGIS SDK definition
import VectorTileLayerView = __esri.VectorTileLayerView;
import {generateSerializableJson, hasValue} from './geoBlazorCore';
import {IPropertyWrapper} from "./definitions";

export default class VectorTileLayerViewWrapper implements IPropertyWrapper {
    public component: VectorTileLayerView;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: VectorTileLayerView) {
        this.component = component;
    }

    // region methods

    unwrap() {
        return this.component;
    }


    async updateComponent(dotNetObject: any): Promise<void> {

        if (hasValue(dotNetObject.visible)) {
            this.component.visible = dotNetObject.visible;
        }
    }

    async isFulfilled(): Promise<any> {
        return this.component.isFulfilled();
    }

    async isRejected(): Promise<any> {
        return this.component.isRejected();
    }

    async isResolved(): Promise<any> {
        return this.component.isResolved();
    }

    async when(callback: any,
               errback: any): Promise<any> {
        let result = await this.component.when(callback,
            errback);

        return generateSerializableJson(result);
    }

    // region properties

    async getLayer(): Promise<any> {
        if (!hasValue(this.component.layer)) {
            return null;
        }

        let {buildDotNetLayer} = await import('./layer');
        return await buildDotNetLayer(this.component.layer, this.viewId);
    }

    getProperty(prop: string): any {
        return this.component[prop];
    }

    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}

export async function buildJsVectorTileLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // not used
}     

export async function buildDotNetVectorTileLayerView(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVectorTileLayerViewGenerated } = await import('./vectorTileLayerView.gb');
    return await buildDotNetVectorTileLayerViewGenerated(jsObject, viewId);
}
