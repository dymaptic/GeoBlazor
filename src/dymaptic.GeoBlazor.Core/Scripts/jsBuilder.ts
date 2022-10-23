// @ts-ignore
import {DotNetExtent, DotNetSpatialReference} from "ArcGisDefinitions";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Extent from "@arcgis/core/geometry/Extent";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";
import SimpleRenderer from "@arcgis/core/renderers/SimpleRenderer";
import Renderer from "@arcgis/core/renderers/Renderer";
import Field from "@arcgis/core/layers/support/Field";
import Font from "@arcgis/core/symbols/Font";

export function buildJsSpatialReference(dotNetSpatialReference: DotNetSpatialReference): SpatialReference {
    let jsSpatialRef = new SpatialReference();
    if (dotNetSpatialReference.wkid !== null) {
        jsSpatialRef.wkid = dotNetSpatialReference.wkid;
    }
    if (dotNetSpatialReference.wkt !== null) {
        jsSpatialRef.wkt = dotNetSpatialReference.wkt;
    }

    return jsSpatialRef;
}

export function buildJsExtent(dotNetExtent: DotNetExtent): Extent {
    let extent = new Extent();
    if (dotNetExtent.xmax !== undefined && dotNetExtent.xmax !== null) {
        extent.xmax = dotNetExtent.xmax;
    }
    if (dotNetExtent.xmin !== undefined && dotNetExtent.xmin !== null) {
        extent.xmin = dotNetExtent.xmin;
    }
    if (dotNetExtent.ymax !== undefined && dotNetExtent.ymax !== null) {
        extent.ymax = dotNetExtent.ymax;
    }
    if (dotNetExtent.ymin !== undefined && dotNetExtent.ymin !== null) {
        extent.ymin = dotNetExtent.ymin;
    }
    if (dotNetExtent.zmax !== undefined && dotNetExtent.zmax !== null) {
        extent.zmax = dotNetExtent.zmax;
    }
    if (dotNetExtent.zmin !== undefined && dotNetExtent.zmin !== null) {
        extent.zmin = dotNetExtent.zmin;
    }
    if (dotNetExtent.mmax !== undefined && dotNetExtent.mmax !== null) {
        extent.mmax = dotNetExtent.mmax;
    }
    if (dotNetExtent.mmin !== undefined && dotNetExtent.mmin !== null) {
        extent.mmin = dotNetExtent.mmin;
    }
    
    return extent;
}

export function buildJsRenderer(dotNetRenderer: any): Renderer | null {
    if (dotNetRenderer === undefined || dotNetRenderer?.symbol === undefined ||
        dotNetRenderer?.symbol === null) return null;
    let dotNetSymbol = dotNetRenderer.symbol;
    switch (dotNetRenderer.type) {
        case 'simple':
            let renderer = new SimpleRenderer();
            switch (dotNetSymbol.type) {
                case 'text':
                    let symbol = buildJsTextSymbol(dotNetSymbol);
                    renderer.symbol = symbol;
                    return renderer;
            }
    }

    return dotNetRenderer
}


export function buildJsFields(dotNetFields: any): Array<Field> {
    let fields : Array<Field> = [];
    dotNetFields.forEach(dnField => {
        let field = new Field();
        for (const prop in dnField) {
            if (Object.prototype.hasOwnProperty.call(dnField, prop) && prop !== 'id') {
                field[prop] = dnField[prop];
            }
        }
        fields.push(field);
    });
    
    return fields;
}

export function buildJsTextSymbol(dotNetTextSymbol: any): TextSymbol {
    let symbol = new TextSymbol();
    if (dotNetTextSymbol.color !== undefined && dotNetTextSymbol.color !== null) {
        symbol.color = dotNetTextSymbol.color;
    }
    if (dotNetTextSymbol.haloColor !== undefined && dotNetTextSymbol.haloColor !== null) {
        symbol.haloColor = dotNetTextSymbol.haloColor;
    }
    if (dotNetTextSymbol.haloSize !== undefined && dotNetTextSymbol.haloSize !== null) {
        symbol.haloSize = dotNetTextSymbol.haloSize;
    }
    if (dotNetTextSymbol.text !== undefined && dotNetTextSymbol.text !== null) {
        symbol.text = dotNetTextSymbol.text;
    }
    if (dotNetTextSymbol.font !== undefined && dotNetTextSymbol.font !== null) {
        symbol.font = buildJsFont(dotNetTextSymbol.font);
    }
    
    return symbol;
}

function buildJsFont(dotNetFont: any) : Font {
    let font = new Font();
    font.size = dotNetFont.size;
    font.family = dotNetFont.family;
    font.style = dotNetFont.style;
    font.weight = dotNetFont.weight;
    
    return font;
}