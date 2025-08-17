import {hasValue, Pro} from "./arcGisJsInterop";

export async function buildJsICreationInfoTemplate(dotNetObject: any): Promise<any> {
    if (!Pro) return null;
    try {
        if (hasValue(dotNetObject.templateId)) {
            // @ts-ignore GeoBlazor Pro only
            let { buildJsSharedTemplateMetaData } = await import('./sharedTemplateMetadata');
            return await buildJsSharedTemplateMetaData(dotNetObject.templateId);
        }

        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureTemplate } = await import('./featureTemplate');
        return await buildJsFeatureTemplate(dotNetObject);
    } catch (e) {
        throw e;
    }
}     

export async function buildDotNetICreationInfoTemplate(jsObject: any): Promise<any> {
    if (!Pro) return null;
    try {
        if (hasValue(jsObject.templateId)) {
            // @ts-ignore GeoBlazor Pro only
            let { buildDotNetSharedTemplate } = await import('./sharedTemplateMetadata');
            return await buildDotNetSharedTemplate(jsObject);
        }

        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
        return await buildDotNetFeatureTemplate(jsObject);
    } catch (e) {
        throw e;
    }
}
