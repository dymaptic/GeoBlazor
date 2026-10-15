import { buildDotNetAttachmentsColumnGenerated } from './attachmentsColumn.gb';

export function buildDotNetAttachmentsColumn(jsObject: any): any {
    return buildDotNetAttachmentsColumnGenerated(jsObject);
}

export async function buildJsAttachmentsColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttachmentsColumnGenerated } = await import('./attachmentsColumn.gb');
    return await buildJsAttachmentsColumnGenerated(dotNetObject, layerId, viewId);
}
