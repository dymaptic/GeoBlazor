export async function buildJsIFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null) {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildDotNetFeatureReduction(dotNetObject, layerId, viewId);
    } catch (e) {
        throw e;
    }
}

export async function buildDotNetIFeatureReduction(featureReduction: any, layerId: string | null, viewId: string | null) {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildDotNetFeatureReduction(featureReduction, layerId, viewId);
    } catch (e) {
        throw e;
    }
}
