// override generated code in this file
import CircleGenerated from './circle.gb';
import Circle from '@arcgis/core/geometry/Circle';

export default class CircleWrapper extends CircleGenerated {

    constructor(component: Circle) {
        super(component);
    }

}

export async function buildJsCircle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCircleGenerated} = await import('./circle.gb');
    return await buildJsCircleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCircle(jsObject: any): Promise<any> {
    let {buildDotNetCircleGenerated} = await import('./circle.gb');
    return await buildDotNetCircleGenerated(jsObject);
}
