import uniqueValue = __esri.uniqueValue;
import RasterUniqueValueCreatorGenerated from './rasterUniqueValueCreator.gb';

export default class RasterUniqueValueCreatorWrapper extends RasterUniqueValueCreatorGenerated {

    constructor(component: uniqueValue) {
        super(component);
    }

}

export async function buildJsRasterUniqueValueCreator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterUniqueValueCreatorGenerated} = await import('./rasterUniqueValueCreator.gb');
    return await buildJsRasterUniqueValueCreatorGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterUniqueValueCreator(jsObject: any): Promise<any> {
    let {buildDotNetRasterUniqueValueCreatorGenerated} = await import('./rasterUniqueValueCreator.gb');
    return await buildDotNetRasterUniqueValueCreatorGenerated(jsObject);
}
