import BookmarksViewModel from '@arcgis/core/widgets/Bookmarks/BookmarksViewModel';
import BookmarksViewModelGenerated from './bookmarksViewModel.gb';

export default class BookmarksViewModelWrapper extends BookmarksViewModelGenerated {

    constructor(component: BookmarksViewModel) {
        super(component);
    }
    
}

export async function buildJsBookmarksViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBookmarksViewModelGenerated } = await import('./bookmarksViewModel.gb');
    return await buildJsBookmarksViewModelGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetBookmarksViewModel(jsObject: any): Promise<any> {
    let { buildDotNetBookmarksViewModelGenerated } = await import('./bookmarksViewModel.gb');
    return await buildDotNetBookmarksViewModelGenerated(jsObject);
}
