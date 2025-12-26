
export async function buildJsGeotriggersInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeotriggersInfoGenerated } = await import('./geotriggersInfo.gb');
    return await buildJsGeotriggersInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeotriggersInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetGeotriggersInfoGenerated } = await import('./geotriggersInfo.gb');
    return await buildDotNetGeotriggersInfoGenerated(jsObject, viewId);
}
