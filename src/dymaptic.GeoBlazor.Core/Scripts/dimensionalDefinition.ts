// override generated code in this file
import DimensionalDefinitionGenerated from './dimensionalDefinition.gb';
import DimensionalDefinition from '@arcgis/core/layers/support/DimensionalDefinition';

export default class DimensionalDefinitionWrapper extends DimensionalDefinitionGenerated {

    constructor(component: DimensionalDefinition) {
        super(component);
    }
    
}              
export async function buildJsDimensionalDefinition(dotNetObject: any): Promise<any> {
    let { buildJsDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildJsDimensionalDefinitionGenerated(dotNetObject);
}
export async function buildDotNetDimensionalDefinition(jsObject: any): Promise<any> {
    let { buildDotNetDimensionalDefinitionGenerated } = await import('./dimensionalDefinition.gb');
    return await buildDotNetDimensionalDefinitionGenerated(jsObject);
}
