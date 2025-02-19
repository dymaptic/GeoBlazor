// override generated code in this file
import FeatureType from '@arcgis/core/layers/support/FeatureType';
import {hasValue} from "./arcGisJsInterop";

export async function buildDotNetFeatureType(result: FeatureType) {
    if (!hasValue(result)) {
        return null;
    }
    let dotNetDomains = {};
    for (let domain in result.domains) {
        if (Object.prototype.hasOwnProperty.call(result.domains, domain)) {
            let { buildDotNetDomain } = await import('./domain');
            dotNetDomains[domain] = buildDotNetDomain(result.domains[domain]);
        }
    }

    let { buildDotNetFeatureTemplate } = await import('./featureTemplate');
    return {
        id: result.id,
        domains: dotNetDomains,
        declaredClass: result.declaredClass,
        name: result.name,
        templates: result.templates?.map(buildDotNetFeatureTemplate)
    }
}
export async function buildJsFeatureType(dotNetObject: any): Promise<any> {
    let { buildJsFeatureTypeGenerated } = await import('./featureType.gb');
    return await buildJsFeatureTypeGenerated(dotNetObject);
}
