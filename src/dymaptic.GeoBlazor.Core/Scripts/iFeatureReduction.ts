export async function buildJsFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null) {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildDotNetFeatureReduction(dotNetObject, layerId, viewId);
    } catch {
        throw new Error("Feature reduction is only available in GeoBlazor Pro.");
    }
}

export async function buildDotNetFeatureReduction(featureReduction: any, layerId: string | null, viewId: string | null) {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildDotNetFeatureReduction(featureReduction, layerId, viewId);
    } catch {
        throw new Error("Feature reduction is only available in GeoBlazor Pro.");
    }
}