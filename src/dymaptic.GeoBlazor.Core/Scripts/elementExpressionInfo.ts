// override generated code in this file
import ElementExpressionInfoGenerated from './elementExpressionInfo.gb';
import ElementExpressionInfo from '@arcgis/core/popup/ElementExpressionInfo';

export default class ElementExpressionInfoWrapper extends ElementExpressionInfoGenerated {

    constructor(component: ElementExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsElementExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElementExpressionInfoGenerated } = await import('./elementExpressionInfo.gb');
    return await buildJsElementExpressionInfoGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetElementExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetElementExpressionInfoGenerated } = await import('./elementExpressionInfo.gb');
    return await buildDotNetElementExpressionInfoGenerated(jsObject);
}
