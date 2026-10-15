// override generated code in this file
import LocateBetweenOperatorGenerated from './locateBetweenOperator.gb';
import locateBetweenOperator = __esri.locateBetweenOperator;

export default class LocateBetweenOperatorWrapper extends LocateBetweenOperatorGenerated {

    constructor(component: locateBetweenOperator) {
        super(component);
    }
    
}

export async function buildJsLocateBetweenOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocateBetweenOperatorGenerated } = await import('./locateBetweenOperator.gb');
    return await buildJsLocateBetweenOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLocateBetweenOperator(jsObject: any): Promise<any> {
    let { buildDotNetLocateBetweenOperatorGenerated } = await import('./locateBetweenOperator.gb');
    return await buildDotNetLocateBetweenOperatorGenerated(jsObject);
}
