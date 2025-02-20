export async function buildJsDynamicLayer(dotNetSource: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetSource?.type) {
        case 'map-layer':
            let {buildJsDynamicMapLayer} = await import('./dynamicMapLayer');
            return await buildJsDynamicMapLayer(dotNetSource, layerId, viewId);
        default:
            let {buildJsDynamicDataLayer} = await import('./dynamicDataLayer');
            return await buildJsDynamicDataLayer(dotNetSource, layerId, viewId);
    }
}

export async function buildDotNetDynamicLayer(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'map-layer':
            let {buildDotNetDynamicMapLayer} = await import('./dynamicMapLayer');
            return await buildDotNetDynamicMapLayer(jsObject);
        default:
            let {buildDotNetDynamicDataLayer} = await import('./dynamicDataLayer');
            return await buildDotNetDynamicDataLayer(jsObject);
    }
}