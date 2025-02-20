import {buildDotNetSearchViewModelSearchResult} from './searchViewModelSearchResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSearchViewModelSearchResultGenerated(dotNetObject: any): Promise<any> {
    let jsSearchViewModelSearchResult: any = {}
    if (hasValue(dotNetObject.extent)) {
        let {buildJsExtent} = await import('./extent');
        jsSearchViewModelSearchResult.extent = buildJsExtent(dotNetObject.extent) as any;
    }
    if (hasValue(dotNetObject.feature)) {
        let {buildJsGraphic} = await import('./graphic');
        jsSearchViewModelSearchResult.feature = buildJsGraphic(dotNetObject.feature) as any;
    }

    if (hasValue(dotNetObject.name)) {
        jsSearchViewModelSearchResult.name = dotNetObject.name;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsSearchViewModelSearchResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsSearchViewModelSearchResult;

    let dnInstantiatedObject = await buildDotNetSearchViewModelSearchResult(jsSearchViewModelSearchResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SearchViewModelSearchResult', e);
    }

    return jsSearchViewModelSearchResult;
}

export async function buildDotNetSearchViewModelSearchResultGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSearchViewModelSearchResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.extent)) {
        let {buildDotNetExtent} = await import('./extent');
        dotNetSearchViewModelSearchResult.extent = buildDotNetExtent(jsObject.extent);
    }
    if (hasValue(jsObject.feature)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetSearchViewModelSearchResult.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
    }
    if (hasValue(jsObject.name)) {
        dotNetSearchViewModelSearchResult.name = jsObject.name;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSearchViewModelSearchResult.id = k;
                break;
            }
        }
    }

    return dotNetSearchViewModelSearchResult;
}

