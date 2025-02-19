// override generated code in this file
import CoverageInfoGenerated from './coverageInfo.gb';
import CoverageInfo = __esri.CoverageInfo;

export default class CoverageInfoWrapper extends CoverageInfoGenerated {

    constructor(component: CoverageInfo) {
        super(component);
    }
    
}              
export async function buildJsCoverageInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoverageInfoGenerated } = await import('./coverageInfo.gb');
    return await buildJsCoverageInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetCoverageInfo(jsObject: any): Promise<any> {
    let { buildDotNetCoverageInfoGenerated } = await import('./coverageInfo.gb');
    return await buildDotNetCoverageInfoGenerated(jsObject);
}
