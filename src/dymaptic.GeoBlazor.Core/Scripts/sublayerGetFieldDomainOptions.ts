// override generated code in this file
import SublayerGetFieldDomainOptionsGenerated from './sublayerGetFieldDomainOptions.gb';
import SublayerGetFieldDomainOptions = __esri.SublayerGetFieldDomainOptions;

export default class SublayerGetFieldDomainOptionsWrapper extends SublayerGetFieldDomainOptionsGenerated {

    constructor(component: SublayerGetFieldDomainOptions) {
        super(component);
    }
    
}              
export async function buildJsSublayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSublayerGetFieldDomainOptionsGenerated } = await import('./sublayerGetFieldDomainOptions.gb');
    return await buildJsSublayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSublayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetSublayerGetFieldDomainOptionsGenerated } = await import('./sublayerGetFieldDomainOptions.gb');
    return await buildDotNetSublayerGetFieldDomainOptionsGenerated(jsObject);
}
