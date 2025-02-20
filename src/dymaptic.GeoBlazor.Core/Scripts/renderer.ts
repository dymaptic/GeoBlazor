// override generated code in this file

export async function buildJsRenderer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject?.type) {
        case 'simple':
            let {buildJsSimpleRenderer} = await import('./simpleRenderer');
            return await buildJsSimpleRenderer(dotNetObject, layerId, viewId);
        case 'pie-chart':
            // @ts-ignore only available in Pro
            let {buildJsPieChartRenderer} = await import('./pieChartRenderer');
            return await buildJsPieChartRenderer(dotNetObject, layerId, viewId);
        case 'unique-value':
            let {buildJsUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildJsUniqueValueRenderer(dotNetObject, layerId, viewId);
        default:
            throw new Error('Unknown renderer type');
    }
}


export async function buildDotNetRenderer(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'simple':
            let {buildDotNetSimpleRenderer} = await import('./simpleRenderer');
            return await buildDotNetSimpleRenderer(jsObject);
        case 'unique-value':
            let {buildDotNetUniqueValueRenderer} = await import('./uniqueValueRenderer');
            return await buildDotNetUniqueValueRenderer(jsObject);
        case 'pie-chart': // only available in Pro
            // @ts-ignore
            let {buildDotNetPieChartRenderer} = await import('./pieChartRenderer');
            return await buildDotNetPieChartRenderer(jsObject);
        default:
            return null;
    }
}
