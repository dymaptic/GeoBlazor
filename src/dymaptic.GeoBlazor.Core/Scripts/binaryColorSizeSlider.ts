// override generated code in this file
import BinaryColorSizeSliderGenerated from './binaryColorSizeSlider.gb';
import BinaryColorSizeSlider from '@arcgis/core/widgets/smartMapping/BinaryColorSizeSlider';

export default class BinaryColorSizeSliderWrapper extends BinaryColorSizeSliderGenerated {

    constructor(component: BinaryColorSizeSlider) {
        super(component);
    }
    
}

export async function buildJsBinaryColorSizeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinaryColorSizeSliderGenerated } = await import('./binaryColorSizeSlider.gb');
    return await buildJsBinaryColorSizeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBinaryColorSizeSlider(jsObject: any): Promise<any> {
    let { buildDotNetBinaryColorSizeSliderGenerated } = await import('./binaryColorSizeSlider.gb');
    return await buildDotNetBinaryColorSizeSliderGenerated(jsObject);
}
