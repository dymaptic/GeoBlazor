// override generated code in this file
import SqlServiceGenerated from './sqlService.gb';
import sql = __esri.sql;

export default class SqlServiceWrapper extends SqlServiceGenerated {

    constructor(component: sql) {
        super(component);
    }
    
}

export async function buildJsSqlService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSqlServiceGenerated } = await import('./sqlService.gb');
    return await buildJsSqlServiceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSqlService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSqlServiceGenerated } = await import('./sqlService.gb');
    return await buildDotNetSqlServiceGenerated(jsObject, layerId, viewId);
}
