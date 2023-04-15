import Popup from "@arcgis/core/widgets/Popup";
import {buildDotNetGraphic} from "./dotNetBuilder";
import {DotNetGraphic} from "./definitions";

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

    getSelectedFeature(): DotNetGraphic {
        return buildDotNetGraphic(this.popup.selectedFeature);
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
}