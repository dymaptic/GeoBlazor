// override generated code in this file
import FieldInfoGenerated from './fieldInfo.gb';
import FieldInfo from '@arcgis/core/popup/FieldInfo';

export default class FieldInfoWrapper extends FieldInfoGenerated {

    constructor(component: FieldInfo) {
        super(component);
    }
    
}              
export async function buildJsFieldInfo(dotNetObject: any): Promise<any> {
    let { buildJsFieldInfoGenerated } = await import('./fieldInfo.gb');
    return await buildJsFieldInfoGenerated(dotNetObject);
}
export async function buildDotNetFieldInfo(jsObject: any): Promise<any> {
    let { buildDotNetFieldInfoGenerated } = await import('./fieldInfo.gb');
    return await buildDotNetFieldInfoGenerated(jsObject);
}
