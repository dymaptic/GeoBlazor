import ListItemGenerated from './listItem.gb';
import {arcGisObjectRefs, copyValuesIfExists, hasValue, lookupGeoBlazorId} from "./arcGisJsInterop";
import ListItem from "@arcgis/core/widgets/LayerList/ListItem";
import {DotNetListItem} from "./definitions";
import Layer from "@arcgis/core/layers/Layer";
import ListItemPanel from "@arcgis/core/widgets/LayerList/ListItemPanel";
import Widget from "@arcgis/core/widgets/Widget";

export default class ListItemWrapper extends ListItemGenerated {
    
    constructor(component: any) {
        super(component);
    }
    
    async setPanel(panel: any): Promise<void> {
        let { buildJsListItemPanelWidget } = await import('./listItemPanelWidget');
        let jsPanel = await buildJsListItemPanelWidget(panel, this.layerId, this.viewId);
        this.component.panel = jsPanel;
    }
}

export async function buildJsListItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsListItemGenerated} = await import('./listItem.gb');
    return await buildJsListItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetListItem(jsObject: any): Promise<any> {
    let {buildDotNetListItemGenerated} = await import('./listItem.gb');
    let listItem = await buildDotNetListItemGenerated(jsObject);
    listItem.layerId = lookupGeoBlazorId(jsObject.layer);
    return listItem;
}

export async function updateListItem(jsItem: ListItem, dnItem: DotNetListItem, layerId, viewId) {
    copyValuesIfExists(dnItem, jsItem, 'title', 'visible', 'childrenSortable', 'hidden',
        'open', 'sortable');

    if (hasValue(dnItem.children)) {
        for (let i = 0; i < dnItem.children.length; i++) {
            const child = dnItem.children[i];
            const jsChild = jsItem.children[i];
            if (hasValue(child) && hasValue(jsChild)) {
                await updateListItem(jsChild, child, layerId, viewId);
            }
        }
    }
    if (hasValue(dnItem.actionsSections)) {
        const actionsSections: any[] = [];
        let {buildJsActionBase} = await import('./actionBase');
        for (let i = 0; i < dnItem.actionsSections.length; i++) {
            const section: any[] = [];
            actionsSections.push(section);
            const dnSection = dnItem.actionsSections[i];
            for (let j = 0; j < dnSection.length; j++) {
                const dnAction = dnSection[j];
                const action = await buildJsActionBase(dnAction);
                section.push(action);
            }
        }
        jsItem.actionsSections = actionsSections as any;
    }

    if (hasValue(dnItem.layerId)) {
        jsItem.layer = arcGisObjectRefs[dnItem.layerId] as Layer;
    }

    if (hasValue(dnItem.panel)) {
        let { buildJsListItemPanelWidget } = await import('./listItemPanelWidget');
        let jsPanel = await buildJsListItemPanelWidget(dnItem.panel, layerId, viewId);
        jsItem.panel = jsPanel;
    }
}
