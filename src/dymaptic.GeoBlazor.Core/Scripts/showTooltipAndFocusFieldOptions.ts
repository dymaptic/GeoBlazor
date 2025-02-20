import ShowTooltipAndFocusFieldOptions = __esri.ShowTooltipAndFocusFieldOptions;
import ShowTooltipAndFocusFieldOptionsGenerated from './showTooltipAndFocusFieldOptions.gb';

export default class ShowTooltipAndFocusFieldOptionsWrapper extends ShowTooltipAndFocusFieldOptionsGenerated {

    constructor(component: ShowTooltipAndFocusFieldOptions) {
        super(component);
    }

}

export async function buildJsShowTooltipAndFocusFieldOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsShowTooltipAndFocusFieldOptionsGenerated} = await import('./showTooltipAndFocusFieldOptions.gb');
    return await buildJsShowTooltipAndFocusFieldOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetShowTooltipAndFocusFieldOptions(jsObject: any): Promise<any> {
    let {buildDotNetShowTooltipAndFocusFieldOptionsGenerated} = await import('./showTooltipAndFocusFieldOptions.gb');
    return await buildDotNetShowTooltipAndFocusFieldOptionsGenerated(jsObject);
}
