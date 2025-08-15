// override generated code in this file
import SignalGenerated from './signal.gb';
import Signal = __esri.Signal;

export default class SignalWrapper extends SignalGenerated {

    constructor(component: Signal) {
        super(component);
    }
    
}

export async function buildJsSignal(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSignalGenerated } = await import('./signal.gb');
    return await buildJsSignalGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSignal(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSignalGenerated } = await import('./signal.gb');
    return await buildDotNetSignalGenerated(jsObject, viewId);
}
