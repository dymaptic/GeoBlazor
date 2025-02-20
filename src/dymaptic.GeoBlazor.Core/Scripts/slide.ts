// override generated code in this file
import SlideGenerated from './slide.gb';
import Slide from '@arcgis/core/webscene/Slide';

export default class SlideWrapper extends SlideGenerated {

    constructor(component: Slide) {
        super(component);
    }

}

export async function buildJsSlide(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSlideGenerated} = await import('./slide.gb');
    return await buildJsSlideGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSlide(jsObject: any): Promise<any> {
    let {buildDotNetSlideGenerated} = await import('./slide.gb');
    return await buildDotNetSlideGenerated(jsObject);
}
