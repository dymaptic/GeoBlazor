// override generated code in this file
import ImageMediaInfoGenerated from './imageMediaInfo.gb';
import ImageMediaInfo from '@arcgis/core/popup/content/ImageMediaInfo';

export default class ImageMediaInfoWrapper extends ImageMediaInfoGenerated {

    constructor(component: ImageMediaInfo) {
        super(component);
    }
    
}

export async function buildJsImageMediaInfo(dotNetObject: any): Promise<any> {
    let { buildJsImageMediaInfoGenerated } = await import('./imageMediaInfo.gb');
    return await buildJsImageMediaInfoGenerated(dotNetObject);
}     

export async function buildDotNetImageMediaInfo(jsObject: any): Promise<any> {
    let { buildDotNetImageMediaInfoGenerated } = await import('./imageMediaInfo.gb');
    return await buildDotNetImageMediaInfoGenerated(jsObject);
}
