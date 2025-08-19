
export async function buildJsImageryRenderer(dnRenderer: any, layerId: string | null, viewId: string | null) {
    switch (dnRenderer?.type) {
        case 'unique-value':
            let {buildJsUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildJsUniqueValueRenderer(dnRenderer, layerId, viewId);
        case 'raster-stretch':
            let {buildJsRasterStretchRenderer} = await import('./rasterStretchRenderer');
            return buildJsRasterStretchRenderer(dnRenderer, layerId, viewId);
    }

    return null;
}
export async function buildDotNetImageryRenderer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetImageryRendererGenerated } = await import('./imageryRenderer.gb');
    return await buildDotNetImageryRendererGenerated(jsObject, viewId);
}
