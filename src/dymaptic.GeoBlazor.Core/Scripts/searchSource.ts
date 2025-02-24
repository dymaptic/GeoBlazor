import LocatorSearchSource from "@arcgis/core/widgets/Search/LocatorSearchSource";
import {arcGisObjectRefs, hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";
import {buildDotNetPoint} from "./point";
import {buildDotNetSpatialReference} from "./spatialReference";
import {buildJsExtent} from "./extent";
import {buildJsGraphic} from "./graphic";

export async function buildDotNetSearchSource(jsSource: any): Promise<any> {
    if (jsSource instanceof LocatorSearchSource) {
        let {buildDotNetLocatorSearchSource} = await import('./locatorSearchSource');
        return await buildDotNetLocatorSearchSource(jsSource);
    }

    let {buildDotNetLayerSearchSource} = await import('./layerSearchSource');
    return await buildDotNetLayerSearchSource(jsSource);
}

export async function buildJsSearchSource(dotNetSource: any, viewId: string | null): Promise<any> {
    let jsSource: any;

    if (hasValue(dotNetSource.url)) {
        let {buildJsLocatorSearchSource} = await import('./locatorSearchSource');
        jsSource = await buildJsLocatorSearchSource(dotNetSource, null, viewId);
    } else {
        let {buildJsLayerSearchSource} = await import('./layerSearchSource');
        let layerId = dotNetSource.layerId ?? dotNetSource.layer?.id;
        jsSource = await buildJsLayerSearchSource(dotNetSource, layerId, viewId);
    }

    if (dotNetSource.hasGetResultsHandler) {
        jsSource.getResults = async (params: any) => {
            let viewId: string | null = lookupGeoBlazorId(params.view);

            let dnParams = {
                exactMatch: params.exactMatch,
                location: buildDotNetPoint(params.location),
                maxResults: params.maxResults,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestResult: {
                    key: params.suggestResult.key,
                    text: params.suggestResult.text,
                    sourceIndex: params.suggestResult.sourceIndex
                },
                viewId: viewId
            }
            let dnResults = await dotNetSource.dotNetComponentReference.invokeMethodAsync('OnJsGetResults', dnParams);

            let results: any[] = [];

            for (let dnResult of dnResults) {
                let result: any = {
                    extent: buildJsExtent(dnResult.extent, null) ?? undefined,
                    name: dnResult.name ?? undefined,
                };
                if (hasValue(dnResult.feature)) {
                    result.feature = buildJsGraphic(dnResult.feature);
                }
                results.push(result);
            }

            return results;
        }
    }

    if (dotNetSource.hasGetSuggestionsHandler) {
        jsSource.getSuggestions = async (params: any) => {
            let viewId: string | null = null;

            for (let key in arcGisObjectRefs) {
                if (arcGisObjectRefs[key] === params.view) {
                    viewId = key;
                    break;
                }
            }

            let dnParams = {
                maxSuggestions: params.maxSuggestions,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestTerm: params.suggestTerm,
                viewId: viewId
            }
            let dnResults = await dotNetSource.dotNetComponentReference.invokeMethodAsync('OnJsGetSuggestions', dnParams);

            let results: any[] = [];

            for (let dnResult of dnResults) {
                results.push({
                    key: dnResult.key,
                    text: dnResult.text,
                    sourceIndex: dnResult.sourceIndex
                })
            }

            return results;
        }
    }

    return jsSource;
}
