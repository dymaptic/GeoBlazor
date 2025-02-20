// override generated code in this file
import ColumnGenerated from './column.gb';
import Column from '@arcgis/core/widgets/FeatureTable/Grid/Column';

export default class ColumnWrapper extends ColumnGenerated {

    constructor(component: Column) {
        super(component);
    }

}

export async function buildJsColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColumnGenerated} = await import('./column.gb');
    return await buildJsColumnGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColumn(jsObject: any): Promise<any> {
    let {buildDotNetColumnGenerated} = await import('./column.gb');
    return await buildDotNetColumnGenerated(jsObject);
}
