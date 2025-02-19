// override generated code in this file
import WhereClauseGenerated from './whereClause.gb';
import WhereClause = __esri.WhereClause;

export default class WhereClauseWrapper extends WhereClauseGenerated {

    constructor(component: WhereClause) {
        super(component);
    }
    
}

export async function buildJsWhereClause(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWhereClauseGenerated } = await import('./whereClause.gb');
    return await buildJsWhereClauseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWhereClause(jsObject: any): Promise<any> {
    let { buildDotNetWhereClauseGenerated } = await import('./whereClause.gb');
    return await buildDotNetWhereClauseGenerated(jsObject);
}
