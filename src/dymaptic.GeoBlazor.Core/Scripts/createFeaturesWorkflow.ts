import CreateFeaturesWorkflow from '@arcgis/core/widgets/Editor/CreateFeaturesWorkflow';
import CreateFeaturesWorkflowGenerated from './createFeaturesWorkflow.gb';

export default class CreateFeaturesWorkflowWrapper extends CreateFeaturesWorkflowGenerated {

    constructor(component: CreateFeaturesWorkflow) {
        super(component);
    }

}

export async function buildJsCreateFeaturesWorkflow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCreateFeaturesWorkflowGenerated} = await import('./createFeaturesWorkflow.gb');
    return await buildJsCreateFeaturesWorkflowGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCreateFeaturesWorkflow(jsObject: any): Promise<any> {
    let {buildDotNetCreateFeaturesWorkflowGenerated} = await import('./createFeaturesWorkflow.gb');
    return await buildDotNetCreateFeaturesWorkflowGenerated(jsObject);
}
