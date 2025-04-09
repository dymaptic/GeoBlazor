// override generated code in this file
import ProjectOperatorGenerated from './projectOperator.gb';
import projectOperator = __esri.projectOperator;

export default class ProjectOperatorWrapper extends ProjectOperatorGenerated {

    constructor(component: projectOperator) {
        super(component);
    }
    
}

export async function buildJsProjectOperator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProjectOperatorGenerated } = await import('./projectOperator.gb');
    return await buildJsProjectOperatorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProjectOperator(jsObject: any): Promise<any> {
    let { buildDotNetProjectOperatorGenerated } = await import('./projectOperator.gb');
    return await buildDotNetProjectOperatorGenerated(jsObject);
}
