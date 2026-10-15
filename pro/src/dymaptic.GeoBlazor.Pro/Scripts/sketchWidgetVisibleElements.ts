import {arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, dotNetRefs} from './geoBlazorCore';

export async function buildJsSketchWidgetVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSketchVisibleElements: any = {};
    if (hasValue(dotNetObject.createTools)) {
        let { buildJsCreateTools } = await import('./createTools');
        jsSketchVisibleElements.createTools = await buildJsCreateTools(dotNetObject.createTools, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.selectionTools)) {
        let { buildJsSelectionTools } = await import('./selectionTools');
        jsSketchVisibleElements.selectionTools = await buildJsSelectionTools(dotNetObject.selectionTools) as any;
    }
    if (hasValue(dotNetObject.snappingControlsElements)) {
        let { buildJsSnappingControlsElements } = await import('./snappingControlsElements');
        jsSketchVisibleElements.snappingControlsElements = await buildJsSnappingControlsElements(dotNetObject.snappingControlsElements, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.deleteButton)) {
        jsSketchVisibleElements.deleteButton = dotNetObject.deleteButton;
    }
    if (hasValue(dotNetObject.duplicateButton)) {
        jsSketchVisibleElements.duplicateButton = dotNetObject.duplicateButton;
    }
    if (hasValue(dotNetObject.labelsToggle)) {
        jsSketchVisibleElements.labelsToggle = dotNetObject.labelsToggle;
    }
    if (hasValue(dotNetObject.selectionCountLabel)) {
        jsSketchVisibleElements.selectionCountLabel = dotNetObject.selectionCountLabel;
    }
    if (hasValue(dotNetObject.settingsMenu)) {
        jsSketchVisibleElements.settingsMenu = dotNetObject.settingsMenu;
    }
    if (hasValue(dotNetObject.snappingControls)) {
        jsSketchVisibleElements.snappingControls = dotNetObject.snappingControls;
    }
    if (hasValue(dotNetObject.tooltipsToggle)) {
        jsSketchVisibleElements.tooltipsToggle = dotNetObject.tooltipsToggle;
    }
    if (hasValue(dotNetObject.undoRedoMenu)) {
        jsSketchVisibleElements.undoRedoMenu = dotNetObject.undoRedoMenu;
    }

    jsObjectRefs[dotNetObject.id] = jsSketchVisibleElements;
    arcGisObjectRefs[dotNetObject.id] = jsSketchVisibleElements;

    return jsSketchVisibleElements;
}


export async function buildDotNetSketchWidgetVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSketchWidgetVisibleElements: any = {};

    if (hasValue(jsObject.createTools)) {
        let { buildDotNetCreateTools } = await import('./createTools');
        dotNetSketchWidgetVisibleElements.createTools = await buildDotNetCreateTools(jsObject.createTools);
    }

    if (hasValue(jsObject.selectionTools)) {
        let { buildDotNetSelectionTools } = await import('./selectionTools');
        dotNetSketchWidgetVisibleElements.selectionTools = await buildDotNetSelectionTools(jsObject.selectionTools);
    }

    if (hasValue(jsObject.snappingControlsElements)) {
        let { buildDotNetSnappingControlsElements } = await import('./snappingControlsElements');
        dotNetSketchWidgetVisibleElements.snappingControlsElements = await buildDotNetSnappingControlsElements(jsObject.snappingControlsElements);
    }

    if (hasValue(jsObject.deleteButton)) {
        dotNetSketchWidgetVisibleElements.deleteButton = jsObject.deleteButton;
    }

    if (hasValue(jsObject.duplicateButton)) {
        dotNetSketchWidgetVisibleElements.duplicateButton = jsObject.duplicateButton;
    }

    if (hasValue(jsObject.labelsToggle)) {
        dotNetSketchWidgetVisibleElements.labelsToggle = jsObject.labelsToggle;
    }

    if (hasValue(jsObject.selectionCountLabel)) {
        dotNetSketchWidgetVisibleElements.selectionCountLabel = jsObject.selectionCountLabel;
    }

    if (hasValue(jsObject.settingsMenu)) {
        dotNetSketchWidgetVisibleElements.settingsMenu = jsObject.settingsMenu;
    }

    if (hasValue(jsObject.snappingControls)) {
        dotNetSketchWidgetVisibleElements.snappingControls = jsObject.snappingControls;
    }

    if (hasValue(jsObject.tooltipsToggle)) {
        dotNetSketchWidgetVisibleElements.tooltipsToggle = jsObject.tooltipsToggle;
    }

    if (hasValue(jsObject.undoRedoMenu)) {
        dotNetSketchWidgetVisibleElements.undoRedoMenu = jsObject.undoRedoMenu;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSketchWidgetVisibleElements.id = geoBlazorId;
    } else if (hasValue(viewId)) {
        let dotNetRef = dotNetRefs[viewId!];
        dotNetSketchWidgetVisibleElements.id = await dotNetRef.invokeMethodAsync('GetId');
    }
    if (hasValue(dotNetSketchWidgetVisibleElements.id)) {
        jsObjectRefs[dotNetSketchWidgetVisibleElements.id] ??= jsObject;
        arcGisObjectRefs[dotNetSketchWidgetVisibleElements.id] ??= jsObject;
    }

    return dotNetSketchWidgetVisibleElements;
}

