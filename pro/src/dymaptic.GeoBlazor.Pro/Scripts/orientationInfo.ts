import { buildJsOrientationInfoGenerated } from './orientationInfo.gb';
import { buildDotNetOrientationInfoGenerated } from './orientationInfo.gb';

export function buildDotNetOrientationInfo(jsObject: any): any {
    return buildDotNetOrientationInfoGenerated(jsObject);
}

export function buildJsOrientationInfo(dotNetObject: any): any {
    return buildJsOrientationInfoGenerated(dotNetObject);
}
