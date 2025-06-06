// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import ButtonMenuItem from '@arcgis/core/widgets/FeatureTable/Grid/support/ButtonMenuItem';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetButtonMenuItem } from './buttonMenuItem';

export async function buildJsButtonMenuItemGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.hasClickFunction) && dotNetObject.hasClickFunction) {
        properties.clickFunction = async (event) => {

            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsClickFunction', event);
        };
    }

    if (hasValue(dotNetObject.autoCloseMenu)) {
        properties.autoCloseMenu = dotNetObject.autoCloseMenu;
    }
    if (hasValue(dotNetObject.iconClass)) {
        properties.iconClass = dotNetObject.iconClass;
    }
    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.open)) {
        properties.open = dotNetObject.open;
    }
    if (hasValue(dotNetObject.selected)) {
        properties.selected = dotNetObject.selected;
    }
    if (hasValue(dotNetObject.selectionEnabled)) {
        properties.selectionEnabled = dotNetObject.selectionEnabled;
    }
    let jsButtonMenuItem = new ButtonMenuItem(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsButtonMenuItem);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsButtonMenuItem;
    
    return jsButtonMenuItem;
}


export async function buildDotNetButtonMenuItemGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetButtonMenuItem: any = {};
    
    if (hasValue(jsObject.autoCloseMenu)) {
        dotNetButtonMenuItem.autoCloseMenu = jsObject.autoCloseMenu;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetButtonMenuItem.label = jsObject.label;
    }
    
    if (hasValue(jsObject.open)) {
        dotNetButtonMenuItem.open = jsObject.open;
    }
    
    if (hasValue(jsObject.selected)) {
        dotNetButtonMenuItem.selected = jsObject.selected;
    }
    
    if (hasValue(jsObject.selectionEnabled)) {
        dotNetButtonMenuItem.selectionEnabled = jsObject.selectionEnabled;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetButtonMenuItem.id = geoBlazorId;
    }

    return dotNetButtonMenuItem;
}

