// override generated code in this file
import LinkChartLayoutSwitcherViewModelGenerated from './linkChartLayoutSwitcherViewModel.gb';
import LinkChartLayoutSwitcherViewModel from '@arcgis/core/widgets/LinkChartLayoutSwitcher/LinkChartLayoutSwitcherViewModel';

export default class LinkChartLayoutSwitcherViewModelWrapper extends LinkChartLayoutSwitcherViewModelGenerated {

    constructor(component: LinkChartLayoutSwitcherViewModel) {
        super(component);
    }
    
}

export async function buildJsLinkChartLayoutSwitcherViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLinkChartLayoutSwitcherViewModelGenerated } = await import('./linkChartLayoutSwitcherViewModel.gb');
    return await buildJsLinkChartLayoutSwitcherViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLinkChartLayoutSwitcherViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLinkChartLayoutSwitcherViewModelGenerated } = await import('./linkChartLayoutSwitcherViewModel.gb');
    return await buildDotNetLinkChartLayoutSwitcherViewModelGenerated(jsObject, viewId);
}
