import Popup from "@arcgis/core/widgets/Popup";
import {buildDotNetGraphic} from "./dotNetBuilder";

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

    getSelectedFeature() {
        return buildDotNetGraphic(this.popup.selectedFeature);
    }

    setContent(content: string) {
        this.popup.content = content;
    }
}