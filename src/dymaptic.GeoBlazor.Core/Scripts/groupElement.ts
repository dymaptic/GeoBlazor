// override generated code in this file
import GroupElementGenerated from './groupElement.gb';
import GroupElement from '@arcgis/core/form/elements/GroupElement';

export default class GroupElementWrapper extends GroupElementGenerated {

    constructor(component: GroupElement) {
        super(component);
    }
    
}

export async function buildJsGroupElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupElementGenerated } = await import('./groupElement.gb');
    return await buildJsGroupElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupElement(jsObject: any): Promise<any> {
    let { buildDotNetGroupElementGenerated } = await import('./groupElement.gb');
    return await buildDotNetGroupElementGenerated(jsObject);
}
