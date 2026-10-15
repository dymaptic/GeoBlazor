// override generated code in this file

export async function buildJsImagePixelLocationParameters(dotNetObject: any): Promise<any> {
    let {buildJsImagePixelLocationParametersGenerated} = await import('./imagePixelLocationParameters.gb');
    return await buildJsImagePixelLocationParametersGenerated(dotNetObject);
}

export async function buildDotNetImagePixelLocationParameters(jsObject: any): Promise<any> {
    let {buildDotNetImagePixelLocationParametersGenerated} = await import('./imagePixelLocationParameters.gb');
    return await buildDotNetImagePixelLocationParametersGenerated(jsObject);
}
