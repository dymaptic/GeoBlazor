// override generated code in this file
import KnowledgeGraphServiceGenerated from './knowledgeGraphService.gb';
import knowledgeGraphService = __esri.knowledgeGraphService;

export default class KnowledgeGraphServiceWrapper extends KnowledgeGraphServiceGenerated {

    constructor(component: knowledgeGraphService) {
        super(component);
    }
    
}

export async function buildJsKnowledgeGraphService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsKnowledgeGraphServiceGenerated } = await import('./knowledgeGraphService.gb');
    return await buildJsKnowledgeGraphServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetKnowledgeGraphService(jsObject: any): Promise<any> {
    let { buildDotNetKnowledgeGraphServiceGenerated } = await import('./knowledgeGraphService.gb');
    return await buildDotNetKnowledgeGraphServiceGenerated(jsObject);
}
