// override generated code in this file
import ClassedSizeSliderGenerated from './classedSizeSlider.gb';
import ClassedSizeSlider from '@arcgis/core/widgets/smartMapping/ClassedSizeSlider';

export default class ClassedSizeSliderWrapper extends ClassedSizeSliderGenerated {

    constructor(component: ClassedSizeSlider) {
        super(component);
    }
    
}

export async function buildJsClassedSizeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedSizeSliderGenerated } = await import('./classedSizeSlider.gb');
    return await buildJsClassedSizeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedSizeSlider(jsObject: any): Promise<any> {
    let { buildDotNetClassedSizeSliderGenerated } = await import('./classedSizeSlider.gb');
    return await buildDotNetClassedSizeSliderGenerated(jsObject);
}
