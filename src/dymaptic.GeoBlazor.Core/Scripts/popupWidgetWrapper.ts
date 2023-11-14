import Popup from "@arcgis/core/widgets/Popup";
import {buildDotNetGraphic} from "./dotNetBuilder";
import {DotNetGraphic} from "./definitions";
import {dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import {buildJsSymbol} from "./jsBuilder";
import Symbol from "@arcgis/core/symbols/Symbol";

export default class PopupWidgetWrapper {
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

    clear() {
        this.popup.clear();
    }

    close() {
        this.popup.close();
    }

    fetchFeatures(): Array<DotNetGraphic> {
        return this.popup.features.map(buildDotNetGraphic);
    }

    getFeatureCount(): number {
        return this.popup.featureCount;
    }

    async getSelectedFeature(viewId: string | null): Promise<DotNetGraphic> {
        let feature = this.popup.selectedFeature;
        let graphic = buildDotNetGraphic(feature);
        if (viewId !== null) {
            graphic.id = await dotNetRefs[viewId].invokeMethodAsync('GetId');
            graphicsRefs[graphic.id as string] = feature;
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
}