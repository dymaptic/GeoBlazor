import {buildDotNetExtent} from "./extent";
import {buildDotNetGraphic} from "./graphic";

export function buildDotNetSearchResult(jsSearchResult: any, layerId: string | null, viewId: string | null): any {
    let dnSearchResult: any = {
        extent: buildDotNetExtent(jsSearchResult.extent),
        feature: buildDotNetGraphic(jsSearchResult.feature, layerId, viewId),
        name: jsSearchResult.name,
        target: buildDotNetGraphic(jsSearchResult.target, layerId, viewId)
    }

    return dnSearchResult;
}

export async function buildJsSearchResult(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsSearchResultGenerated} = await import('./searchResult.gb');
    return await buildJsSearchResultGenerated(dotNetObject, viewId);
}
