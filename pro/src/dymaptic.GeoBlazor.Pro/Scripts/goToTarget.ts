import { buildJsGoToTargetGenerated } from './goToTarget.gb';
import { buildDotNetGoToTargetGenerated } from './goToTarget.gb';

export function buildDotNetGoToTarget(jsObject: any, layerId: string | null, viewId: string | null): any {
    return buildDotNetGoToTargetGenerated(jsObject, layerId, viewId);
}

export function buildJsGoToTarget(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return buildJsGoToTargetGenerated(dotNetObject, layerId, viewId);
}
