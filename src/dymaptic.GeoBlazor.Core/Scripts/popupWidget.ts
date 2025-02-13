import Popup from "@arcgis/core/widgets/Popup";
import {DotNetGraphic, IPropertyWrapper} from "./definitions";
import {dotNetRefs} from "./arcGisJsInterop";
import {buildJsSymbol} from "./jsBuilder";
import Symbol from "@arcgis/core/symbols/Symbol";

export default class PopupWidgetWrapper implements IPropertyWrapper {
    private popup: Popup;

    constructor(popup: Popup) {
        this.popup = popup;
        // set all properties from graphic
        for (let prop in popup) {
            if (prop.hasOwnProperty(prop)) {
                this[prop] = popup[prop];
            }
        }
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

    async fetchFeatures(): Promise<Array<DotNetGraphic>> {
        let { buildDotNetGraphic } = await import('./graphic');
        return this.popup.features.map((g) => buildDotNetGraphic(g, null, null) as DotNetGraphic);
    }

    getFeatureCount(): number {
        return this.popup.featureCount;
    }

    async getSelectedFeature(viewId: string | null): Promise<DotNetGraphic | null> {
        let feature = this.popup.selectedFeature;
        let { buildDotNetGraphic } = await import('./graphic');
        let graphic = buildDotNetGraphic(feature, null, viewId);
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
    
    setSelectedClusterBoundaryFeatureSymbol(symbol: any) {
        this.popup.viewModel.selectedClusterBoundaryFeature.symbol = buildJsSymbol(symbol) as Symbol;
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