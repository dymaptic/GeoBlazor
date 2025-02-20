// override generated code in this file
import CoordinateFormatterGenerated from './coordinateFormatter.gb';
import coordinateFormatter = __esri.coordinateFormatter;

export default class CoordinateFormatterWrapper extends CoordinateFormatterGenerated {

    constructor(component: coordinateFormatter) {
        super(component);
    }

}

export async function buildJsCoordinateFormatter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCoordinateFormatterGenerated} = await import('./coordinateFormatter.gb');
    return await buildJsCoordinateFormatterGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCoordinateFormatter(jsObject: any): Promise<any> {
    let {buildDotNetCoordinateFormatterGenerated} = await import('./coordinateFormatter.gb');
    return await buildDotNetCoordinateFormatterGenerated(jsObject);
}
