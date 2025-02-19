import {DotNetBookmark} from "./definitions";
import Bookmark from "@arcgis/core/webmap/Bookmark";
import Viewpoint from "@arcgis/core/Viewpoint";
import {hasValue} from "./arcGisJsInterop";

export async function buildDotNetBookmark(bookmark: any) {
    let { buildDotNetTimeExtent } = await import('./timeExtent');
    let { buildDotNetViewpoint } = await import('./viewpoint');
    
    return {
        name: bookmark.name,
        thumbnail: bookmark.thumbnail != null ? bookmark.thumbnail.url : null,
        timeExtent: buildDotNetTimeExtent(bookmark.timeExtent),
        viewpoint: buildDotNetViewpoint(bookmark.viewpoint)
    }
}


export async function buildJsBookmark(dnBookmark): Promise<Bookmark | null> {
    if (dnBookmark === undefined || dnBookmark === null) return null;
    let bookmark = new Bookmark();
    bookmark.name = dnBookmark.name ?? undefined;
    bookmark.timeExtent = dnBookmark.timeExtent ?? undefined;

    if (!(dnBookmark.thumbnail == null)) {
        //ESRI has this as an "object" with url property
        bookmark.thumbnail = { url: dnBookmark.thumbnail };
    }

    if (hasValue(dnBookmark.viewpoint)) {
        let { buildJsViewpoint } = await import('./viewpoint');
        bookmark.viewpoint = buildJsViewpoint(dnBookmark.viewpoint) as Viewpoint;
    }

    return bookmark as Bookmark;
}
