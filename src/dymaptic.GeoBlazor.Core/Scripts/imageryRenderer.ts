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
            } catch {
                throw new Error("Raster stretch renderer is only available in GeoBlazor Pro.");
            }
    }

    return null;
}