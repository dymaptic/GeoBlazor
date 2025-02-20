export async function buildJsGeotriggersInfoFeatureFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeotriggersInfoFeatureFilterGenerated} = await import('./geotriggersInfoFeatureFilter.gb');
    return await buildJsGeotriggersInfoFeatureFilterGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeotriggersInfoFeatureFilter(jsObject: any): Promise<any> {
    let {buildDotNetGeotriggersInfoFeatureFilterGenerated} = await import('./geotriggersInfoFeatureFilter.gb');
    return await buildDotNetGeotriggersInfoFeatureFilterGenerated(jsObject);
}
