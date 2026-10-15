// override generated code in this file
import RelationshipRendererGeneratorGenerated from './relationshipRendererGenerator.gb';
import relationship = __esri.relationship;

export default class RelationshipRendererGeneratorWrapper extends RelationshipRendererGeneratorGenerated {

    constructor(component: relationship) {
        super(component);
    }
    
}

export async function buildJsRelationshipRendererGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipRendererGeneratorGenerated } = await import('./relationshipRendererGenerator.gb');
    return await buildJsRelationshipRendererGeneratorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipRendererGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipRendererGeneratorGenerated } = await import('./relationshipRendererGenerator.gb');
    return await buildDotNetRelationshipRendererGeneratorGenerated(jsObject, layerId, viewId);
}
