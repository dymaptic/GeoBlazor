import {hasValue} from "./arcGisJsInterop";

export async function buildJsIEditorWidgetActiveWorkflow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    switch (dotNetObject.type) {
        case 'create-features':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsCreateFeaturesWorkflow} = await import('./createFeaturesWorkflow');
                return await buildJsCreateFeaturesWorkflow(dotNetObject, layerId, viewId);
            } catch (e) {
                throw new Error("Feature requires GeoBlazor Pro");
            }
        case 'update':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildJsUpdateWorkflow} = await import('./updateWorkflow');
                return await buildJsUpdateWorkflow(dotNetObject, layerId, viewId);
            } catch (e) {
                throw new Error("Feature requires GeoBlazor Pro");
            }
        default:
            return null;
    }
}     

export async function buildDotNetIEditorWidgetActiveWorkflow(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    switch (jsObject.type) {
        case 'create-features':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildDotNetCreateFeaturesWorkflow} = await import('./createFeaturesWorkflow');
                return await buildDotNetCreateFeaturesWorkflow(jsObject, layerId, viewId);
            } catch (e) {
                throw new Error("Feature requires GeoBlazor Pro");
            }
        case 'update':
            try {
                // @ts-ignore GeoBlazor Pro Only
                let {buildDotNetUpdateWorkflow} = await import('./updateWorkflow');
                return await buildDotNetUpdateWorkflow(jsObject, layerId, viewId);
            } catch (e) {
                throw new Error("Feature requires GeoBlazor Pro");
            }
        default:
            return null;
    }
}
