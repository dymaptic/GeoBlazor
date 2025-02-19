// override generated code in this file
import GroupColumnGenerated from './groupColumn.gb';
import GroupColumn from '@arcgis/core/widgets/FeatureTable/Grid/GroupColumn';

export default class GroupColumnWrapper extends GroupColumnGenerated {

    constructor(component: GroupColumn) {
        super(component);
    }
    
}

export async function buildJsGroupColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupColumnGenerated } = await import('./groupColumn.gb');
    return await buildJsGroupColumnGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupColumn(jsObject: any): Promise<any> {
    let { buildDotNetGroupColumnGenerated } = await import('./groupColumn.gb');
    return await buildDotNetGroupColumnGenerated(jsObject);
}
