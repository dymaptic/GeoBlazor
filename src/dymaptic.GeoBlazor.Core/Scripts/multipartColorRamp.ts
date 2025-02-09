// override generated code in this file
import MultipartColorRampGenerated from './multipartColorRamp.gb';
import MultipartColorRamp from '@arcgis/core/rest/support/MultipartColorRamp';

export default class MultipartColorRampWrapper extends MultipartColorRampGenerated {

    constructor(component: MultipartColorRamp) {
        super(component);
    }
    
}

export async function buildJsMultipartColorRamp(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMultipartColorRampGenerated } = await import('./multipartColorRamp.gb');
    return await buildJsMultipartColorRampGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMultipartColorRamp(jsObject: any): Promise<any> {
    let { buildDotNetMultipartColorRampGenerated } = await import('./multipartColorRamp.gb');
    return await buildDotNetMultipartColorRampGenerated(jsObject);
}
