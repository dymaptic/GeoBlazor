// override generated code in this file
import ShowTooltipAndFocusFieldOptionsGenerated from './showTooltipAndFocusFieldOptions.gb';
import ShowTooltipAndFocusFieldOptions = __esri.ShowTooltipAndFocusFieldOptions;

export default class ShowTooltipAndFocusFieldOptionsWrapper extends ShowTooltipAndFocusFieldOptionsGenerated {

    constructor(component: ShowTooltipAndFocusFieldOptions) {
        super(component);
    }
    
}

export async function buildJsShowTooltipAndFocusFieldOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShowTooltipAndFocusFieldOptionsGenerated } = await import('./showTooltipAndFocusFieldOptions.gb');
    return await buildJsShowTooltipAndFocusFieldOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShowTooltipAndFocusFieldOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetShowTooltipAndFocusFieldOptionsGenerated } = await import('./showTooltipAndFocusFieldOptions.gb');
    return await buildDotNetShowTooltipAndFocusFieldOptionsGenerated(jsObject, layerId, viewId);
}
