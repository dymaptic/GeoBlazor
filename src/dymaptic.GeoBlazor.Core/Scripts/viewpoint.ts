import {DotNetViewpoint} from "./definitions";
import {hasValue} from "./arcGisJsInterop";
import {buildDotNetGeometry} from "./geometry";

export function buildDotNetViewpoint(viewpoint: any): any {
    if (!hasValue(viewpoint)) return null;
    return {
        rotation: viewpoint.rotation,
        scale: viewpoint.scale,
        targetGeometry: buildDotNetGeometry(viewpoint.targetGeometry)
    } as DotNetViewpoint;
}