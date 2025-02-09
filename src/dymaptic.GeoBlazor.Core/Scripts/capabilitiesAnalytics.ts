// override generated code in this file
import CapabilitiesAnalyticsGenerated from './capabilitiesAnalytics.gb';
import CapabilitiesAnalytics = __esri.CapabilitiesAnalytics;

export default class CapabilitiesAnalyticsWrapper extends CapabilitiesAnalyticsGenerated {

    constructor(component: CapabilitiesAnalytics) {
        super(component);
    }
    
}              
export async function buildJsCapabilitiesAnalytics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildJsCapabilitiesAnalyticsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCapabilitiesAnalytics(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesAnalyticsGenerated } = await import('./capabilitiesAnalytics.gb');
    return await buildDotNetCapabilitiesAnalyticsGenerated(jsObject);
}
