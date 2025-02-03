// override generated code in this file
import AuthoringInfoStatisticsGenerated from './authoringInfoStatistics.gb';
import AuthoringInfoStatistics = __esri.AuthoringInfoStatistics;

export default class AuthoringInfoStatisticsWrapper extends AuthoringInfoStatisticsGenerated {

    constructor(component: AuthoringInfoStatistics) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfoStatistics(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildJsAuthoringInfoStatisticsGenerated(dotNetObject);
}
export async function buildDotNetAuthoringInfoStatistics(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoStatisticsGenerated } = await import('./authoringInfoStatistics.gb');
    return await buildDotNetAuthoringInfoStatisticsGenerated(jsObject);
}
