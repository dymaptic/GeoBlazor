// override generated code in this file
import SizeSliderGenerated from './sizeSlider.gb';
import SizeSlider from '@arcgis/core/widgets/smartMapping/SizeSlider';

export default class SizeSliderWrapper extends SizeSliderGenerated {

    constructor(component: SizeSlider) {
        super(component);
    }
    
}

export async function buildJsSizeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSliderGenerated } = await import('./sizeSlider.gb');
    return await buildJsSizeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSlider(jsObject: any): Promise<any> {
    let { buildDotNetSizeSliderGenerated } = await import('./sizeSlider.gb');
    return await buildDotNetSizeSliderGenerated(jsObject);
}
