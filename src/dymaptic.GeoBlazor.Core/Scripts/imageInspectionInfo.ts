// override generated code in this file

export async function buildJsImageInspectionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageInspectionInfoGenerated} = await import('./imageInspectionInfo.gb');
    return await buildJsImageInspectionInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageInspectionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageInspectionInfoGenerated} = await import('./imageInspectionInfo.gb');
    return await buildDotNetImageInspectionInfoGenerated(jsObject, layerId, viewId);
}
