import {arcGisObjectRefs} from "../dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js";
import {getView} from "../dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js";


export function assertAllowedFormats(methodName, widgetId, allowedFormats) {
    let printWidget = arcGisObjectRefs[widgetId];
    let actualFormats = printWidget.allowedFormats;
    if (actualFormats.length !== allowedFormats.length) {
        throw new Error(`Expected ${allowedFormats.length} allowed formats, but got ${actualFormats.length}`);
    }
    for (let i = 0; i < allowedFormats.length; i++) {
        if (!actualFormats.includes(allowedFormats[i])) {
            throw new Error(`Expected allowed format ${allowedFormats[i]} not found in actual formats`);
        }
    }
    
    console.log(`${methodName} - Allowed formats assertion passed for widget ${widgetId}`);
    return 1;
}

export function assertAllowedLayouts(methodName, widgetId, allowedLayouts) {
    let printWidget = arcGisObjectRefs[widgetId];
    let actualLayouts = printWidget.allowedLayouts;
    if (actualLayouts.length !== allowedLayouts.length) {
        throw new Error(`Expected ${allowedLayouts.length} allowed layouts, but got ${actualLayouts.length}`);
    }
    for (let i = 0; i < allowedLayouts.length; i++) {
        if (!actualLayouts.includes(allowedLayouts[i])) {
            throw new Error(`Expected allowed layout ${allowedLayouts[i]} not found in actual layouts`);
        }
    }
    
    console.log(`${methodName} - Allowed layouts assertion passed for widget ${widgetId}`);
    return 1;
}

export function clickOnExportButton(methodName) {
    let view = getView(methodName);
    let widget = view.ui._components
        .find(c => c.widget?.declaredClass === "esri.widgets.Print")
        .widget.container;
    let addButton = widget.querySelector('.esri-print__export-button');
    if (!addButton) {
        throw new Error(`Export button not found`);
    }
    addButton.click();
}

export function assertTemplateOptions(methodName, widgetId) {
    let printWidget = arcGisObjectRefs[widgetId];
    let actualTemplateOptions = printWidget.templateOptions;
    
    if (actualTemplateOptions.copyright !== "xxx xxx") {
        throw new Error(`Expected copyright "xxx xxx", but got "${actualTemplateOptions.copyright}"`);
    }
    
    if (actualTemplateOptions.fileName !== "export") {
        throw new Error(`Expected fileName "export", but got "${actualTemplateOptions.fileName}"`);
    }
    
    if (actualTemplateOptions.dpi !== 600) {
        throw new Error(`Expected dpi 600, but got ${actualTemplateOptions.dpi}`);
    }
    
    console.log(`${methodName} - Template options assertion passed for widget ${widgetId}`);
    return 1;
}