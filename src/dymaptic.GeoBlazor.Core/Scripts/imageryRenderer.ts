export async function buildJsImageryRenderer(dnRenderer: any, layerId: string | null, viewId: string | null) {
    switch (dnRenderer?.imageryRendererType) {
        case 'unique-value':
            let {buildJsUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildJsUniqueValueRenderer(dnRenderer, layerId, viewId);
        case 'raster-stretch':
            try {
                // @ts-ignore GeoBlazor Pro only
                let {buildJsRasterStretchRenderer} = await import('./rasterStretchRenderer');
                return buildJsRasterStretchRenderer(dnRenderer);
            } catch (e) {
                throw e;
            }
    }

    return null;
}
export async function buildDotNetImageryRenderer(jsObject: any): Promise<any> {
    let { buildDotNetImageryRendererGenerated } = await import('./imageryRenderer.gb');
    return await buildDotNetImageryRendererGenerated(jsObject);
}
