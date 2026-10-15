
export async function buildJsSelectionTools(dotNetObject: any): Promise<any> {
    return {
        "rectangle-selection": dotNetObject.rectangleSelection,
        "lasso-selection": dotNetObject.lassoSelection
    };
}     

export async function buildDotNetSelectionTools(jsObject: any): Promise<any> {
    return {
        rectangleSelection: jsObject["rectangle-selection"],
        lassoSelection: jsObject["lasso-selection"]
    }
}
