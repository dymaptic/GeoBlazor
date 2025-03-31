export async function buildJsDynamicLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject?.type) {
        case 'map-layer':
            let {buildJsDynamicMapLayer} = await import('./dynamicMapLayer');
            return await buildJsDynamicMapLayer(dotNetObject, layerId, viewId);
        default:
            let {buildJsDynamicDataLayer} = await import('./dynamicDataLayer');
            return await buildJsDynamicDataLayer(dotNetObject, layerId, viewId);
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
