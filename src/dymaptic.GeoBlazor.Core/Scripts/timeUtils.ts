// override generated code in this file
import TimeUtilsGenerated from './timeUtils.gb';
import timeUtils = __esri.timeUtils;

export default class TimeUtilsWrapper extends TimeUtilsGenerated {

    constructor(component: timeUtils) {
        super(component);
    }

}

export async function buildJsTimeUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTimeUtilsGenerated} = await import('./timeUtils.gb');
    return await buildJsTimeUtilsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTimeUtils(jsObject: any): Promise<any> {
    let {buildDotNetTimeUtilsGenerated} = await import('./timeUtils.gb');
    return await buildDotNetTimeUtilsGenerated(jsObject);
}
