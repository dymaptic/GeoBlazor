// override generated code in this file
import AuthoringInfoField1ClassBreakInfosGenerated from './authoringInfoField1ClassBreakInfos.gb';
import AuthoringInfoField1ClassBreakInfos = __esri.AuthoringInfoField1ClassBreakInfos;

export default class AuthoringInfoField1ClassBreakInfosWrapper extends AuthoringInfoField1ClassBreakInfosGenerated {

    constructor(component: AuthoringInfoField1ClassBreakInfos) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfoField1ClassBreakInfos(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoField1ClassBreakInfosGenerated } = await import('./authoringInfoField1ClassBreakInfos.gb');
    return await buildJsAuthoringInfoField1ClassBreakInfosGenerated(dotNetObject);
}
export async function buildDotNetAuthoringInfoField1ClassBreakInfos(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoField1ClassBreakInfosGenerated } = await import('./authoringInfoField1ClassBreakInfos.gb');
    return await buildDotNetAuthoringInfoField1ClassBreakInfosGenerated(jsObject);
}
