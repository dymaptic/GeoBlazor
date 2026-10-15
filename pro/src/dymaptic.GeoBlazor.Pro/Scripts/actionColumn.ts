import { buildJsActionColumnGenerated } from './actionColumn.gb';
import { buildDotNetActionColumnGenerated } from './actionColumn.gb';

export function buildDotNetActionColumn(jsObject: any): any {
    return buildDotNetActionColumnGenerated(jsObject);
}

export function buildJsActionColumn(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    return buildJsActionColumnGenerated(dotNetObject, layerId, viewId);
}
