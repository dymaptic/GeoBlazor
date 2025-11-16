import {buildDotNetExtent} from "./extent";
import {buildDotNetPoint} from "./point";
import {hasValue} from "./arcGisJsInterop";

export function buildDotNetAddressCandidate(addressCandidate: any, viewId: string | null): any {
    if (!hasValue(addressCandidate)) {
        return null;
    }

    return {
        address: addressCandidate.address,
        attributes: addressCandidate.attributes,
        extent: buildDotNetExtent(addressCandidate.extent, viewId),
        location: buildDotNetPoint(addressCandidate.location, viewId),
        score: addressCandidate.score
    }
}

export async function buildJsAddressCandidate(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsAddressCandidateGenerated} = await import('./addressCandidate.gb');
    return await buildJsAddressCandidateGenerated(dotNetObject, viewId);
}
