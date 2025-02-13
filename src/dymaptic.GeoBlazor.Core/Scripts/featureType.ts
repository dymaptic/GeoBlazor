// override generated code in this file
import FeatureTypeGenerated from './featureType.gb';
import FeatureType from '@arcgis/core/layers/support/FeatureType';
import {hasValue} from "./arcGisJsInterop";

export default class FeatureTypeWrapper extends FeatureTypeGenerated {

    constructor(component: FeatureType) {
        super(component);
    }
    
}

export async function buildDotNetFeatureType(result: FeatureType) {
    let { buildDotNetFeatureTypeGenerated } = await import('./featureType.gb');
    // TODO: compare with generated and possibly remove
    // return await buildDotNetFeatureTypeGenerated(result);
    if (!hasValue(result)) {
        return null;
    }
    let dotNetDomains = {};
    for (var domain in result.domains) {
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
