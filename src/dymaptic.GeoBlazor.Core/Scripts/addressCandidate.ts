import {buildDotNetExtent} from "./extent";
import {buildDotNetPoint} from "./point";

export function buildDotNetAddressCandidate(addressCandidate): any {
    if (addressCandidate === undefined || addressCandidate === null) return null;

    return {
        address: addressCandidate.address,
        attributes: addressCandidate.attributes,
        extent: buildDotNetExtent(addressCandidate.extent),
        location: buildDotNetPoint(addressCandidate.location),
        score: addressCandidate.score
    } as DotNetAddressCandidate;
}