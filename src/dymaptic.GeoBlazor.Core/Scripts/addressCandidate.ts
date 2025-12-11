import {buildDotNetExtent} from "./extent";
import {buildDotNetPoint} from "./point";
import {hasValue} from './geoBlazorCore';

export function buildDotNetAddressCandidate(addressCandidate: any): any {
    if (!hasValue(addressCandidate)) {
        return null;
    }

    return {
        address: addressCandidate.address,
        attributes: addressCandidate.attributes,
        extent: buildDotNetExtent(addressCandidate.extent),
        location: buildDotNetPoint(addressCandidate.location),
        score: addressCandidate.score
    }
}

export async function buildJsAddressCandidate(dotNetObject: any): Promise<any> {
    let {buildJsAddressCandidateGenerated} = await import('./addressCandidate.gb');
    return await buildJsAddressCandidateGenerated(dotNetObject);
}
