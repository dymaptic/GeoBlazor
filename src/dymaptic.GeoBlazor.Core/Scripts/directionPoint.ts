// override generated code in this file
import DirectionPointGenerated from './directionPoint.gb';
import DirectionPoint from '@arcgis/core/rest/support/DirectionPoint';

export default class DirectionPointWrapper extends DirectionPointGenerated {

    constructor(component: DirectionPoint) {
        super(component);
    }

}

export async function buildJsDirectionPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDirectionPointGenerated} = await import('./directionPoint.gb');
    return await buildJsDirectionPointGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDirectionPoint(jsObject: any): Promise<any> {
    let {buildDotNetDirectionPointGenerated} = await import('./directionPoint.gb');
    return await buildDotNetDirectionPointGenerated(jsObject);
}
