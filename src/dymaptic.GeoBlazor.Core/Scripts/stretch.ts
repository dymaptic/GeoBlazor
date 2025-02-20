// override generated code in this file
import StretchGenerated from './stretch.gb';
import stretch = __esri.stretch;

export default class StretchWrapper extends StretchGenerated {

    constructor(component: stretch) {
        super(component);
    }

}

export async function buildJsStretch(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsStretchGenerated} = await import('./stretch.gb');
    return await buildJsStretchGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetStretch(jsObject: any): Promise<any> {
    let {buildDotNetStretchGenerated} = await import('./stretch.gb');
    return await buildDotNetStretchGenerated(jsObject);
}
