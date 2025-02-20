// override generated code in this file
import FieldColumnGenerated from './fieldColumn.gb';
import FieldColumn from '@arcgis/core/widgets/FeatureTable/FieldColumn';

export default class FieldColumnWrapper extends FieldColumnGenerated {

    constructor(component: FieldColumn) {
        super(component);
    }

}

export async function buildJsFieldColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFieldColumnGenerated} = await import('./fieldColumn.gb');
    return await buildJsFieldColumnGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFieldColumn(jsObject: any): Promise<any> {
    let {buildDotNetFieldColumnGenerated} = await import('./fieldColumn.gb');
    return await buildDotNetFieldColumnGenerated(jsObject);
}
