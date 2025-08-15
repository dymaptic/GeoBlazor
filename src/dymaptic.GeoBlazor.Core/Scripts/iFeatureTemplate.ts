import {Pro} from "./arcGisJsInterop";

export async function buildJsIFeatureTemplate(dnFeatureTemplate: any, viewId: string | null): Promise<any> {
    if (!Pro) {
        return null;
    }
    
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        return await buildJsFeatureTemplate(dnFeatureTemplate, viewId);
    } catch (_) {
        return null;
    }
}

export async function buildDotNetIFeatureTemplate(jsObject: any, viewId: string | null): Promise<any> {
    if (!Pro) {
        return null;
    }
    
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
        return await buildDotNetFeatureTemplate(jsObject, viewId);
    } catch (_) {
        return null;
    }
}
