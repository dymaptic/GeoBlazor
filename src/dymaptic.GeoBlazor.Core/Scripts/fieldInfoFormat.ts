// override generated code in this file
import FieldInfoFormatGenerated from './fieldInfoFormat.gb';
import FieldInfoFormat from '@arcgis/core/popup/support/FieldInfoFormat';

export default class FieldInfoFormatWrapper extends FieldInfoFormatGenerated {

    constructor(component: FieldInfoFormat) {
        super(component);
    }
    
}              
export async function buildJsFieldInfoFormat(dotNetObject: any): Promise<any> {
    let { buildJsFieldInfoFormatGenerated } = await import('./fieldInfoFormat.gb');
    return await buildJsFieldInfoFormatGenerated(dotNetObject);
}
export async function buildDotNetFieldInfoFormat(jsObject: any): Promise<any> {
    let { buildDotNetFieldInfoFormatGenerated } = await import('./fieldInfoFormat.gb');
    return await buildDotNetFieldInfoFormatGenerated(jsObject);
}
