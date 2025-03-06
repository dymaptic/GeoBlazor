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

export async function buildDotNetListItem(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetListItemGenerated} = await import('./listItem.gb');
    let listItem = await buildDotNetListItemGenerated(jsObject, layerId, viewId);
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
                const action = await buildJsActionBase(dnAction, layerId, viewId);
                section.push(action);
            }
        }
        jsItem.actionsSections = actionsSections as any;
    }

    if (hasValue(dnItem.layerId)) {
        jsItem.layer = arcGisObjectRefs[dnItem.layerId] as Layer;
    }

    if (hasValue(dnItem.panel)) {
        if (hasValue(dnItem.panel.containerId)) {
            const contentDiv = document.getElementById(dnItem.panel.containerId);
            if (contentDiv !== null) {
                jsItem.panel = {
                    content: contentDiv,
                    visible: dnItem.panel.visible,
                    className: dnItem.panel.className,
                    disabled: dnItem.panel.disabled,
                    flowEnabled: dnItem.panel.flowEnabled,
                    open: dnItem.panel.open,
                    image: dnItem.panel.image,
                    icon: dnItem.panel.icon,
                    label: dnItem.panel.label
                } as ListItemPanel;
            }
        } else if (hasValue(dnItem.panel.contentWidgetId)) {
            const contentWidget = arcGisObjectRefs[dnItem.panel.contentWidgetId] as Widget;
            jsItem.panel = {
                content: contentWidget,
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        } else if (hasValue(dnItem.panel.stringContent)) {
            jsItem.panel = {
                content: dnItem.panel.stringContent,
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        } else if (hasValue(dnItem.panel.showLegendContent) && dnItem.panel.showLegendContent) {
            jsItem.panel = {
                content: 'legend',
                visible: dnItem.panel.visible,
                className: dnItem.panel.className,
                disabled: dnItem.panel.disabled,
                flowEnabled: dnItem.panel.flowEnabled,
                open: dnItem.panel.open,
                image: dnItem.panel.image,
                icon: dnItem.panel.icon,
                label: dnItem.panel.label
            } as ListItemPanel;
        }
    }
}
