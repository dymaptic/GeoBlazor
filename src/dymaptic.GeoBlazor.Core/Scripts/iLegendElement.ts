
export async function buildJsILegendElement(dotNetObject: any): Promise<any> {
    switch (dotNetObject.type) {
        case 'symbol-table':
            let { buildJsSymbolTableElement } = await import('./symbolTableElement');
            return await buildJsSymbolTableElement(dotNetObject);
        case 'color-ramp':
            let { buildJsColorRampElement } = await import('./colorRampElement');
            return await buildJsColorRampElement(dotNetObject);
        case 'heatmap-ramp':
            let { buildJsHeatmapRampElement } = await import('./heatmapRampElement');
            return await buildJsHeatmapRampElement(dotNetObject);
        case 'opacity-ramp':
            let { buildJsOpacityRampElement } = await import('./opacityRampElement');
            return await buildJsOpacityRampElement(dotNetObject);
        case 'size-ramp':
            let { buildJsSizeRampElement } = await import('./sizeRampElement');
            return await buildJsSizeRampElement(dotNetObject);
        default:
            throw new Error(`Unknown type: ${dotNetObject.type}`);
    }
}     

export async function buildDotNetILegendElement(jsObject: any): Promise<any> {
    switch (jsObject.declaredClass) {
        case 'symbol-table':
            let { buildDotNetSymbolTableElement } = await import('./symbolTableElement');
            return await buildDotNetSymbolTableElement(jsObject, null);
        case 'color-ramp':
            let { buildDotNetColorRampElement } = await import('./colorRampElement');
            return await buildDotNetColorRampElement(jsObject, null);
        case 'heatmap-ramp':
            let { buildDotNetHeatmapRampElement } = await import('./heatmapRampElement');
            return await buildDotNetHeatmapRampElement(jsObject, null);
        case 'opacity-ramp':
            let { buildDotNetOpacityRampElement } = await import('./opacityRampElement');
            return await buildDotNetOpacityRampElement(jsObject, null);
        case 'size-ramp':
            let { buildDotNetSizeRampElement } = await import('./sizeRampElement');
            return await buildDotNetSizeRampElement(jsObject, null);
        default:
            throw new Error(`Unknown type: ${jsObject.type}`);
    }
}
