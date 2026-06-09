export async function buildDotNetIElevationSampler(jsObject: any): Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildDotNetElevationSampler } = await import('./elevationSampler');
        return await buildDotNetElevationSampler(jsObject);
    } catch (e) {
        
        throw e;
    }
}
export async function buildJsIElevationSampler(dotNetObject: any): Promise<any> {
    try {
        // @ts-ignore GeoBlazor Pro only
        let { buildJsElevationSampler } = await import('./elevationSampler');
        return await buildJsElevationSampler(dotNetObject);
    } catch (e) {
        
        throw e;
    }
}
