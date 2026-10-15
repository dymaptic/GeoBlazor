import {hasValue} from './geoBlazorCore';
import {buildJsActionBase} from "./actionBase";

export async function buildJsTableListListItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTableListListItemGenerated} = await import('./tableListListItem.gb');
    let jsObject = await buildJsTableListListItemGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.actionSections)) {
        jsObject.actionsSections = dotNetObject.actionSections.map((actionSection: any) => {
            return actionSection.map(buildJsActionBase);
        });
    }
}

export async function buildDotNetTableListListItem(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetTableListListItemGenerated} = await import('./tableListListItem.gb');
    return await buildDotNetTableListListItemGenerated(jsObject, viewId);
}
