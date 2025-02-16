import FlowRenderer from "@arcgis/core/renderers/FlowRenderer";
import {hasValue} from "./arcGisJsInterop";

export async function buildJsFlowRenderer(dotNetFlowRenderer, layerId: string | null, viewId: string | null)
    : Promise<FlowRenderer | null> {
    if (dotNetFlowRenderer === undefined) return null;
    let flowRenderer = new FlowRenderer();

    if (hasValue(dotNetFlowRenderer.authoringInfo)) {
        let { buildJsAuthoringInfo } = await import('./authoringInfo');
        flowRenderer.authoringInfo = await buildJsAuthoringInfo(dotNetFlowRenderer.authoringInfo, layerId, viewId);
    }
    if (hasValue(dotNetFlowRenderer.color)) {
        let { buildJsColor } = await import('./mapColor');
        flowRenderer.color = buildJsColor(dotNetFlowRenderer.color);
    }
    if (hasValue(dotNetFlowRenderer.density)) {
        flowRenderer.density = dotNetFlowRenderer.density;
    }
    if (hasValue(dotNetFlowRenderer.flowRepresentation)) {
        flowRenderer.flowRepresentation = dotNetFlowRenderer.flowRepresentation as any;
    }
    if (hasValue(dotNetFlowRenderer.flowSpeed)) {
        flowRenderer.flowSpeed = dotNetFlowRenderer.flowSpeed;
    }
    if (hasValue(dotNetFlowRenderer.maxPathLength)) {
        flowRenderer.maxPathLength = dotNetFlowRenderer.maxPathLength;
    }
    if (hasValue(dotNetFlowRenderer.trailCap)) {
        flowRenderer.trailCap = dotNetFlowRenderer.trailCap as any;
    }
    if (hasValue(dotNetFlowRenderer.trailLength)) {
        flowRenderer.trailLength = dotNetFlowRenderer.trailLength;
    }
    if (hasValue(dotNetFlowRenderer.trailWidth)) {
        flowRenderer.trailWidth = dotNetFlowRenderer.trailWidth;
    }
    if (hasValue(dotNetFlowRenderer.visualVariables)) {
        let { buildJsVisualVariable } = await import('./visualVariable');
        flowRenderer.visualVariables = dotNetFlowRenderer.visualVariables.map(buildJsVisualVariable);
    }
    return flowRenderer;
}