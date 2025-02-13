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