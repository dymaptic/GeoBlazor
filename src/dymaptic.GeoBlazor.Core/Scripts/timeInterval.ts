export async function buildJsTimeInterval(dotNetObject: any): Promise<any> {
    let { buildJsTimeIntervalGenerated } = await import('./timeInterval.gb');
    return await buildJsTimeIntervalGenerated(dotNetObject);
}     

export async function buildDotNetTimeInterval(jsObject: any): Promise<any> {
    return {
        unit: jsObject.unit,
        value: jsObject.value
    }
}
