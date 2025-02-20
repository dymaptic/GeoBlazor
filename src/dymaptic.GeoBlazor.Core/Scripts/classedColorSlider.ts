import ClassedColorSlider from '@arcgis/core/widgets/smartMapping/ClassedColorSlider';
import ClassedColorSliderGenerated from './classedColorSlider.gb';

export default class ClassedColorSliderWrapper extends ClassedColorSliderGenerated {

    constructor(component: ClassedColorSlider) {
        super(component);
    }

}

export async function buildJsClassedColorSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassedColorSliderGenerated} = await import('./classedColorSlider.gb');
    return await buildJsClassedColorSliderGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassedColorSlider(jsObject: any): Promise<any> {
    let {buildDotNetClassedColorSliderGenerated} = await import('./classedColorSlider.gb');
    return await buildDotNetClassedColorSliderGenerated(jsObject);
}
