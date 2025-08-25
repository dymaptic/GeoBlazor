export let Core;
export let arcGisObjectRefs;
let Color;
export let Portal;
export let SimpleRenderer;

let esriConfig;

export function initialize(core) {
    Core = core;
    arcGisObjectRefs = Core.arcGisObjectRefs;
    Color = Core.Color;
    Portal = Core.Portal;
    SimpleRenderer = Core.SimpleRenderer;
    esriConfig = Core.esriConfig;
}

export function setJsTimeout(time, methodName) {
    delete timeouts[methodName];
    setTimeout(() => {
        timeouts[methodName] = true;
    }, time);
}

export function timeoutComplete(methodName) {
    return timeouts[methodName] === true;
}

let timeouts = {};

export async function dispatchEvent(methodName, objectId, eventName) {
    let obj = arcGisObjectRefs[objectId];
    let event = new Event(eventName);
    obj.dispatchEvent(event);
}
export function assertBasemapHasTwoLayers(methodName) {
    let view = getView(methodName);
    if (view.map.basemap.baseLayers.length !== 2) {
        throw new Error("Basemap does not have two layers");
    }
}

export function assertWidgetExists(methodName, widgetClass) {
    let view = getView(methodName);
    let widget = view.ui._components.find(c => c.widget.declaredClass === widgetClass);
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

export async function assertGraphicExistsInLayer(methodName, layerId, geometryType, count) {
    let layer = arcGisObjectRefs[layerId];
    let graphics;
    if (layer.declaredClass === 'esri.layers.FeatureLayer') {
        let featureSet = await layer.queryFeatures();
        graphics = featureSet.features;
    } else {
        graphics = layer.graphics.items.filter(g => g.geometry.type === geometryType);
    }
    
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
                    isMatch = layer.renderer.symbol[propertyName]?.family === dnFont.family;
                    break;
                case "id":
                case "layerId":
                case "viewId":
                case "proProperties":
                case "dotNetComponentReference":
                    isMatch = true;
                    break;
                default:
                    isMatch = layer.renderer.symbol[propertyName]?.toString() === dnSymbol[propertyName]?.toString();
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

export function assertGroupLayerHasLayer(methodName, layerType) {
    let view = getView(methodName);
    let layers = view.map.layers;
    let groupLayer = layers.find(l => l.type === 'group');
    if (groupLayer === undefined) {
        throw new Error(`Expected group layer but found none`);
    }
    for (let i = 0; i < groupLayer.layers.items.length; i++) {
        let layer = groupLayer.layers.items[i];
        if (layer.type === layerType) {
            return;
        }
    }
    
    throw new Error(`Expected layer of type ${layerType} but found none`);
}

export function assertObjectHasPropertyWithValue(methodName, objectId, propertyName, expectedValue) {
    let props = propertyName.split('.');
    let obj = arcGisObjectRefs[objectId];
    for (var i = 0; i < props.length; i++) {
        let prop = props[i];
        let candidate = obj[prop];
        if (candidate === undefined) {
            throw new Error(`Expected ${propertyName} to be ${expectedValue} but found undefined part ${prop}`);
        }
        obj = candidate;
    }
    
    if (obj !== expectedValue) {
        throw new Error(`Expected ${propertyName} to be ${expectedValue} but found ${obj}`);
    }
}

export function testThrow() {
    throw new Error("Test throw");
}

export async function clickOnPopupAction(methodName) {
    let view = getView(methodName);
    let layer = view.map.layers.items[0];
    let featureSet = await layer.queryFeatures();
    await view.openPopup({
        features: [featureSet.features[0]]
    });
    let button = null;
    while (button === null) {
        await new Promise(resolve => setTimeout(resolve, 100));
        button = document.querySelector('[title="Measure Length"]');
    }
    button.click();
}

export async function clickOnGraphicPopupAction(methodName) {
    let view = getView(methodName);
    let layer = view.map.layers.items[0];
    let graphic = layer.graphics.items[0];
    await view.openPopup({
        features: [graphic]
    });
    let button = null;
    while (button === null) {
        await new Promise(resolve => setTimeout(resolve, 100));
        button = document.querySelector('[title="Button Click"]');
    }
    button.click();
}

export async function clickOnMap(methodName) {
    let view = getView(methodName);
    let mapContainer = view.container;
    if (mapContainer === null) {
        throw new Error(`Map container for view ${view.id} not found`);
    }
    
    let rect = mapContainer.getBoundingClientRect();
    let clickEvent = new MouseEvent('click', {
        clientX: rect.left + (rect.width / 2),
        clientY: rect.top + (rect.height / 2),
        bubbles: true,
        cancelable: true
    });
    
    mapContainer.dispatchEvent(clickEvent);
}

export async function triggerSearchHandlers() {
    let searchInput = document.querySelector('.esri-search__autocomplete')
        .shadowRoot.querySelector('calcite-input')
        .shadowRoot.querySelector('input');
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

export function elementExists(id) {
    let element = document.getElementById(id);
    if (element === null) {
        throw new Error(`Element with id ${id} does not exist`);
    }
}

export function getView(methodName) {
    const testDiv = document.getElementById(methodName);
    const mapContainer = testDiv.getElementsByClassName('map-container')[0];
    const viewId = mapContainer.id.replace('map-container-', '');
    return arcGisObjectRefs[viewId];
}

export function assertImageExists(methodName, elementId) {
    let element = document.getElementById(elementId);
    if (element === null) {
        throw new Error(`Element with id ${elementId} does not exist`);
    }
    if (element.tagName !== 'IMG') {
        throw new Error(`Element with id ${elementId} is not an image`);
    }
}

export function assertBasemapHasStyle(methodName, style) {
    let view = getView(methodName);
    if (view.map.basemap.style.id !== style) {
        throw new Error("Basemap does not have expected style");
    }
}

export function assertBasemapHasPortalItemId(methodName, portalItemId) {
    let view = getView(methodName);
    if (view.map.basemap.portalItem.id !== portalItemId) {
        throw new Error("Basemap does not have expected portalItemId");
    }
}

export function assertApiKeyAdded(methodName) {
    if (esriConfig.apiKey === undefined || esriConfig.apiKey === null) {
        throw new Error("API key not added");
    }
}

export function waitForWidgetToLoad(methodName, widgetClass) {
    return new Promise((resolve, reject) => {
        let view = getView(methodName);
        let interval = setInterval(() => {
            let widget = view.ui._components.find(c => c.widget.declaredClass === widgetClass);
            if (widget) {
                let innerHTML = widget.node.innerHTML;
                if (innerHTML.includes("__loader")) {
                    return;
                }
                clearInterval(interval);
                widget.widget.when(() => {
                    resolve(widget.widget);
                })
            }
        }, 100);
    });
}