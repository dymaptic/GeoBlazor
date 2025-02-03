// override generated code in this file
import GroupElementGenerated from './groupElement.gb';
import GroupElement from '@arcgis/core/form/elements/GroupElement';

export default class GroupElementWrapper extends GroupElementGenerated {

    constructor(component: GroupElement) {
        super(component);
    }
    
}

export async function buildJsGroupElement(dotNetObject: any): Promise<any> {
    let { buildJsGroupElementGenerated } = await import('./groupElement.gb');
    return await buildJsGroupElementGenerated(dotNetObject);
}     

export async function buildDotNetGroupElement(jsObject: any): Promise<any> {
    let { buildDotNetGroupElementGenerated } = await import('./groupElement.gb');
    return await buildDotNetGroupElementGenerated(jsObject);
}
