// override generated code in this file

import {arcGisObjectRefs, hasValue, jsObjectRefs, lookupGeoBlazorId} from "./arcGisJsInterop";
import ActionToggle from "@arcgis/core/support/actions/ActionToggle";

export function buildJsActionToggle(dotNetObject: any): any {
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
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.value)) {
        properties.value = dotNetObject.value;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    let jsActionToggle = new ActionToggle(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsActionToggle);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsActionToggle;

    let dnInstantiatedObject = buildDotNetActionToggle(jsActionToggle);

    try {
        let seenObjects = new WeakMap();
        dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, JSON.stringify(dnInstantiatedObject, function (key, value) {
                if (key.startsWith('_') || key === 'jsComponentReference') {
                    return undefined;
                }
                if (typeof value === 'object' && value !== null
                    && !(Array.isArray(value) && value.length === 0)) {
                    if (seenObjects.has(value)) {
                        console.debug(`Circular reference in serializing type ActionToggle detected at path: ${key}, value: ${value.declaredClass}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                return value;
            }));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ActionToggle', e);
    }

    return jsActionToggle;
}

export function buildDotNetActionToggle(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetActionToggle: any = {};

    if (hasValue(jsObject.id)) {
        dotNetActionToggle.actionId = jsObject.id;
    }

    if (hasValue(jsObject.active)) {
        dotNetActionToggle.active = jsObject.active;
    }

    if (hasValue(jsObject.className)) {
        dotNetActionToggle.className = jsObject.className;
    }

    if (hasValue(jsObject.disabled)) {
        dotNetActionToggle.disabled = jsObject.disabled;
    }

    if (hasValue(jsObject.icon)) {
        dotNetActionToggle.icon = jsObject.icon;
    }

    if (hasValue(jsObject.title)) {
        dotNetActionToggle.title = jsObject.title;
    }

    if (hasValue(jsObject.type)) {
        dotNetActionToggle.type = jsObject.type;
    }

    if (hasValue(jsObject.value)) {
        dotNetActionToggle.value = jsObject.value;
    }

    if (hasValue(jsObject.visible)) {
        dotNetActionToggle.visible = jsObject.visible;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetActionToggle.id = geoBlazorId;
    }

    return dotNetActionToggle;
}
