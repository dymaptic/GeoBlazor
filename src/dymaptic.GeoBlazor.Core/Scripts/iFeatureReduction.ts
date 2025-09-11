import {Pro} from './arcGisJsInterop';

export async function buildJsIFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null) {
    if (!Pro) return null;
            try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildJsFeatureReduction(dotNetObject, layerId, viewId);
    } catch (e) {
        throw e;
    }
}

export async function buildDotNetIFeatureReduction(featureReduction: any, viewId: string | null): Promise<any> {
    if (!Pro) return null;
            try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetFeatureReduction } = await import('./featureReduction');
        // @ts-ignore GeoBlazor Pro only
        return await buildDotNetFeatureReduction(featureReduction, viewId);
    } catch (e) {
        throw e;
    }
}
