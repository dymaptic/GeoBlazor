import GraphicGenerated from './graphic.gb';
import Graphic from "@arcgis/core/Graphic";
import {DotNetGeometry, DotNetGraphic, DotNetPopupTemplate} from "./definitions";
import {buildJsAttributes, buildJsGeometry, buildJsPopupTemplate, buildJsSymbol, hasValue} from "./jsBuilder";
import {arcGisObjectRefs, copyValuesIfExists, graphicsRefs, lookupGraphicById} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Symbol from "@arcgis/core/symbols/Symbol";
import PopupTemplate from "@arcgis/core/PopupTemplate";
import { buildDotNetGeometry } from './geometry';
import { buildDotNetPopupTemplate } from './popupTemplate';
import { buildDotNetSymbol } from './symbol';

export default class GraphicWrapper extends GraphicGenerated {

    constructor(component: Graphic) {
        super(component);
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

    setPopupTemplate(popupTemplate: DotNetPopupTemplate): void {
        let jsPopupTemplate = buildJsPopupTemplate(popupTemplate, this.layerId, this.viewId);
        if (jsPopupTemplate !== null && this.component.popupTemplate !== jsPopupTemplate) {
            this.component.popupTemplate = jsPopupTemplate;
        }
    }

    async getPopupTemplate(): Promise<DotNetPopupTemplate | null> {
        return await buildDotNetPopupTemplate(this.component.popupTemplate);
    }




}
export function buildJsGraphic(graphicObject: any, layerId: string | null, viewId: string | null)
    : Graphic | null {
    let graphic: Graphic | null = lookupGraphicById(graphicObject.id, layerId, viewId);
    if (graphic !== null) {
        graphic.geometry = buildJsGeometry(graphicObject.geometry) as Geometry ?? graphic.geometry;
        graphic.symbol = buildJsSymbol(graphicObject.symbol) as Symbol ?? graphic.symbol;
    } else {
        graphic = new Graphic({
            geometry: buildJsGeometry(graphicObject.geometry) as Geometry ?? null,
            symbol: buildJsSymbol(graphicObject.symbol) as Symbol ?? null,
        });
    }

    graphic.attributes = buildJsAttributes(graphicObject.attributes);

    if (hasValue(graphicObject.popupTemplate)) {
        graphic.popupTemplate = buildJsPopupTemplate(graphicObject.popupTemplate, layerId, viewId) as PopupTemplate;
    }

    if (hasValue(graphicObject.origin)) {
        let layer : any | undefined = undefined;
        if (arcGisObjectRefs.hasOwnProperty(graphicObject.origin.id)) {
            layer = arcGisObjectRefs[graphicObject.origin.layerId] as any;
        }
        graphic.origin = {
            type: 'vector-tile',
            layer: layer,
            layerId: graphicObject.origin.arcGISLayerId,
            layerIndex: graphicObject.origin.layerIndex
        }
    }

    copyValuesIfExists(graphicObject, graphic, 'visible', 'aggregateGeometries');

    let groupId = layerId ?? viewId;
    if (hasValue(groupId)) {
        if (!graphicsRefs.hasOwnProperty(groupId!)) {
            graphicsRefs[groupId!] = {};
        }
        graphicsRefs[groupId!][graphicObject.id] = graphic;
    }

    return graphic;
}

export async function buildDotNetGraphic(graphic: Graphic, layerId: string | null, viewId: string | null)
    : Promise<DotNetGraphic | null> {
    if (graphic === undefined || graphic === null) return null;
    let dotNetGraphic = {} as DotNetGraphic;

    let groupId = layerId ?? viewId;
    if (groupId !== null && graphicsRefs.hasOwnProperty(groupId)) {
        let group = graphicsRefs[groupId];
        for (const k of Object.keys(group)) {
            if (group[k] === graphic) {
                dotNetGraphic.id = k;
                break;
            }
        }
    }
    else {
        for (const k of Object.keys(graphicsRefs)) {
            let group = graphicsRefs[k];
            for (const j of Object.keys(group)) {
                if (group[j] === graphic) {
                    dotNetGraphic.id = j;
                    break;
                }
            }
        }
    }

    dotNetGraphic.uid = (graphic as any).uid;
    dotNetGraphic.attributes = graphic.attributes ?? {};
    dotNetGraphic.visible = graphic.visible;
    dotNetGraphic.aggregateGeometries = graphic.aggregateGeometries;

    if (graphic.symbol !== undefined && graphic.symbol !== null) {
        dotNetGraphic.symbol = await buildDotNetSymbol(graphic.symbol);
    }

    dotNetGraphic.geometry = buildDotNetGeometry(graphic.geometry);
    return dotNetGraphic;
}
