import Workflow from '@arcgis/core/widgets/Editor/Workflow';
import WorkflowGenerated from './workflow.gb';
export async function buildJsWorkflow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWorkflowGenerated } = await import('./workflow.gb');
    return await buildJsWorkflowGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWorkflow(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetWorkflowGenerated} = await import('./workflow.gb');
    return await buildDotNetWorkflowGenerated(jsObject, layerId, viewId);
}

export default class WorkflowWrapper extends WorkflowGenerated {

    constructor(component: Workflow) {
        super(component);
    }
    
}

