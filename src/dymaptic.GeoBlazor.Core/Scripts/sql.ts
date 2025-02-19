// override generated code in this file
import SqlGenerated from './sql.gb';
import sql = __esri.sql;

export default class SqlWrapper extends SqlGenerated {

    constructor(component: sql) {
        super(component);
    }
    
}

export async function buildJsSql(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSqlGenerated } = await import('./sql.gb');
    return await buildJsSqlGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSql(jsObject: any): Promise<any> {
    let { buildDotNetSqlGenerated } = await import('./sql.gb');
    return await buildDotNetSqlGenerated(jsObject);
}
