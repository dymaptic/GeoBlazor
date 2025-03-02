export async function buildJsFeatureTemplate(dnFeatureTemplate: any, layerId: string | null, viewId: string | null) : Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        return await buildJsFeatureTemplate(dnFeatureTemplate, layerId, viewId);
    } catch {
        throw new Error("Feature template is only available in GeoBlazor Pro.");
    }
}

export async function buildDotNetFeatureTemplate(jsObject: any, layerId: string | null, viewId: string | null) : Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
        return await buildDotNetFeatureTemplate(jsObject, layerId, viewId);
    } catch {
        throw new Error("Feature template is only available in GeoBlazor Pro.");
    }
}