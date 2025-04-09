// override generated code in this file
import GridControlsViewModelGenerated from './gridControlsViewModel.gb';
import GridControlsViewModel from '@arcgis/core/widgets/support/GridControls/GridControlsViewModel';

export default class GridControlsViewModelWrapper extends GridControlsViewModelGenerated {

    constructor(component: GridControlsViewModel) {
        super(component);
    }
    
}

export async function buildJsGridControlsViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGridControlsViewModelGenerated } = await import('./gridControlsViewModel.gb');
    return await buildJsGridControlsViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGridControlsViewModel(jsObject: any): Promise<any> {
    let { buildDotNetGridControlsViewModelGenerated } = await import('./gridControlsViewModel.gb');
    return await buildDotNetGridControlsViewModelGenerated(jsObject);
}
