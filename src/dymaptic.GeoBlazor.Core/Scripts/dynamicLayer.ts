export async function buildJsDynamicLayer(dotNetObject: any): Promise<any> {
    switch (dotNetObject?.type) {
        case 'map-layer':
            let {buildJsDynamicMapLayer} = await import('./dynamicMapLayer');
            return await buildJsDynamicMapLayer(dotNetObject);
        default:
            let {buildJsDynamicDataLayer} = await import('./dynamicDataLayer');
            return await buildJsDynamicDataLayer(dotNetObject);
    }
}

export async function buildDotNetDynamicLayer(jsObject: any, viewId: string | null): Promise<any> {
    switch (jsObject?.type) {
        case 'map-layer':
            let {buildDotNetDynamicMapLayer} = await import('./dynamicMapLayer');
            return await buildDotNetDynamicMapLayer(jsObject, viewId);
        default:
            let {buildDotNetDynamicDataLayer} = await import('./dynamicDataLayer');
            return await buildDotNetDynamicDataLayer(jsObject, viewId);
    }
}
