// override generated code in this file

import LayerSearchSource from '@arcgis/core/widgets/Search/LayerSearchSource';
import {arcGisObjectRefs, hasValue, jsObjectRefs, lookupGeoBlazorId} from './geoBlazorCore';

export async function buildJsLayerSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.filter)) {
        let { buildJsSearchSourceFilter } = await import('./searchSourceFilter');
        properties.filter = await buildJsSearchSourceFilter(dotNetObject.filter) as any;
    }
    if (hasValue(dotNetObject.layerId)) {
        if (arcGisObjectRefs.hasOwnProperty(dotNetObject.layerId)) {
            properties.layer = arcGisObjectRefs[dotNetObject.layerId!];
        } else {
            let dnLayer = await dotNetObject.dotNetComponentReference.invokeMethodAsync('GetLayerFromJs');
            if (hasValue(dnLayer)) {
                let { buildJsLayer } = await import('./layer');
                properties.layer = await buildJsLayer(dnLayer, layerId, viewId);
            } else {
                console.warn(`LayerSearchSource: Unable to find layer with id ${dotNetObject.layerId}`);
            }
        }
    } else if (hasValue(dotNetObject.layer)) {
        let { buildJsLayer } = await import('./layer');
        properties.layer = await buildJsLayer(dotNetObject.layer, layerId, viewId);
    }
    
    if (hasValue(dotNetObject.popupTemplate)) {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        properties.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.resultSymbol)) {
        let { buildJsSymbol } = await import('./symbol');
        properties.resultSymbol = buildJsSymbol(dotNetObject.resultSymbol, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.autoNavigate)) {
        properties.autoNavigate = dotNetObject.autoNavigate;
    }
    if (hasValue(dotNetObject.displayField)) {
        properties.displayField = dotNetObject.displayField;
    }
    if (hasValue(dotNetObject.exactMatch)) {
        properties.exactMatch = dotNetObject.exactMatch;
    }
    if (hasValue(dotNetObject.maxResults)) {
        properties.maxResults = dotNetObject.maxResults;
    }
    if (hasValue(dotNetObject.maxSuggestions)) {
        properties.maxSuggestions = dotNetObject.maxSuggestions;
    }
    if (hasValue(dotNetObject.minSuggestCharacters)) {
        properties.minSuggestCharacters = dotNetObject.minSuggestCharacters;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.orderByFields) && dotNetObject.orderByFields.length > 0) {
        properties.orderByFields = dotNetObject.orderByFields;
    }
    if (hasValue(dotNetObject.outFields) && dotNetObject.outFields.length > 0) {
        properties.outFields = dotNetObject.outFields;
    }
    if (hasValue(dotNetObject.placeholder)) {
        properties.placeholder = dotNetObject.placeholder;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        properties.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.prefix)) {
        properties.prefix = dotNetObject.prefix;
    }
    if (hasValue(dotNetObject.resultGraphicEnabled)) {
        properties.resultGraphicEnabled = dotNetObject.resultGraphicEnabled;
    }
    if (hasValue(dotNetObject.searchFields) && dotNetObject.searchFields.length > 0) {
        properties.searchFields = dotNetObject.searchFields;
    }
    if (hasValue(dotNetObject.searchTemplate)) {
        properties.searchTemplate = dotNetObject.searchTemplate;
    }
    if (hasValue(dotNetObject.suffix)) {
        properties.suffix = dotNetObject.suffix;
    }
    if (hasValue(dotNetObject.suggestionsEnabled)) {
        properties.suggestionsEnabled = dotNetObject.suggestionsEnabled;
    }
    if (hasValue(dotNetObject.suggestionTemplate)) {
        properties.suggestionTemplate = dotNetObject.suggestionTemplate;
    }
    if (hasValue(dotNetObject.withinViewEnabled)) {
        properties.withinViewEnabled = dotNetObject.withinViewEnabled;
    }
    if (hasValue(dotNetObject.zoomScale)) {
        properties.zoomScale = dotNetObject.zoomScale;
    }
    let jsLayerSearchSource = new LayerSearchSource(properties);

    jsObjectRefs[dotNetObject.id] = jsLayerSearchSource;
    arcGisObjectRefs[dotNetObject.id] = jsLayerSearchSource;

    return jsLayerSearchSource;
}

export async function buildDotNetLayerSearchSource(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetLayerSearchSourceGenerated} = await import('./layerSearchSource.gb');
    let dnObject = await buildDotNetLayerSearchSourceGenerated(jsObject, viewId);
    
    if (hasValue(jsObject.layer)) {
        dnObject.layerId = lookupGeoBlazorId(jsObject.layer);
    }
    
    return dnObject;
}
