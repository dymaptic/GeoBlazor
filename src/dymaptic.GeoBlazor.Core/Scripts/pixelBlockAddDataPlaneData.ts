
export async function buildJsPixelBlockAddDataPlaneData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelBlockAddDataPlaneDataGenerated } = await import('./pixelBlockAddDataPlaneData.gb');
    return await buildJsPixelBlockAddDataPlaneDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPixelBlockAddDataPlaneData(jsObject: any): Promise<any> {
    let { buildDotNetPixelBlockAddDataPlaneDataGenerated } = await import('./pixelBlockAddDataPlaneData.gb');
    return await buildDotNetPixelBlockAddDataPlaneDataGenerated(jsObject);
}
