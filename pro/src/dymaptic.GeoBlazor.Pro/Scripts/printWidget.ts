// override generated code in this file
import PrintWidgetGenerated from './printWidget.gb';
import Print from '@arcgis/core/widgets/Print';
import {buildJsStreamReference, hasValue} from './geoBlazorCore';

export default class PrintWidgetWrapper extends PrintWidgetGenerated {

    constructor(widget: Print) {
        super(widget);
    }
    
    async setTemplateOptions(templateOptions: any): Promise<void> {
        let { buildJsTemplateOptions } = await import('./templateOptions');
        let jsTemplateOptions = await buildJsTemplateOptions(templateOptions, this.layerId, this.viewId);
        this.widget.templateOptions = jsTemplateOptions;
    }
    
    async getTemplateOptions(): Promise<any> {
        let { buildDotNetTemplateOptions } = await import('./templateOptions');
        return await buildDotNetTemplateOptions(this.widget.templateOptions, this.layerId, this.viewId);
    }
}

export async function buildJsPrintWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPrintWidgetGenerated } = await import('./printWidget.gb');
    let jsPrint = await buildJsPrintWidgetGenerated(dotNetObject, layerId, viewId);

    if (hasValue(dotNetObject.hasCompleteListener) && dotNetObject.hasCompleteListener) {
        jsPrint.on('complete', async (evt: any) => {
            let dnEvent = await buildDotNetPrintEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComplete', streamRef);
        });
    }

    if (hasValue(dotNetObject.hasSubmitListener) && dotNetObject.hasSubmitListener) {
        jsPrint.on('submit', async (evt: any) => {
            let dnEvent = await buildDotNetPrintEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSubmit', streamRef);
        });
    }
    
    return jsPrint;
}

async function buildDotNetPrintEvent(evt: any, layerId: string | null, viewId: string | null): Promise<any> {
    let portalItem: any | null = null;
    if (hasValue(evt.link?.portalItem)) {
        let { buildJsPortalItem } = await import('./portalItem');
        portalItem = await buildJsPortalItem(evt.link.portalItem, layerId, viewId);
    }
    return {
        link: {
            count: evt.link?.count,
            error: evt.link?.error,
            extension: evt.link?.extension,
            formattedName: evt.link?.formattedName,
            name: evt.link?.name,
            portalItem: portalItem,
            state: evt.link?.state,
            url: evt.link?.url
        },
        saveExportEnabled: evt.saveExportEnabled
    }
}

export async function buildDotNetPrintWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPrintWidgetGenerated } = await import('./printWidget.gb');
    return await buildDotNetPrintWidgetGenerated(jsObject, layerId, viewId);
}
