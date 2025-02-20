// override generated code in this file
import NavigationToggleWidgetGenerated from './navigationToggleWidget.gb';
import NavigationToggle from '@arcgis/core/widgets/NavigationToggle';

export default class NavigationToggleWidgetWrapper extends NavigationToggleWidgetGenerated {

    constructor(widget: NavigationToggle) {
        super(widget);
    }

}

export async function buildJsNavigationToggleWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsNavigationToggleWidgetGenerated} = await import('./navigationToggleWidget.gb');
    return await buildJsNavigationToggleWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetNavigationToggleWidget(jsObject: any): Promise<any> {
    let {buildDotNetNavigationToggleWidgetGenerated} = await import('./navigationToggleWidget.gb');
    return await buildDotNetNavigationToggleWidgetGenerated(jsObject);
}
