import Bookmark from "@arcgis/core/webmap/Bookmark";
import Viewpoint from "@arcgis/core/Viewpoint";
import {hasValue} from "./arcGisJsInterop";

export async function buildDotNetBookmark(bookmark: any, viewId: string | null): Promise<any> {
    let {buildDotNetTimeExtent} = await import('./timeExtent');
    let {buildDotNetViewpoint} = await import('./viewpoint');

    return {
        name: bookmark.name,
        timeExtent: buildDotNetTimeExtent(bookmark.timeExtent, viewId),
        viewpoint: buildDotNetViewpoint(bookmark.viewpoint, viewId)
    }
}


export async function buildJsBookmark(dnBookmark: any, viewId: string | null): Promise<any> {
    if (dnBookmark === undefined || dnBookmark === null) return null;
    let bookmark = new Bookmark();
    if (hasValue(dnBookmark.name)) {
        bookmark.name = dnBookmark.name;
    }
    
    if (hasValue(dnBookmark.timeExtent)) {
        let {buildJsTimeExtent} = await import('./timeExtent');
        bookmark.timeExtent = await buildJsTimeExtent(dnBookmark.timeExtent, viewId);
    }

    if (hasValue(dnBookmark.thumbnail)) {
        //ArcGIS has this as an "object" with url property
        bookmark.thumbnail = {
            url: dnBookmark.thumbnail.url
        };
    }

    if (hasValue(dnBookmark.viewpoint)) {
        let {buildJsViewpoint} = await import('./viewpoint');
        bookmark.viewpoint = buildJsViewpoint(dnBookmark.viewpoint, viewId) as Viewpoint;
    }

    return bookmark as Bookmark;
}
