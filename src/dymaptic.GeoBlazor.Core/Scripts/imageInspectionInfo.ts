// override generated code in this file
import ImageInspectionInfoGenerated from './imageInspectionInfo.gb';
import ImageInspectionInfo from '@arcgis/core/rest/support/ImageInspectionInfo';

export default class ImageInspectionInfoWrapper extends ImageInspectionInfoGenerated {

    constructor(component: ImageInspectionInfo) {
        super(component);
    }
    
}              
export async function buildJsImageInspectionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageInspectionInfoGenerated } = await import('./imageInspectionInfo.gb');
    return await buildJsImageInspectionInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageInspectionInfo(jsObject: any): Promise<any> {
    let { buildDotNetImageInspectionInfoGenerated } = await import('./imageInspectionInfo.gb');
    return await buildDotNetImageInspectionInfoGenerated(jsObject);
}
