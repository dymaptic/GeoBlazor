// override generated code in this file
import ExpressionInfoGenerated from './expressionInfo.gb';
import ExpressionInfo from '@arcgis/core/form/ExpressionInfo';

export default class ExpressionInfoWrapper extends ExpressionInfoGenerated {

    constructor(component: ExpressionInfo) {
        super(component);
    }
    
}              
export async function buildJsExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsExpressionInfoGenerated } = await import('./expressionInfo.gb');
    return await buildJsExpressionInfoGenerated(dotNetObject);
}
export async function buildDotNetExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetExpressionInfoGenerated } = await import('./expressionInfo.gb');
    return await buildDotNetExpressionInfoGenerated(jsObject);
}
