// override generated code in this file
import FeatureViewModelGenerated from './featureViewModel.gb';
import FeatureViewModel from '@arcgis/core/widgets/Feature/FeatureViewModel';

export default class FeatureViewModelWrapper extends FeatureViewModelGenerated {

    constructor(component: FeatureViewModel) {
        super(component);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.component.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

export async function buildJsFeatureViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureViewModelGenerated } = await import('./featureViewModel.gb');
    return await buildJsFeatureViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureViewModelGenerated } = await import('./featureViewModel.gb');
    return await buildDotNetFeatureViewModelGenerated(jsObject, layerId, viewId);
}
