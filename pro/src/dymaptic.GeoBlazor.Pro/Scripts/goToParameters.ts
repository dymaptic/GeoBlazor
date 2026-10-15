import { buildJsGoToParametersGenerated } from './goToParameters.gb';
import { buildDotNetGoToParametersGenerated } from './goToParameters.gb';
export function buildDotNetGoToParameters(jsObject: any, layerId: string | null, viewId: string | null): any {
    return buildDotNetGoToParametersGenerated(jsObject, layerId, viewId);
}

export function buildJsGoToParameters(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return buildJsGoToParametersGenerated(dotNetObject, layerId, viewId);
}
