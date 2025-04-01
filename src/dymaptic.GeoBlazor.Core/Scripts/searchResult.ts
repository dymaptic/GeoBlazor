import {buildDotNetExtent} from "./extent";
import {buildDotNetGraphic} from "./graphic";

export function buildDotNetSearchResult(jsSearchResult) {
    let dnSearchResult: any = {
        extent: buildDotNetExtent(jsSearchResult.extent),
        feature: buildDotNetGraphic(jsSearchResult.feature, null, null),
        name: jsSearchResult.name,
        target: buildDotNetGraphic(jsSearchResult.target, null, null)
    }

    return dnSearchResult;
}

export async function buildJsSearchResult(dotNetObject: any): Promise<any> {
    let {buildJsSearchResultGenerated} = await import('./searchResult.gb');
    return await buildJsSearchResultGenerated(dotNetObject);
}
