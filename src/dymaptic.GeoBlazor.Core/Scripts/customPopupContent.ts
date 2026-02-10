import {
    arcGisObjectRefs,
    buildJsStreamReference,
    hasValue,
    jsObjectRefs,
    lookupGeoBlazorId,
    removeCircularReferences,
    Pro
} from './geoBlazorCore';
import {buildDotNetGraphic} from "./graphic";
import CustomContent from "@arcgis/core/popup/content/CustomContent";
import {buildJsWidget} from "./widget";

export function buildJsCustomPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    if (!Pro) {
        throw new Error('Custom Popup Content only available with GeoBlazor Pro.');
    }

    let customContentDiv = document.getElementById(`custom-content-${dotNetObject.id}`) as HTMLElement;
    if (!hasValue(customContentDiv)) {
        return null;
    }

    // remove the custom content div from the DOM
    customContentDiv.parentElement?.removeChild(customContentDiv);
    customContentDiv.hidden = false;

    // remove comment nodes
    for (let i = 0; i < customContentDiv.childNodes.length; i++) {
        let childNode = customContentDiv.childNodes[i];
        if (childNode.nodeType === 8) {
            customContentDiv.removeChild(childNode);
            i--;
        }
    }

    let properties: any = {};
    if (hasValue(dotNetObject.hasContentCreatorFunction) && dotNetObject.hasContentCreatorFunction) {
        properties.creator = async (event) => {
            let dnGraphic = buildDotNetGraphic(event.graphic, layerId, viewId);
            let dnStream = buildJsStreamReference({graphic: dnGraphic});
            return await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsPopupTemplateContentCreator', dnStream);
        };
    } else if (hasValue(dotNetObject.widgetContent)) {
        properties.creator = async () => {
            return await buildJsWidget(dotNetObject.widgetContent, layerId, viewId);
        }
    } else {
        properties.creator = () => {
            return customContentDiv;
        }
    }

    if (hasValue(dotNetObject.hasDestroyerFunction) && dotNetObject.hasDestroyerFunction) {
        properties.destroyer = async (event) => {
            let dnGraphic = buildDotNetGraphic(event.graphic, layerId, viewId);
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsDestroyer', {graphic: dnGraphic});
        };
    }

    if (hasValue(dotNetObject.outFields) && dotNetObject.outFields.length > 0) {
        properties.outFields = dotNetObject.outFields;
    }

    let jsCustomContent = new CustomContent(properties);

    jsObjectRefs[dotNetObject.id] = jsCustomContent;
    arcGisObjectRefs[dotNetObject.id] = jsCustomContent;

    return jsCustomContent;
}

export function buildDotNetCustomPopupContent(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCustomPopupContent: any = {};

    if (hasValue(jsObject.outFields)) {
        dotNetCustomPopupContent.outFields = jsObject.outFields;
    }

    if (hasValue(jsObject.type)) {
        dotNetCustomPopupContent.type = removeCircularReferences(jsObject.type);
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetCustomPopupContent.id = geoBlazorId;
    }

    return dotNetCustomPopupContent;
}
