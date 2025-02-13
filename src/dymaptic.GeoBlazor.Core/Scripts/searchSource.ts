import LayerSearchSource from "@arcgis/core/widgets/Search/LayerSearchSource";
import LocatorSearchSource from "@arcgis/core/widgets/Search/LocatorSearchSource";
import {arcGisObjectRefs, hasValue} from "./arcGisJsInterop";
import {buildDotNetGeometry} from "./geometry";
import { buildDotNetPopupTemplate } from "./popupTemplate";
import { buildDotNetSymbol } from "./symbol";
import { buildDotNetLayer } from "./layer";

export function buildDotNetSearchSource(jsSource: LayerSearchSource | LocatorSearchSource): any {
    let dnSource: any = {
        autoNavigate: jsSource.autoNavigate,
        maxResults: jsSource.maxResults,
        minSuggestCharacters: jsSource.minSuggestCharacters,
        name: jsSource.name,
        outFields: jsSource.outFields,
        placeholder: jsSource.placeholder,
        popupEnabled: jsSource.popupEnabled,
        prefix: jsSource.prefix,
        resultGraphicEnabled: jsSource.resultGraphicEnabled,
        searchTemplate: jsSource.searchTemplate,
        suffix: jsSource.suffix,
        suggestionsEnabled: jsSource.suggestionsEnabled,
        withinViewEnabled: jsSource.withinViewEnabled,
        zoomScale: jsSource.zoomScale,
    }

    if (hasValue(jsSource.popupTemplate)) {
        dnSource.popupTemplate = buildDotNetPopupTemplate(jsSource.popupTemplate);
    }

    if (hasValue(jsSource.resultSymbol)) {
        dnSource.resultSymbol = buildDotNetSymbol(jsSource.resultSymbol);
    }

    if (jsSource instanceof LayerSearchSource) {
        dnSource.type = 'layer';
        dnSource.displayField = jsSource.displayField;
        dnSource.exactMatch = jsSource.exactMatch;
        dnSource.layer = buildDotNetLayer(jsSource.layer);
        for (let key in arcGisObjectRefs) {
            if (arcGisObjectRefs[key] === jsSource.layer) {
                dnSource.layerId = key;
                break;
            }
        }
        dnSource.orderByFields = jsSource.orderByFields;
        dnSource.searchFields = jsSource.searchFields;
        dnSource.suggestionTemplate = jsSource.suggestionTemplate;
        dnSource.filter = {
            where: jsSource.filter?.where,
            geometry: buildDotNetGeometry(jsSource.filter?.geometry ?? null),
        }
    } else {
        dnSource.type = 'locator';
        dnSource.apiKey = jsSource.apiKey;
        dnSource.categories = jsSource.categories;
        dnSource.countryCode = jsSource.countryCode;
        dnSource.defaultZoomScale = jsSource.defaultZoomScale;
        dnSource.localSearchDisabled = jsSource.localSearchDisabled;
        dnSource.locationType = jsSource.locationType;
        dnSource.singleLineFieldName = jsSource.singleLineFieldName;
        dnSource.url = jsSource.url;
        dnSource.filter = {
            geometry: buildDotNetGeometry(jsSource.filter?.geometry ?? null)
        }
    }

    return dnSource;
}