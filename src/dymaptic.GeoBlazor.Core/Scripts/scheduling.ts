// override generated code in this file
import SchedulingGenerated from './scheduling.gb';
import scheduling = __esri.scheduling;

export default class SchedulingWrapper extends SchedulingGenerated {

    constructor(component: scheduling) {
        super(component);
    }

}

export async function buildJsScheduling(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSchedulingGenerated} = await import('./scheduling.gb');
    return await buildJsSchedulingGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetScheduling(jsObject: any): Promise<any> {
    let {buildDotNetSchedulingGenerated} = await import('./scheduling.gb');
    return await buildDotNetSchedulingGenerated(jsObject);
}
