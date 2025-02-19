
export async function buildJsColorRampsCreateColorRampOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorRampsCreateColorRampOptionsGenerated } = await import('./colorRampsCreateColorRampOptions.gb');
    return await buildJsColorRampsCreateColorRampOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorRampsCreateColorRampOptions(jsObject: any): Promise<any> {
    let { buildDotNetColorRampsCreateColorRampOptionsGenerated } = await import('./colorRampsCreateColorRampOptions.gb');
    return await buildDotNetColorRampsCreateColorRampOptionsGenerated(jsObject);
}
