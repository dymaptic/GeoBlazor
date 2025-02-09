// override generated code in this file
import RelationshipPopupContentGenerated from './relationshipPopupContent.gb';
import RelationshipContent = __esri.RelationshipContent;

export default class RelationshipPopupContentWrapper extends RelationshipPopupContentGenerated {

    constructor(component: RelationshipContent) {
        super(component);
    }
    
}

export async function buildJsRelationshipPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipPopupContentGenerated } = await import('./relationshipPopupContent.gb');
    return await buildJsRelationshipPopupContentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipPopupContentGenerated } = await import('./relationshipPopupContent.gb');
    return await buildDotNetRelationshipPopupContentGenerated(jsObject);
}
