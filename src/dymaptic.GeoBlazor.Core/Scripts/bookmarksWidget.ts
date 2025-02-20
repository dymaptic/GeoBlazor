import Bookmarks from '@arcgis/core/widgets/Bookmarks';
import BookmarksWidgetGenerated from './bookmarksWidget.gb';

export default class BookmarksWidgetWrapper extends BookmarksWidgetGenerated {

    constructor(widget: Bookmarks) {
        super(widget);
    }

}

export async function buildJsBookmarksWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBookmarksWidgetGenerated} = await import('./bookmarksWidget.gb');
    return await buildJsBookmarksWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBookmarksWidget(jsObject: any): Promise<any> {
    let {buildDotNetBookmarksWidgetGenerated} = await import('./bookmarksWidget.gb');
    return await buildDotNetBookmarksWidgetGenerated(jsObject);
}
