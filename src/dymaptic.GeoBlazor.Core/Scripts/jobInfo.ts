// override generated code in this file
import JobInfoGenerated from './jobInfo.gb';
import JobInfo from '@arcgis/core/rest/support/JobInfo';

export default class JobInfoWrapper extends JobInfoGenerated {

    constructor(component: JobInfo) {
        super(component);
    }

}

export async function buildJsJobInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsJobInfoGenerated} = await import('./jobInfo.gb');
    return await buildJsJobInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetJobInfo(jsObject: any): Promise<any> {
    let {buildDotNetJobInfoGenerated} = await import('./jobInfo.gb');
    return await buildDotNetJobInfoGenerated(jsObject);
}
