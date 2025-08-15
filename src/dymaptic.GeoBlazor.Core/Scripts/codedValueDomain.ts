// override generated code in this file
import CodedValueDomainGenerated from './codedValueDomain.gb';
import CodedValueDomain from '@arcgis/core/layers/support/CodedValueDomain';

export default class CodedValueDomainWrapper extends CodedValueDomainGenerated {

    constructor(component: CodedValueDomain) {
        super(component);
    }
    
}

export async function buildJsCodedValueDomain(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCodedValueDomainGenerated } = await import('./codedValueDomain.gb');
    return await buildJsCodedValueDomainGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCodedValueDomain(jsObject: any): Promise<any> {
    let { buildDotNetCodedValueDomainGenerated } = await import('./codedValueDomain.gb');
    return await buildDotNetCodedValueDomainGenerated(jsObject);
}
