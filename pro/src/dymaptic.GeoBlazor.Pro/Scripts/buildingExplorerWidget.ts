// override generated code in this file
import BuildingExplorerWidgetGenerated from './buildingExplorerWidget.gb';
import BuildingExplorer from '@arcgis/core/widgets/BuildingExplorer';

export default class BuildingExplorerWidgetWrapper extends BuildingExplorerWidgetGenerated {

    constructor(widget: BuildingExplorer) {
        super(widget);
    }
    
}

export async function buildJsBuildingExplorerWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingExplorerWidgetGenerated } = await import('./buildingExplorerWidget.gb');
    return await buildJsBuildingExplorerWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingExplorerWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBuildingExplorerWidgetGenerated } = await import('./buildingExplorerWidget.gb');
    return await buildDotNetBuildingExplorerWidgetGenerated(jsObject, layerId, viewId);
}
