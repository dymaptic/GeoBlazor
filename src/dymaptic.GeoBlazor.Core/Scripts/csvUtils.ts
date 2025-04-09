// override generated code in this file
import CsvUtilsGenerated from './csvUtils.gb';
import csvUtils = __esri.csvUtils;

export default class CsvUtilsWrapper extends CsvUtilsGenerated {

    constructor(component: csvUtils) {
        super(component);
    }
    
}

export async function buildJsCsvUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCsvUtilsGenerated } = await import('./csvUtils.gb');
    return await buildJsCsvUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCsvUtils(jsObject: any): Promise<any> {
    let { buildDotNetCsvUtilsGenerated } = await import('./csvUtils.gb');
    return await buildDotNetCsvUtilsGenerated(jsObject);
}
