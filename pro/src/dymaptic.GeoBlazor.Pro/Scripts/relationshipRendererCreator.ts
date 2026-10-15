// override generated code in this file
import RelationshipRendererCreatorGenerated from './relationshipRendererCreator.gb';
import relationship = __esri.relationship;

export default class RelationshipRendererCreatorWrapper extends RelationshipRendererCreatorGenerated {

    constructor(component: relationship) {
        super(component);
    }

}

export async function buildJsRelationshipRendererCreator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRelationshipRendererCreatorGenerated} = await import('./relationshipRendererCreator.gb');
    return await buildJsRelationshipRendererCreatorGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRelationshipRendererCreator(jsObject: any): Promise<any> {
    let {buildDotNetRelationshipRendererCreatorGenerated} = await import('./relationshipRendererCreator.gb');
    return await buildDotNetRelationshipRendererCreatorGenerated(jsObject);
}
