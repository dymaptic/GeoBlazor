// override generated code in this file
import DOMContainerGenerated from './dOMContainer.gb';
import DOMContainer = __esri.DOMContainer;

export default class DOMContainerWrapper extends DOMContainerGenerated {

    constructor(component: DOMContainer) {
        super(component);
    }
    
}

export async function buildJsDOMContainer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDOMContainerGenerated } = await import('./dOMContainer.gb');
    return await buildJsDOMContainerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDOMContainer(jsObject: any): Promise<any> {
    let { buildDotNetDOMContainerGenerated } = await import('./dOMContainer.gb');
    return await buildDotNetDOMContainerGenerated(jsObject);
}
