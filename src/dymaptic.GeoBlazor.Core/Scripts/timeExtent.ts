// override generated code in this file
import TimeExtentGenerated from './timeExtent.gb';
import TimeExtent from '@arcgis/core/TimeExtent';

export default class TimeExtentWrapper extends TimeExtentGenerated {

    constructor(component: TimeExtent) {
        super(component);
    }
    
}              
export async function buildJsTimeExtent(dotNetObject: any): Promise<any> {
    let { buildJsTimeExtentGenerated } = await import('./timeExtent.gb');
    return await buildJsTimeExtentGenerated(dotNetObject);
}
export async function buildDotNetTimeExtent(jsObject: any): Promise<any> {
    let { buildDotNetTimeExtentGenerated } = await import('./timeExtent.gb');
    return await buildDotNetTimeExtentGenerated(jsObject);
}
