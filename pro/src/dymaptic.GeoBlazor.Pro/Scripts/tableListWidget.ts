import TableList from '@arcgis/core/widgets/TableList';
// override generated code in this file
import TableListWidgetGenerated from './tableListWidget.gb';
import {hasValue} from './geoBlazorCore';

export default class TableListWidgetWrapper extends TableListWidgetGenerated {

    constructor(widget: TableList) {
        super(widget);
    }
    
}

export async function buildJsTableListWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListWidgetGenerated } = await import('./tableListWidget.gb');
    let jsObject = await buildJsTableListWidgetGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.tableItems) && dotNetObject.tableItems.length > 0) {
        jsObject.on('trigger-action', async (evt: any) => {
            for (let i = 0; i < dotNetObject.tableItems.length; i++) {
                let item = dotNetObject.tableItems[i];
                for (let j = 0; j < item.actionsSections.length; j++) {
                    let actionSection = item.actionsSections[j];
                    for (let k = 0; k < actionSection.length; k++) {
                        let dnAction = actionSection[k];
                        if (dnAction.actionId === evt.action.id) {
                            let { buildDotNetPopupTriggerActionEvent } = await import('./popupTriggerActionEvent');
                            let dnEvent = await buildDotNetPopupTriggerActionEvent(evt);
                            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsTriggerAction', dnEvent);
                        }
                    }
                }
            }
        });
    }
    
    return jsObject;
}     

export async function buildDotNetTableListWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTableListWidgetGenerated } = await import('./tableListWidget.gb');
    return await buildDotNetTableListWidgetGenerated(jsObject, layerId, viewId);
}
