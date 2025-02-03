// override generated code in this file
import LabelGenerated from './label.gb';
import Label = __esri.LabelClass;

export default class LabelWrapper extends LabelGenerated {

    constructor(component: Label) {
        super(component);
    }
    
}              
export async function buildJsLabel(dotNetObject: any): Promise<any> {
    let { buildJsLabelGenerated } = await import('./label.gb');
    return await buildJsLabelGenerated(dotNetObject);
}
export async function buildDotNetLabel(jsObject: any): Promise<any> {
    let { buildDotNetLabelGenerated } = await import('./label.gb');
    return await buildDotNetLabelGenerated(jsObject);
}
