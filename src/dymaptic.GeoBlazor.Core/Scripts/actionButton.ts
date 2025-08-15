// override generated code in this file

import {arcGisObjectRefs, hasValue, jsObjectRefs, lookupGeoBlazorId} from "./arcGisJsInterop";
import ActionButton from "@arcgis/core/support/actions/ActionButton";

export function buildJsActionButton(dotNetObject: any, viewId: string | null): any {
    let properties: any = {};

    if (hasValue(dotNetObject.actionId)) {
        properties.id = dotNetObject.actionId;
    }
    if (hasValue(dotNetObject.active)) {
        properties.active = dotNetObject.active;
    }
    if (hasValue(dotNetObject.className)) {
        properties.className = dotNetObject.className;
    }
    if (hasValue(dotNetObject.disabled)) {
        properties.disabled = dotNetObject.disabled;
    }
    if (hasValue(dotNetObject.icon)) {
        properties.icon = dotNetObject.icon;
    }
    if (hasValue(dotNetObject.image)) {
        properties.image = dotNetObject.image;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    let jsActionButton = new ActionButton(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsActionButton);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsActionButton;

    return jsActionButton;
}

export function buildDotNetActionButton(jsObject: any, viewId: string | null): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetActionButton: any = {};

    if (hasValue(jsObject.id)) {
        dotNetActionButton.actionId = jsObject.id;
    }

    if (hasValue(jsObject.active)) {
        dotNetActionButton.active = jsObject.active;
    }

    if (hasValue(jsObject.className)) {
        dotNetActionButton.className = jsObject.className;
    }

    if (hasValue(jsObject.disabled)) {
        dotNetActionButton.disabled = jsObject.disabled;
    }

    if (hasValue(jsObject.icon)) {
        dotNetActionButton.icon = jsObject.icon;
    }

    if (hasValue(jsObject.image)) {
        dotNetActionButton.image = jsObject.image;
    }

    if (hasValue(jsObject.title)) {
        dotNetActionButton.title = jsObject.title;
    }

    if (hasValue(jsObject.type)) {
        dotNetActionButton.type = jsObject.type;
    }

    if (hasValue(jsObject.visible)) {
        dotNetActionButton.visible = jsObject.visible;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetActionButton.id = geoBlazorId;
    }

    return dotNetActionButton;
}
