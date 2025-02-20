import symbologyColor = __esri.symbologyColor;
import SymbologyColorGenerated from './symbologyColor.gb';

export default class SymbologyColorWrapper extends SymbologyColorGenerated {

    constructor(component: symbologyColor) {
        super(component);
    }

}

export async function buildJsSymbologyColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbologyColorGenerated} = await import('./symbologyColor.gb');
    return await buildJsSymbologyColorGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbologyColor(jsObject: any): Promise<any> {
    let {buildDotNetSymbologyColorGenerated} = await import('./symbologyColor.gb');
    return await buildDotNetSymbologyColorGenerated(jsObject);
}
