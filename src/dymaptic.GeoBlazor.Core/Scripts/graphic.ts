import Graphic from "@arcgis/core/Graphic";
import {DotNetGeometry, DotNetPopupTemplate, IPropertyWrapper} from "./definitions";
import {buildJsGeometry, buildJsPopupTemplate, buildJsSymbol} from "./jsBuilder";
import {buildDotNetGeometry, buildDotNetPopupTemplate} from "./dotNetBuilder";

export default class GraphicWrapper implements IPropertyWrapper {
    public component: Graphic;

    constructor(component: Graphic) {
        this.component = component;
        // set all properties from graphic
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }

    unwrap() {
        return this.component;
    }

    setAttribute(name: string, value: any): void {
        if (this.component.attributes[name] !== value) {
            this.component.attributes[name] = value;
        }
    }

    getAttribute(name: string): any {
        return this.component.attributes[name];
    }

    removeAttribute(name: string): void {
        delete this.component.attributes[name];
    }

    setGeometry(geometry: DotNetGeometry): void {
        let jsGeometry = buildJsGeometry(geometry);
        if (jsGeometry !== null && this.component.geometry !== jsGeometry) {
            this.component.geometry = jsGeometry;
        }
    }

    getGeometry(): DotNetGeometry | null {
        return buildDotNetGeometry(this.component.geometry);
    }

    setSymbol(symbol: any): void {
        if (this.component.symbol !== symbol) {
            this.component.symbol = buildJsSymbol(symbol) as any;
        }
    }

    getSymbol(): any {
        return this.component.symbol;
    }

    setVisibility(visible: boolean): void {
        this.component.visible = visible;
    }

    getVisibility(): boolean {
        return this.component.visible;
    }

    setPopupTemplate(popupTemplate: DotNetPopupTemplate, viewId: string): void {
        let jsPopupTemplate = buildJsPopupTemplate(popupTemplate, viewId);
        if (jsPopupTemplate !== null && this.component.popupTemplate !== jsPopupTemplate) {
            this.component.popupTemplate = jsPopupTemplate;
        }
    }

    getPopupTemplate(): DotNetPopupTemplate | null {
        return buildDotNetPopupTemplate(this.component.popupTemplate);
    }

    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }

    getProperty(prop: string) {
        return this.component[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.component[prop].addMany(value);
        } else {
            this.component[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.component[prop].removeMany(value);
        } else {
            this.component[prop].remove(value);
        }
    }
}