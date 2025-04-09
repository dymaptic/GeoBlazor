// override generated code in this file
import BufferOperatorGenerated from './bufferOperator.gb';
import bufferOperator = __esri.bufferOperator;

export default class BufferOperatorWrapper extends BufferOperatorGenerated {

    constructor(component: bufferOperator) {
        super(component);
    }
    
}

export async function buildJsBufferOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBufferOperatorGenerated } = await import('./bufferOperator.gb');
    return await buildJsBufferOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBufferOperator(jsObject: any): Promise<any> {
    let { buildDotNetBufferOperatorGenerated } = await import('./bufferOperator.gb');
    return await buildDotNetBufferOperatorGenerated(jsObject);
}
