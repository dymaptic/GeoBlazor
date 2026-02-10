import VisualVariable from "@arcgis/core/renderers/visualVariables/VisualVariable";

export async function buildDotNetVisualVariable(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'color':
            let {buildDotNetColorVariable} = await import('./colorVariable');
            return await buildDotNetColorVariable(jsObject);
        case 'size':
            let {buildDotNetSizeVariable} = await import('./sizeVariable');
            return await buildDotNetSizeVariable(jsObject);
        case 'opacity':
            let {buildDotNetOpacityVariable} = await import('./opacityVariable');
            return await buildDotNetOpacityVariable(jsObject);
        case 'rotation':
            let {buildDotNetRotationVariable} = await import('./rotationVariable');
            return await buildDotNetRotationVariable(jsObject);
        default:
            throw new Error('Unknown visual variable type');
    }
}

export async function buildJsVisualVariable(dotNetVisualVariable, layerId: string | null, viewId: string | null)
    : Promise<VisualVariable | null> {
    switch (dotNetVisualVariable?.type) {
        case 'color':
            let {buildJsColorVariable} = await import('./colorVariable');
            return await buildJsColorVariable(dotNetVisualVariable);
        case 'size':
            let {buildJsSizeVariable} = await import('./sizeVariable');
            return await buildJsSizeVariable(dotNetVisualVariable, layerId, viewId);
        case 'opacity':
            let {buildJsOpacityVariable} = await import('./opacityVariable');
            return await buildJsOpacityVariable(dotNetVisualVariable);
        case 'rotation':
            let {buildJsRotationVariable} = await import('./rotationVariable');
            return await buildJsRotationVariable(dotNetVisualVariable);
        default:
            throw new Error('Unknown visual variable type');
    }
}
