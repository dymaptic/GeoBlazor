// override generated code in this file
import AuthoringInfoFieldGenerated from './authoringInfoField.gb';
import AuthoringInfoField = __esri.AuthoringInfoField1;

export default class AuthoringInfoFieldWrapper extends AuthoringInfoFieldGenerated {

    constructor(component: AuthoringInfoField) {
        super(component);
    }
    
}              
export async function buildJsAuthoringInfoField(dotNetObject: any): Promise<any> {
    let { buildJsAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildJsAuthoringInfoFieldGenerated(dotNetObject);
}
export async function buildDotNetAuthoringInfoField(jsObject: any): Promise<any> {
    let { buildDotNetAuthoringInfoFieldGenerated } = await import('./authoringInfoField.gb');
    return await buildDotNetAuthoringInfoFieldGenerated(jsObject);
}
