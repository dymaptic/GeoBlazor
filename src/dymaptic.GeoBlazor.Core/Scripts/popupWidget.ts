import Popup from "@arcgis/core/widgets/Popup";
import {dotNetRefs} from "./arcGisJsInterop";
import Symbol from "@arcgis/core/symbols/Symbol";
import { buildJsSymbol } from "./symbol";
import PopupWidgetGenerated from "./popupWidget.gb";

export default class PopupWidgetWrapper extends PopupWidgetGenerated {
    private popup: Popup;

    constructor(popup: Popup) {
        super(popup);
        this.popup = popup;
    }

    unwrap() {
        return this.popup;
    }

    clear() {
        this.popup.clear();
    }

    close() {
        this.popup.close();
    }

    async fetchFeatures(): Promise<Array<any>> {
        let { buildDotNetGraphic } = await import('./graphic');
        return await Promise.all(this.popup.features.map(async (g) => await buildDotNetGraphic(g, null, null)));
    }

    getFeatureCount(): number {
        return this.popup.featureCount;
    }

    async getSelectedFeature(viewId: string | null): Promise<any | null> {
        let feature = this.popup.selectedFeature;
        let { buildDotNetGraphic } = await import('./graphic');
        let graphic = await buildDotNetGraphic(feature, null, viewId);
        if (viewId !== null && graphic !== null) {
            graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
        }
        return graphic;
    }

    getSelectedFeatureIndex(): number {
        return this.popup.selectedFeatureIndex;
    }

    getVisibility(): boolean {
        return this.popup.visible;
    }

    open() {
        this.popup.open();
    }

    setContent(content: string) {
        this.popup.content = content;
    }
    
    async setSelectedClusterBoundaryFeatureSymbol(symbol: any) {
        this.popup.viewModel.selectedClusterBoundaryFeature.symbol = await buildJsSymbol(symbol, this.layerId, this.viewId) as Symbol;
    }

    setProperty(prop: string, value: any): void {
        this.popup[prop] = value;
    }

    getProperty(prop: string) {
        return this.popup[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.popup[prop].addMany(value);
        } else {
            this.popup[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.popup[prop].removeMany(value);
        } else {
            this.popup[prop].remove(value);
        }
    }
}

export async function buildJsPopupWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupWidgetGenerated } = await import('./popupWidget.gb');
    return await buildJsPopupWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupWidget(jsObject: any): Promise<any> {
    let { buildDotNetPopupWidgetGenerated } = await import('./popupWidget.gb');
    return await buildDotNetPopupWidgetGenerated(jsObject);
}