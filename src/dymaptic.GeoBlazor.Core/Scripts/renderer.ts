// override generated code in this file

import {hasValue, sanitize} from "./arcGisJsInterop";

export async function buildJsRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    switch (dotNetObject?.type) {
        case 'simple':
            let {buildJsSimpleRenderer} = await import('./simpleRenderer');
            return await buildJsSimpleRenderer(dotNetObject, layerId, viewId);
        case 'pie-chart':
            try {
                // @ts-ignore only available in Pro
                let {buildJsPieChartRenderer} = await import('./pieChartRenderer');
                return await buildJsPieChartRenderer(dotNetObject, layerId, viewId);
            } catch {
                throw new Error("Pie chart renderer is only available in GeoBlazor Pro.");
            }
        case 'unique-value':
            let {buildJsUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildJsUniqueValueRenderer(dotNetObject, layerId, viewId);
        default:
            return sanitize(dotNetObject);
    }
}


export async function buildDotNetRenderer(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    switch (jsObject?.type) {
        case 'simple':
            let {buildDotNetSimpleRenderer} = await import('./simpleRenderer');
            return await buildDotNetSimpleRenderer(jsObject);
        case 'unique-value':
            let {buildDotNetUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildDotNetUniqueValueRenderer(jsObject);
        case 'pie-chart':
            try {
                // @ts-ignore only available in Pro
                let {buildDotNetPieChartRenderer} = await import('./pieChartRenderer');
                return await buildDotNetPieChartRenderer(jsObject);
            } catch {
                throw new Error("Pie chart renderer is only available in GeoBlazor Pro.");
            }
        default:
            return jsObject;
    }
}
