import {getView} from "./testRunner.js";

export function assertHasLegends(methodName) {
    let view = getView(methodName);
    let widgetHTML = view.ui._components.find(c => c.widget?.declaredClass === 'esri.widgets.LayerList')?.node.innerHTML;
    if (widgetHTML === undefined || widgetHTML === null) {
        throw new Error(`No widget HTML found for LayerList`);
    }
    if (!widgetHTML.includes('<div class="esri-legend esri-widget esri-widget--panel">')) {
        throw new Error(`No legends found in LayerList widget`);
    }

    return 1;
}

export function assertHasStringContent(methodName) {
    let view = getView(methodName);
    let widgetHTML = view.ui._components.find(c => c.widget?.declaredClass === 'esri.widgets.LayerList')?.node.innerHTML;
    if (widgetHTML === undefined || widgetHTML === null) {
        throw new Error(`No widget HTML found for LayerList`);
    }
    if (!widgetHTML.includes('Test String Content')) {
        throw new Error(`No test string content found in LayerList widget`);
    }

    return 1;
}

export function assertHasHtmlContent(methodName) {
    let view = getView(methodName);
    let widgetHTML = view.ui._components.find(c => c.widget?.declaredClass === 'esri.widgets.LayerList')?.node.innerHTML;
    if (widgetHTML === undefined || widgetHTML === null) {
        throw new Error(`No widget HTML found for LayerList`);
    }
    if (!widgetHTML.includes('<span class="test-html">Test HTML Content</span>')) {
        throw new Error(`No test HTML content found in LayerList widget`);
    }

    return 1;
}

export function assertHasWidgetContent(methodName) {
    let view = getView(methodName);
    let widgetHTML = view.ui._components.find(c => c.widget?.declaredClass === 'esri.widgets.LayerList')?.node.innerHTML;
    if (widgetHTML === undefined || widgetHTML === null) {
        throw new Error(`No widget HTML found for LayerList`);
    }
    if (!widgetHTML.includes('<div class="esri-search esri-widget">')) {
        throw new Error(`No test widget content found in LayerList widget`);
    }

    return 1;
}