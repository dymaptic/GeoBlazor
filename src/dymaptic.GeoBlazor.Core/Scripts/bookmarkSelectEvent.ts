import {hasValue} from "./arcGisJsInterop";

export async function buildJsBookmarkSelectEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject?.bookmark)) {
        return null;
    }
    
    let {buildJsBookmark} = await import('./bookmark');
    let jsBookmark = await buildJsBookmark(dotNetObject.bookmark);
    return {
        bookmark: jsBookmark
    };
}

export async function buildDotNetBookmarkSelectEvent(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let {buildDotNetBookmark} = await import('./bookmark');
    let dotNetBookmark = await buildDotNetBookmark(jsObject.bookmark);
    
    return {
        bookmark: dotNetBookmark
    };
}
