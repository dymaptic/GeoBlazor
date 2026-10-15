// override generated code in this file
import CoordinateConversionViewModelGenerated from './coordinateConversionViewModel.gb';
import CoordinateConversionViewModel from '@arcgis/core/widgets/CoordinateConversion/CoordinateConversionViewModel';

export default class CoordinateConversionViewModelWrapper extends CoordinateConversionViewModelGenerated {

    constructor(component: CoordinateConversionViewModel) {
        super(component);
    }
    
}

export async function buildJsCoordinateConversionViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoordinateConversionViewModelGenerated } = await import('./coordinateConversionViewModel.gb');
    return await buildJsCoordinateConversionViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoordinateConversionViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCoordinateConversionViewModelGenerated } = await import('./coordinateConversionViewModel.gb');
    return await buildDotNetCoordinateConversionViewModelGenerated(jsObject, layerId, viewId);
}
