// override generated code in this file
import TimeInfoGenerated from './timeInfo.gb';
import TimeInfo from '@arcgis/core/layers/support/TimeInfo';

export default class TimeInfoWrapper extends TimeInfoGenerated {

    constructor(component: TimeInfo) {
        super(component);
    }
    
}              
export async function buildJsTimeInfo(dotNetObject: any): Promise<any> {
    let { buildJsTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildJsTimeInfoGenerated(dotNetObject);
}
export async function buildDotNetTimeInfo(jsObject: any): Promise<any> {
    let { buildDotNetTimeInfoGenerated } = await import('./timeInfo.gb');
    return await buildDotNetTimeInfoGenerated(jsObject);
}
