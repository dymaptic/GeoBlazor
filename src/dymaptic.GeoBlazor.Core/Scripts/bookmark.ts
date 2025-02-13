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