// override generated code in this file
import RelationshipQueryGenerated from './relationshipQuery.gb';
import RelationshipQuery from '@arcgis/core/rest/support/RelationshipQuery';

export default class RelationshipQueryWrapper extends RelationshipQueryGenerated {

    constructor(component: RelationshipQuery) {
        super(component);
    }
    
}              
export async function buildJsRelationshipQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipQueryGenerated } = await import('./relationshipQuery.gb');
    return await buildJsRelationshipQueryGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationshipQuery(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipQueryGenerated } = await import('./relationshipQuery.gb');
    return await buildDotNetRelationshipQueryGenerated(jsObject);
}
