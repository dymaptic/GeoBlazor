export let Core;
export let arcGisObjectRefs;
export let Color;

(async () => {

    try {
        let Pro = await import("../dymaptic.GeoBlazor.Pro/js/arcGisPro.js");
        Core = await Pro.getCore();
    } catch {
        Core = await import("../dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js");
    }
    arcGisObjectRefs = Core.arcGisObjectRefs;
    Color = Core.Color;
})();

export function assertBasemapHasTwoLayers(methodName) {
    let view = getView(methodName);
    if (view.map.basemap.baseLayers.length !== 2) {
        throw new Error("Basemap does not have two layers");
    }
}

export function assertWidgetExists(methodName, widgetClass) {
    let view = getView(methodName);
    let widget = view.ui._components.find(c => c.widget.declaredClass === widgetClass)
    if (!widget) {
        throw new Error(`Widget ${widgetClass} does not exist`);
    }
}

export function assertGraphicExistsInView(methodName, geometryType, count) {
    let view = getView(methodName);
    let graphics = view.graphics.items.filter(g => g.geometry.type === geometryType);
    if (graphics.length !== count) {
        throw new Error(`Expected ${count} graphics of type ${geometryType} but found ${graphics.length}`);
    }
}

export function assertGraphicExistsInLayer(methodName, layerId, geometryType, count) {
    let layer = arcGisObjectRefs[layerId];
    let graphics = layer.graphics.items.filter(g => g.geometry.type === geometryType);
    if (graphics.length !== count) {
        throw new Error(`Expected ${count} graphics of type ${geometryType} but found ${graphics.length}`);
    }
}

export function assertSymbolOnLayer(methodName, layerId, symbolType, dnSymbol) {
    let layer = arcGisObjectRefs[layerId];
    if (layer.renderer.symbol.type !== symbolType) {
        throw new Error(`Expected symbol type ${symbolType} but found ${layer.renderer.symbol.type}`);
    }

    if (dnSymbol !== undefined && dnSymbol !== null) {
        Object.getOwnPropertyNames(dnSymbol).forEach((propertyName) => {
            let isMatch = false;
            switch (propertyName) {
                case "color":
                case "backgroundColor":
                case "borderLineColor":
                case "haloColor":
                    let dnColor = new Color(dnSymbol[propertyName]);
                    if (layer.renderer.symbol[propertyName]?.toHex() === dnColor.toHex()) {
                        isMatch = true;
                    }
                    break;
                case "lineWidth":
                    let lineVal = dnSymbol[propertyName];

                    if (lineVal.includes("px")) {
                        lineVal = lineVal.replace("px", "");
                        lineVal = lineVal * 0.75;
                    } else {
                        lineVal = lineVal.replace("pt", "");
                    }

                    // noinspection EqualityComparisonWithCoercionJS
                    isMatch = layer.renderer.symbol[propertyName] == lineVal;
                    break;
                case "xOffset":
                case "yOffset":
                    let val = dnSymbol[propertyName];

                    if (val.includes("px")) {
                        val = val.replace("px", "");
                        val = val * 0.75;
                    } else {
                        val = val.replace("pt", "");
                    }

                    // noinspection EqualityComparisonWithCoercionJS
                    isMatch = layer.renderer.symbol[propertyName.toLowerCase()] == val;
                    break;
                case "font":
                    let dnFont = dnSymbol[propertyName];
                    isMatch = layer.renderer.symbol[propertyName].family === dnFont.family;
                    break;
                case "id":
                    isMatch = true;
                    break;
                case "proProperties":
                    isMatch = true;
                    break;
                default:
                    isMatch = layer.renderer.symbol[propertyName] === dnSymbol[propertyName];
                    break;
            }

            if (!isMatch) {
                throw new Error(`Expected symbol property ${propertyName} to be ${dnSymbol[propertyName]} but found ${layer.renderer.symbol[propertyName]}`);
            }
        });
    }
}

export function assertLayerExists(methodName, layerType) {
    let view = getView(methodName);
    let layers = view.map.layers;
    for (let i = 0; i < layers.items.length; i++) {
        let layer = layers.items[i];
        if (layer.type === layerType) {
            return;
        }
    }

    throw new Error(`Expected layer of type ${layerType} but found none`);
}

export function testThrow() {
    throw new Error("Test throw");
}

export async function assertPopupCallback(methodName) {
    let view = getView(methodName);
    let layer = view.map.layers.items[0];
    let featureSet = await layer.queryFeatures();
    view.popup.open({
        features: [featureSet.features[0]]
    });
    let button = null;
    while (button === null) {
        await new Promise(resolve => setTimeout(resolve, 100));
        button = document.querySelector('[title="Measure Length"]');
    }
    button.click();
}

export async function triggerSearchHandlers() {
    let searchInput = document.querySelector('.esri-search__input');
    searchInput.value = 'testFromJavascript';
    searchInput.dispatchEvent(new Event('input'));
    await new Promise(resolve => setTimeout(resolve, 100));
    searchInput.value = 'testFromJavascript1';
    searchInput.dispatchEvent(new Event('input'));
}

export function assertWidgetPropertyEqual(methodName, widgetClass, propName, expectedValue) {
    let view = getView(methodName);
    let widget = view.ui._components.find(c => c.widget.declaredClass === widgetClass).widget;
    let actualValue = widget[propName];
    if (actualValue !== expectedValue) {
        throw new Error(`Expected ${propName} to be ${expectedValue} but found ${actualValue}`);
    }
}

export function scrollToTestClass(id) {
    const element = document.getElementById(id);
    if (element instanceof HTMLElement) {
        element.scrollIntoView({
            behavior: "smooth",
            block: "start",
            inline: "nearest"
        });
    }
}

export function getView(methodName) {
    const testDiv = document.getElementById(methodName);
    const mapContainer = testDiv.getElementsByClassName('map-container')[0];
    const viewId = mapContainer.id.replace('map-container-', '');
    return arcGisObjectRefs[viewId];
}