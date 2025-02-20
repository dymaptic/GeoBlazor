// override generated code in this file
import AgeUtilsGenerated from './ageUtils.gb';
import ageUtils = __esri.ageUtils;

export default class AgeUtilsWrapper extends AgeUtilsGenerated {

    constructor(component: ageUtils) {
        super(component);
    }

}

export async function buildJsAgeUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAgeUtilsGenerated} = await import('./ageUtils.gb');
    return await buildJsAgeUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAgeUtils(jsObject: any): Promise<any> {
    let {buildDotNetAgeUtilsGenerated} = await import('./ageUtils.gb');
    return await buildDotNetAgeUtilsGenerated(jsObject);
}
