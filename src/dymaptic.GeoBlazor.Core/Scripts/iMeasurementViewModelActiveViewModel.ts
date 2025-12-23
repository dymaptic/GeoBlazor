
export async function buildJsIMeasurementViewModelActiveViewModel(dotNetObject: any): Promise<any> {
    // not used
}     

export async function buildDotNetIMeasurementViewModelActiveViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let className = jsObject.declaredClass;
    if (className.includes('AreaMeasurement')) {
        let { buildDotNetAreaMeasurement2DViewModel } = await import('./areaMeasurement2DViewModel');
        return await buildDotNetAreaMeasurement2DViewModel(jsObject, layerId, viewId);
    }
    if (className.includes('DistanceMeasurement')) {
        let { buildDotNetDistanceMeasurement2DViewModel } = await import('./distanceMeasurement2DViewModel');
        return await buildDotNetDistanceMeasurement2DViewModel(jsObject, layerId, viewId);
    }
    
    return null;
}
