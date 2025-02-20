import {buildDotNetSearchViewModelSearchResponseResults} from './searchViewModelSearchResponseResults';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSearchViewModelSearchResponseResultsGenerated(dotNetObject: any): Promise<any> {
    let jsSearchViewModelSearchResponseResults: any = {}
    if (hasValue(dotNetObject.results)) {
        let {buildJsSearchViewModelSearchResult} = await import('./searchViewModelSearchResult');
        jsSearchViewModelSearchResponseResults.results = await Promise.all(dotNetObject.results.map(async i => await buildJsSearchViewModelSearchResult(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.source)) {
        jsSearchViewModelSearchResponseResults.source = dotNetObject.source;
    }
    if (hasValue(dotNetObject.sourceIndex)) {
        jsSearchViewModelSearchResponseResults.sourceIndex = dotNetObject.sourceIndex;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSearchViewModelSearchResponseResults);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSearchViewModelSearchResponseResults;

    let dnInstantiatedObject = await buildDotNetSearchViewModelSearchResponseResults(jsSearchViewModelSearchResponseResults);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SearchViewModelSearchResponseResults', e);
    }

    return jsSearchViewModelSearchResponseResults;
}

export async function buildDotNetSearchViewModelSearchResponseResultsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSearchViewModelSearchResponseResults: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.results)) {
        let {buildDotNetSearchViewModelSearchResult} = await import('./searchViewModelSearchResult');
        dotNetSearchViewModelSearchResponseResults.results = await Promise.all(jsObject.results.map(async i => await buildDotNetSearchViewModelSearchResult(i, layerId, viewId)));
    }
    if (hasValue(jsObject.source)) {
        dotNetSearchViewModelSearchResponseResults.source = jsObject.source;
    }
    if (hasValue(jsObject.sourceIndex)) {
        dotNetSearchViewModelSearchResponseResults.sourceIndex = jsObject.sourceIndex;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSearchViewModelSearchResponseResults.id = k;
                break;
            }
        }
    }

    return dotNetSearchViewModelSearchResponseResults;
}

