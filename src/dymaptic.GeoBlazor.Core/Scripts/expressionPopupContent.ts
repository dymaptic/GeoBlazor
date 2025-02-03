// override generated code in this file
import ExpressionPopupContentGenerated from './expressionPopupContent.gb';
import ExpressionContent = __esri.ExpressionContent;

export default class ExpressionPopupContentWrapper extends ExpressionPopupContentGenerated {

    constructor(component: ExpressionContent) {
        super(component);
    }
    
}

export async function buildJsExpressionPopupContent(dotNetObject: any): Promise<any> {
    let { buildJsExpressionPopupContentGenerated } = await import('./expressionPopupContent.gb');
    return await buildJsExpressionPopupContentGenerated(dotNetObject);
}     

export async function buildDotNetExpressionPopupContent(jsObject: any): Promise<any> {
    let { buildDotNetExpressionPopupContentGenerated } = await import('./expressionPopupContent.gb');
    return await buildDotNetExpressionPopupContentGenerated(jsObject);
}
