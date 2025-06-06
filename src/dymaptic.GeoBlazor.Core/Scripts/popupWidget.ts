import Popup from '@arcgis/core/widgets/Popup';
import PopupWidgetGenerated from './popupWidget.gb';
import {dotNetRefs, hasValue} from "./arcGisJsInterop";
import Symbol from "@arcgis/core/symbols/Symbol";
import {buildJsSymbol} from "./symbol";
import {buildJsWidget} from "./widget";
import Widget from "@arcgis/core/widgets/Widget";

export default class PopupWidgetWrapper extends PopupWidgetGenerated {

    constructor(popup: Popup) {
        super(popup);
    }


    async updateComponent(dotNetObject: any): Promise<void> {
        await super.updateComponent(dotNetObject);
        if (hasValue(dotNetObject.widgetContent)) {
            const widgetContent = await buildJsWidget(dotNetObject.widgetContent, dotNetObject.widgetContent.layerId, this.viewId);
            if (hasValue(widgetContent)) {
                this.widget.content = widgetContent as Widget;
            }
        }

        if (hasValue(dotNetObject.htmlContent)) {
            this.widget.content = dotNetObject.htmlContent;
        }

        if (hasValue(dotNetObject.stringContent)) {
            this.widget.content = dotNetObject.stringContent;
        }
    }
    
    clear() {
        this.widget.clear();
    }

    close() {
        this.widget.close();
    }

    async fetchFeatures(): Promise<Array<any>> {
        let {buildDotNetGraphic} = await import('./graphic');
        return await Promise.all(this.widget.features.map(async (g) => await buildDotNetGraphic(g, null, null)));
    }

    getFeatureCount(): number {
        return this.widget.featureCount;
    }

    async getSelectedFeature(): Promise<any | null> {
        let feature = this.widget.selectedFeature;
        let {buildDotNetGraphic} = await import('./graphic');
        let graphic = buildDotNetGraphic(feature, null, this.viewId);
        return graphic;
    }

    getSelectedFeatureIndex(): number {
        return this.widget.selectedFeatureIndex;
    }

    getVisibility(): boolean {
        return this.widget.visible;
    }

    open() {
        this.widget.open();
    }

    setContent(content: string) {
        this.widget.content = content;
    }

    async setSelectedClusterBoundaryFeatureSymbol(symbol: any) {
        this.widget.viewModel.selectedClusterBoundaryFeature.symbol = await buildJsSymbol(symbol) as Symbol;
    }


}

export async function buildJsPopupWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupWidgetGenerated} = await import('./popupWidget.gb');
    let jsPopup = await buildJsPopupWidgetGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.widgetContent)) {
        const widgetContent = await buildJsWidget(dotNetObject.widgetContent, dotNetObject.widgetContent.layerId, viewId);
        if (hasValue(widgetContent)) {
            jsPopup.content = widgetContent as Widget;
        }
    }
    
    if (hasValue(dotNetObject.htmlContent)) {
        jsPopup.content = dotNetObject.htmlContent;
    }
    
    if (hasValue(dotNetObject.stringContent)) {
        jsPopup.content = dotNetObject.stringContent;
    }
    
    return jsPopup;
}

export async function buildDotNetPopupWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetPopupWidgetGenerated} = await import('./popupWidget.gb');
    return await buildDotNetPopupWidgetGenerated(jsObject, layerId, viewId);
}
