// override generated code in this file
import UpdateWorkflowGenerated from './updateWorkflow.gb';
import UpdateWorkflow from '@arcgis/core/widgets/Editor/UpdateWorkflow';

export default class UpdateWorkflowWrapper extends UpdateWorkflowGenerated {

    constructor(component: UpdateWorkflow) {
        super(component);
    }

}

export async function buildJsUpdateWorkflow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUpdateWorkflowGenerated} = await import('./updateWorkflow.gb');
    return await buildJsUpdateWorkflowGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUpdateWorkflow(jsObject: any): Promise<any> {
    let {buildDotNetUpdateWorkflowGenerated} = await import('./updateWorkflow.gb');
    return await buildDotNetUpdateWorkflowGenerated(jsObject);
}
