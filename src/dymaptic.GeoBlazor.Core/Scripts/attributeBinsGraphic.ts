// override generated code in this file
import AttributeBinsGraphicGenerated from './attributeBinsGraphic.gb';
import AttributeBinsGraphic from '@arcgis/core/AttributeBinsGraphic';

export default class AttributeBinsGraphicWrapper extends AttributeBinsGraphicGenerated {

    constructor(component: AttributeBinsGraphic) {
        super(component);
    }
    
}

export async function buildJsAttributeBinsGraphic(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeBinsGraphicGenerated } = await import('./attributeBinsGraphic.gb');
    return await buildJsAttributeBinsGraphicGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeBinsGraphic(jsObject: any): Promise<any> {
    let { buildDotNetAttributeBinsGraphicGenerated } = await import('./attributeBinsGraphic.gb');
    return await buildDotNetAttributeBinsGraphicGenerated(jsObject);
}
