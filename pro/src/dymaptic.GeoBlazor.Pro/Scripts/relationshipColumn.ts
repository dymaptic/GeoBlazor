import RelationshipColumn from '@arcgis/core/widgets/FeatureTable/RelationshipColumn';
import RelationshipColumnGenerated from './relationshipColumn.gb';

export async function buildJsRelationshipColumn(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipColumnGenerated } = await import('./relationshipColumn.gb');
    return await buildJsRelationshipColumnGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipColumn(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipColumnGenerated } = await import('./relationshipColumn.gb');
    return await buildDotNetRelationshipColumnGenerated(jsObject, layerId, viewId);
}

export default class RelationshipColumnWrapper extends RelationshipColumnGenerated {

    constructor(component: RelationshipColumn) {
        super(component);
    }
    
}

