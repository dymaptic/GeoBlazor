// override generated code in this file

export async function buildJsActionBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    switch (dotNetObject?.type) {
        case 'button':
            let {buildJsActionButton} = await import('./actionButton');
            return await buildJsActionButton(dotNetObject, layerId, viewId);
        case 'toggle':
            let {buildJsActionToggle} = await import('./actionToggle');
            return await buildJsActionToggle(dotNetObject, layerId, viewId);
        default:
            throw new Error(`Unsupported action type: ${dotNetObject?.type}`);
    }
}

export async function buildDotNetActionBase(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'button':
            let {buildDotNetActionButton} = await import('./actionButton');
            return await buildDotNetActionButton(jsObject);
        case 'toggle':
            let {buildDotNetActionToggle} = await import('./actionToggle');
            return await buildDotNetActionToggle(jsObject);
        default:
            throw new Error(`Unsupported action type: ${jsObject?.type}`);
    }
}
