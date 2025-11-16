import Bookmark from "@arcgis/core/webmap/Bookmark";
import Viewpoint from "@arcgis/core/Viewpoint";
import {hasValue} from "./arcGisJsInterop";

export async function buildDotNetBookmark(bookmark: any): Promise<any> {
    let {buildDotNetTimeExtent} = await import('./timeExtent');
    let {buildDotNetViewpoint} = await import('./viewpoint');

    return {
        name: bookmark.name,
        timeExtent: buildDotNetTimeExtent(bookmark.timeExtent),
        viewpoint: buildDotNetViewpoint(bookmark.viewpoint)
    }
}


export async function buildJsBookmark(dnBookmark: any): Promise<any> {
    if (dnBookmark === undefined || dnBookmark === null) return null;
    let bookmark = new Bookmark();
    if (hasValue(dnBookmark.name)) {
        bookmark.name = dnBookmark.name;
    }
    
    if (hasValue(dnBookmark.timeExtent)) {
        let {buildJsTimeExtent} = await import('./timeExtent');
        bookmark.timeExtent = await buildJsTimeExtent(dnBookmark.timeExtent);
    }

    if (hasValue(dnBookmark.thumbnail)) {
        //ArcGIS has this as an "object" with url property
        bookmark.thumbnail = {
            url: dnBookmark.thumbnail.url
        };
    }

    if (hasValue(dnBookmark.viewpoint)) {
        let {buildJsViewpoint} = await import('./viewpoint');
        bookmark.viewpoint = buildJsViewpoint(dnBookmark.viewpoint) as Viewpoint;
    }

    return bookmark as Bookmark;
}
