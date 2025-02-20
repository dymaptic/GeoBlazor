import {buildDotNetSearchResponseResults} from './searchResponseResults';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSearchResponseResultsGenerated(dotNetObject: any): Promise<any> {
    let jsSearchResponseResults: any = {}
    if (hasValue(dotNetObject.results)) {
        let {buildJsSearchResult} = await import('./searchResult');
        jsSearchResponseResults.results = await Promise.all(dotNetObject.results.map(async i => await buildJsSearchResult(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.source)) {
        jsSearchResponseResults.source = dotNetObject.source;
    }
    if (hasValue(dotNetObject.sourceIndex)) {
        jsSearchResponseResults.sourceIndex = dotNetObject.sourceIndex;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSearchResponseResults);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSearchResponseResults;

    let dnInstantiatedObject = await buildDotNetSearchResponseResults(jsSearchResponseResults);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SearchResponseResults', e);
    }

    return jsSearchResponseResults;
}

export async function buildDotNetSearchResponseResultsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSearchResponseResults: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.results)) {
        let {buildDotNetSearchResult} = await import('./searchResult');
        dotNetSearchResponseResults.results = jsObject.results.map(i => buildDotNetSearchResult(i));
    }
    if (hasValue(jsObject.source)) {
        dotNetSearchResponseResults.source = jsObject.source;
    }
    if (hasValue(jsObject.sourceIndex)) {
        dotNetSearchResponseResults.sourceIndex = jsObject.sourceIndex;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSearchResponseResults.id = k;
                break;
            }
        }
    }

    return dotNetSearchResponseResults;
}

