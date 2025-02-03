// override generated code in this file
import AuthoringInfoGenerated from './authoringInfo.gb';
import AuthoringInfo from '@arcgis/core/renderers/support/AuthoringInfo';

export default class AuthoringInfoWrapper extends AuthoringInfoGenerated {

    constructor(component: AuthoringInfo) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfo(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoGenerated } = await import('./authoringInfo.gb');
    return await buildJsAuthoringInfoGenerated(dotNetObject);
}
export async function buildDotNetAuthoringInfo(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoGenerated } = await import('./authoringInfo.gb');
    return await buildDotNetAuthoringInfoGenerated(jsObject);
}
