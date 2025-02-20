// override generated code in this file
import PointBarrierGenerated from './pointBarrier.gb';
import PointBarrier from '@arcgis/core/rest/support/PointBarrier';

export default class PointBarrierWrapper extends PointBarrierGenerated {

    constructor(component: PointBarrier) {
        super(component);
    }

}

export async function buildJsPointBarrier(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPointBarrierGenerated} = await import('./pointBarrier.gb');
    return await buildJsPointBarrierGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPointBarrier(jsObject: any): Promise<any> {
    let {buildDotNetPointBarrierGenerated} = await import('./pointBarrier.gb');
    return await buildDotNetPointBarrierGenerated(jsObject);
}
