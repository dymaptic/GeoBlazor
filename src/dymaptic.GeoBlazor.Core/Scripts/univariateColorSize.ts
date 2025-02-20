// override generated code in this file
import UnivariateColorSizeGenerated from './univariateColorSize.gb';
import univariateColorSize = __esri.univariateColorSize;

export default class UnivariateColorSizeWrapper extends UnivariateColorSizeGenerated {

    constructor(component: univariateColorSize) {
        super(component);
    }

}

export async function buildJsUnivariateColorSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUnivariateColorSizeGenerated} = await import('./univariateColorSize.gb');
    return await buildJsUnivariateColorSizeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUnivariateColorSize(jsObject: any): Promise<any> {
    let {buildDotNetUnivariateColorSizeGenerated} = await import('./univariateColorSize.gb');
    return await buildDotNetUnivariateColorSizeGenerated(jsObject);
}
