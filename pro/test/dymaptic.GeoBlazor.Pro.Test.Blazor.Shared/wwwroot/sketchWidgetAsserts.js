import {arcGisObjectRefs, getView} from "../dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js";


export function assertTools(methodName, widgetId, tools) {
    let sketch = arcGisObjectRefs[widgetId];
    if (sketch.availableCreateTools.length !== tools.length) {
        throw new Error(`Expected ${tools.length} tools, got ${sketch.availableCreateTools.length}`);
    }
    for (let i = 0; i < tools.length; i++) {
        let tool = tools[i];
        if (!sketch.availableCreateTools.find(t => t === tool)) {
            throw new Error(`Expected to find ${tool}`);
        }
    }
}

export function assertVisibleElements(methodName, widgetId, visibleElements) {
    let sketch = arcGisObjectRefs[widgetId];
    if (sketch.visibleElements.settingsMenu !== visibleElements.settingsMenu) {
        throw new Error(`Expected settingsMenu to be ${visibleElements.settingsMenu}, got ${sketch.visibleElements.settingsMenu}`);
    }
    if (sketch.visibleElements.duplicateButton !== visibleElements.duplicateButton) {
        throw new Error(`Expected duplicateButton to be ${visibleElements.duplicateButton}, got ${sketch.visibleElements.duplicateButton}`);
    }
    if (sketch.visibleElements.createTools.point !== visibleElements.createTools.point) {
        throw new Error(`Expected createTools.point to be ${visibleElements.createTools.point}, got ${sketch.visibleElements.createTools.point}`);
    }
    if (sketch.visibleElements.createTools.polyline !== visibleElements.createTools.polyline) {
        throw new Error(`Expected createTools.polyline to be ${visibleElements.createTools.polyline}, got ${sketch.visibleElements.createTools.polyline}`);
    }
    if (sketch.visibleElements.createTools.polygon !== visibleElements.createTools.polygon) {
        throw new Error(`Expected createTools.polygon to be ${visibleElements.createTools.polygon}, got ${sketch.visibleElements.createTools.polygon}`);
    }
    if (sketch.visibleElements.createTools.rectangle !== visibleElements.createTools.rectangle) {
        throw new Error(`Expected createTools.rectangle to be ${visibleElements.createTools.rectangle}, got ${sketch.visibleElements.createTools.rectangle}`);
    }
    if (sketch.visibleElements.createTools.circle !== visibleElements.createTools.circle) {
        throw new Error(`Expected createTools.circle to be ${visibleElements.createTools.circle}, got ${sketch.visibleElements.createTools.circle}`);
    }
    if (sketch.visibleElements.selectionTools["rectangle-selection"] !== visibleElements.selectionTools.rectangleSelection) {
        throw new Error(`Expected selectionTools.rectangleSelection to be ${visibleElements.selectionTools.rectangleSelection}, got ${sketch.visibleElements.selectionTools["rectangle-selection"]}`);
    }
    if (sketch.visibleElements.selectionTools["lasso-selection"] !== visibleElements.selectionTools.lassoSelection) {
        throw new Error(`Expected selectionTools.lassoSelection to be ${visibleElements.selectionTools.lassoSelection}, got ${sketch.visibleElements.selectionTools["lasso-selection"]}`);
    }
}

export function canOverrideFeatureSourceInJs(methodName, widgetId, layerId) {
    let widget = arcGisObjectRefs[widgetId];
    widget.snappingOptions.featureSources = [{
        enabled: true,
        layer: arcGisObjectRefs[layerId]
    }]
}

export function createSketch(methodName, widgetId) {
    let sketch = arcGisObjectRefs[widgetId];
    if (!sketch) {
        throw new Error(`Sketch widget with id ${widgetId} not found`);
    }
    sketch.create("point");
}

export function assertSketchLayer(methodName, widgetId, layerId) {
    let sketch = arcGisObjectRefs[widgetId];
    let layer = arcGisObjectRefs[layerId];
    if (!sketch) {
        throw new Error(`Sketch widget with id ${widgetId} not found`);
    }
    if (!layer) {
        throw new Error(`Layer with id ${layerId} not found`);
    }
    if (sketch.layer !== layer) {
        throw new Error(`Expected SketchWidget.layer to be the ArcGIS layer reference ${layerId}`);
    }
    if (sketch.layer.declaredClass !== "esri.layers.GraphicsLayer") {
        throw new Error(`Expected SketchWidget.layer to be an ArcGIS GraphicsLayer but found ${sketch.layer.declaredClass}`);
    }
}