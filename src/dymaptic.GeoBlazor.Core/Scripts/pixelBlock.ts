// override generated code in this file
import PixelBlockGenerated from './pixelBlock.gb';
import PixelBlock from '@arcgis/core/layers/support/PixelBlock';

export default class PixelBlockWrapper extends PixelBlockGenerated {

    constructor(component: PixelBlock) {
        super(component);
    }
    
}              
export async function buildJsPixelBlock(dotNetObject: any): Promise<any> {
    let { buildJsPixelBlockGenerated } = await import('./pixelBlock.gb');
    return await buildJsPixelBlockGenerated(dotNetObject);
}
export async function buildDotNetPixelBlock(jsObject: any): Promise<any> {
    let { buildDotNetPixelBlockGenerated } = await import('./pixelBlock.gb');
    return await buildDotNetPixelBlockGenerated(jsObject);
}
