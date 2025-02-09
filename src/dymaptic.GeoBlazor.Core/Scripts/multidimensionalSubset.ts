// override generated code in this file
import MultidimensionalSubsetGenerated from './multidimensionalSubset.gb';
import MultidimensionalSubset from '@arcgis/core/layers/support/MultidimensionalSubset';

export default class MultidimensionalSubsetWrapper extends MultidimensionalSubsetGenerated {

    constructor(component: MultidimensionalSubset) {
        super(component);
    }
    
}              
export async function buildJsMultidimensionalSubset(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultidimensionalSubsetGenerated } = await import('./multidimensionalSubset.gb');
    return await buildJsMultidimensionalSubsetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMultidimensionalSubset(jsObject: any): Promise<any> {
    let { buildDotNetMultidimensionalSubsetGenerated } = await import('./multidimensionalSubset.gb');
    return await buildDotNetMultidimensionalSubsetGenerated(jsObject);
}
