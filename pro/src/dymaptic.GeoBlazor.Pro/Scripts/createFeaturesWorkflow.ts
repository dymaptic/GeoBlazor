import CreateFeaturesWorkflow from '@arcgis/core/widgets/Editor/CreateFeaturesWorkflow';
import CreateFeaturesWorkflowGenerated from './createFeaturesWorkflow.gb';
import {hasValue} from './geoBlazorCore';

export default class CreateFeaturesWorkflowWrapper extends CreateFeaturesWorkflowGenerated {

    constructor(component: CreateFeaturesWorkflow) {
        super(component);
    }
    
    async getPendingFeatures(): Promise<any> {
        if (!hasValue(this.component.pendingFeatures)) {
            return null;
        }

        let { buildDotNetGraphic } = await import('./graphic');
        // typescript definition is wrong, this is a Collection<Graphic> not Collection<GraphicsLayer>
        return this.component.pendingFeatures!.map(i => buildDotNetGraphic(i as any, this.layerId, this.viewId));
    }

}

export async function buildJsCreateFeaturesWorkflow(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCreateFeaturesWorkflowGenerated} = await import('./createFeaturesWorkflow.gb');
    return await buildJsCreateFeaturesWorkflowGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCreateFeaturesWorkflow(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetCreateFeaturesWorkflowGenerated} = await import('./createFeaturesWorkflow.gb');
    return await buildDotNetCreateFeaturesWorkflowGenerated(jsObject, layerId, viewId);
}
