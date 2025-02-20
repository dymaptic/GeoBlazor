// override generated code in this file
import SvgUtilsGenerated from './svgUtils.gb';
import svgUtils = __esri.svgUtils;

export default class SvgUtilsWrapper extends SvgUtilsGenerated {

    constructor(component: svgUtils) {
        super(component);
    }

}

export async function buildJsSvgUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSvgUtilsGenerated} = await import('./svgUtils.gb');
    return await buildJsSvgUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSvgUtils(jsObject: any): Promise<any> {
    let {buildDotNetSvgUtilsGenerated} = await import('./svgUtils.gb');
    return await buildDotNetSvgUtilsGenerated(jsObject);
}
