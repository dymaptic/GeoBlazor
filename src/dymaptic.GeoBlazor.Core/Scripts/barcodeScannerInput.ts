
export async function buildJsBarcodeScannerInput(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBarcodeScannerInputGenerated } = await import('./barcodeScannerInput.gb');
    return await buildJsBarcodeScannerInputGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBarcodeScannerInput(jsObject: any): Promise<any> {
    let { buildDotNetBarcodeScannerInputGenerated } = await import('./barcodeScannerInput.gb');
    return await buildDotNetBarcodeScannerInputGenerated(jsObject);
}
