// override generated code in this file
import MultidimensionalSubsetGenerated from './multidimensionalSubset.gb';
import MultidimensionalSubset from '@arcgis/core/layers/support/MultidimensionalSubset';

export default class MultidimensionalSubsetWrapper extends MultidimensionalSubsetGenerated {

    constructor(component: MultidimensionalSubset) {
        super(component);
    }
    
}              
export async function buildJsMultidimensionalSubset(dotNetObject: any): Promise<any> {
    let { buildJsMultidimensionalSubsetGenerated } = await import('./multidimensionalSubset.gb');
    return await buildJsMultidimensionalSubsetGenerated(dotNetObject);
}
export async function buildDotNetMultidimensionalSubset(jsObject: any): Promise<any> {
    let { buildDotNetMultidimensionalSubsetGenerated } = await import('./multidimensionalSubset.gb');
    return await buildDotNetMultidimensionalSubsetGenerated(jsObject);
}
