// override generated code in this file
import CSVLayerElevationInfoGenerated from './cSVLayerElevationInfo.gb';
import CSVLayerElevationInfo = __esri.CSVLayerElevationInfo;

export default class CSVLayerElevationInfoWrapper extends CSVLayerElevationInfoGenerated {

    constructor(component: CSVLayerElevationInfo) {
        super(component);
    }
    
}              
export async function buildJsCSVLayerElevationInfo(dotNetObject: any): Promise<any> {
    let { buildJsCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildJsCSVLayerElevationInfoGenerated(dotNetObject);
}
export async function buildDotNetCSVLayerElevationInfo(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerElevationInfoGenerated } = await import('./cSVLayerElevationInfo.gb');
    return await buildDotNetCSVLayerElevationInfoGenerated(jsObject);
}
