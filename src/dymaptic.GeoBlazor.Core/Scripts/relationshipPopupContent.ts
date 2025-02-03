// override generated code in this file
import RelationshipPopupContentGenerated from './relationshipPopupContent.gb';
import RelationshipContent = __esri.RelationshipContent;

export default class RelationshipPopupContentWrapper extends RelationshipPopupContentGenerated {

    constructor(component: RelationshipContent) {
        super(component);
    }
    
}

export async function buildJsRelationshipPopupContent(dotNetObject: any): Promise<any> {
    let { buildJsRelationshipPopupContentGenerated } = await import('./relationshipPopupContent.gb');
    return await buildJsRelationshipPopupContentGenerated(dotNetObject);
}     

export async function buildDotNetRelationshipPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipPopupContentGenerated } = await import('./relationshipPopupContent.gb');
    return await buildDotNetRelationshipPopupContentGenerated(jsObject);
}
