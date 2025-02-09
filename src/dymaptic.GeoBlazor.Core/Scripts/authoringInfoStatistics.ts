// override generated code in this file
import AuthoringInfoStatisticsGenerated from './authoringInfoStatistics.gb';
import AuthoringInfoStatistics = __esri.AuthoringInfoStatistics;

export default class AuthoringInfoStatisticsWrapper extends AuthoringInfoStatisticsGenerated {

    constructor(component: AuthoringInfoStatistics) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfoStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildJsAuthoringInfoStatisticsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetAuthoringInfoStatistics(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildDotNetAuthoringInfoStatisticsGenerated(jsObject);
}
