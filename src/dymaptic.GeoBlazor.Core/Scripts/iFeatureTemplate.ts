import {Pro} from "./arcGisJsInterop";

export async function buildJsIFeatureTemplate(dnFeatureTemplate: any): Promise<any> {
    if (!Pro) {
        return null;
    }
    
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        return await buildJsFeatureTemplate(dnFeatureTemplate);
    } catch (_) {
        return null;
    }
}

export async function buildDotNetIFeatureTemplate(jsObject: any): Promise<any> {
    if (!Pro) {
        return null;
    }
    
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
        return await buildDotNetFeatureTemplate(jsObject);
    } catch (_) {
        return null;
    }
}
