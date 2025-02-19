// override generated code in this file
import NavigationToggleViewModelGenerated from './navigationToggleViewModel.gb';
import NavigationToggleViewModel from '@arcgis/core/widgets/NavigationToggle/NavigationToggleViewModel';

export default class NavigationToggleViewModelWrapper extends NavigationToggleViewModelGenerated {

    constructor(component: NavigationToggleViewModel) {
        super(component);
    }
    
}

export async function buildJsNavigationToggleViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNavigationToggleViewModelGenerated } = await import('./navigationToggleViewModel.gb');
    return await buildJsNavigationToggleViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNavigationToggleViewModel(jsObject: any): Promise<any> {
    let { buildDotNetNavigationToggleViewModelGenerated } = await import('./navigationToggleViewModel.gb');
    return await buildDotNetNavigationToggleViewModelGenerated(jsObject);
}
