// override generated code in this file
import MultipointDrawActionGenerated from './multipointDrawAction.gb';
import MultipointDrawAction = __esri.MultipointDrawAction;

export default class MultipointDrawActionWrapper extends MultipointDrawActionGenerated {

    constructor(component: MultipointDrawAction) {
        super(component);
    }

}

export async function buildJsMultipointDrawAction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMultipointDrawActionGenerated} = await import('./multipointDrawAction.gb');
    return await buildJsMultipointDrawActionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMultipointDrawAction(jsObject: any): Promise<any> {
    let {buildDotNetMultipointDrawActionGenerated} = await import('./multipointDrawAction.gb');
    return await buildDotNetMultipointDrawActionGenerated(jsObject);
}
