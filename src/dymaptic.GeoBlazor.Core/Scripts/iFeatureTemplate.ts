export async function buildJsIFeatureTemplate(dnFeatureTemplate: any, layerId: string | null, viewId: string | null) : Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        return await buildJsFeatureTemplate(dnFeatureTemplate, layerId, viewId);
    } catch (e) {
        throw e;
    }
}

export async function buildDotNetIFeatureTemplate(jsObject: any, layerId: string | null, viewId: string | null) : Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
        return await buildDotNetFeatureTemplate(jsObject, layerId, viewId);
    } catch (e) {
        throw e;
    }
}
