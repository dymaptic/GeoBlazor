export async function buildDotNetVisualVariable(jsObject: any): Promise<any> {
    switch (jsObject?.type){
        case 'color':
            let { buildDotNetColorVariable } = await import('./colorVariable');
            return await buildDotNetColorVariable(jsObject);
        case 'size':
            let { buildDotNetSizeVariable } = await import('./sizeVariable');
            return await buildDotNetSizeVariable(jsObject);
        case 'opacity':
            let { buildDotNetOpacityVariable } = await import('./opacityVariable');
            return await buildDotNetOpacityVariable(jsObject);
        case 'rotation':
            let { buildDotNetRotationVariable } = await import('./rotationVariable');
            return await buildDotNetRotationVariable(jsObject);
        default:
            throw new Error('Unknown visual variable type');
    }
}