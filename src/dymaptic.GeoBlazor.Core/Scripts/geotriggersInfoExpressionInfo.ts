
export async function buildJsGeotriggersInfoExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeotriggersInfoExpressionInfoGenerated } = await import('./geotriggersInfoExpressionInfo.gb');
    return await buildJsGeotriggersInfoExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeotriggersInfoExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGeotriggersInfoExpressionInfoGenerated } = await import('./geotriggersInfoExpressionInfo.gb');
    return await buildDotNetGeotriggersInfoExpressionInfoGenerated(jsObject, layerId, viewId);
}
