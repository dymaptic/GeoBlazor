import TableMenuItemConfig = __esri.TableMenuItemConfig;
import TableMenuItemConfigGenerated from './tableMenuItemConfig.gb';

export default class TableMenuItemConfigWrapper extends TableMenuItemConfigGenerated {

    constructor(component: TableMenuItemConfig) {
        super(component);
    }
    
}

export async function buildJsTableMenuItemConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableMenuItemConfigGenerated } = await import('./tableMenuItemConfig.gb');
    return await buildJsTableMenuItemConfigGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTableMenuItemConfig(jsObject: any): Promise<any> {
    let { buildDotNetTableMenuItemConfigGenerated } = await import('./tableMenuItemConfig.gb');
    return await buildDotNetTableMenuItemConfigGenerated(jsObject);
}
