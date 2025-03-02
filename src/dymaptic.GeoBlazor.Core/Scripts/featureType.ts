// override generated code in this file
import FeatureType from '@arcgis/core/layers/support/FeatureType';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export async function buildDotNetFeatureType(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetFeatureType: any = {};
    
    if (hasValue(jsObject.domains)) {
        let {buildDotNetDomain} = await import('./domain');
        let dotNetDomains = {};
        for (let domain in jsObject.domains) {
            if (Object.prototype.hasOwnProperty.call(jsObject.domains, domain)) {
                dotNetDomains[domain] = buildDotNetDomain(jsObject.domains[domain]);
            }
        }
        
        dotNetFeatureType.domains = dotNetDomains;
    }
    
    if (hasValue(jsObject.id)) {
        dotNetFeatureType.id = jsObject.id;
    }
    
    if (hasValue(jsObject.name)) {
        dotNetFeatureType.name = jsObject.name;
    }
    
    if (hasValue(jsObject.templates)) {
        let {buildDotNetIFeatureTemplate} = await import('./iFeatureTemplate');
        dotNetFeatureType.templates = jsObject.templates.map(t => buildDotNetIFeatureTemplate(t, layerId, viewId));
    }
    
    return dotNetFeatureType;
}

export async function buildJsFeatureType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let properties: any = {};
    if (hasValue(dotNetObject.domains)) {
        let { buildJsDomain } = await import('./domain');
        properties.domains = buildJsDomain(dotNetObject.domains) as any;
    }

    if (hasValue(dotNetObject.featureTypeId)) {
        properties.id = dotNetObject.featureTypeId;
    }
    if (hasValue(dotNetObject.name)) {
        properties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.templates)) {
        let { buildJsIFeatureTemplate } = await import('./iFeatureTemplate');
        properties.templates = dotNetObject.templates.map(t => buildJsIFeatureTemplate(t, layerId, viewId));
    }
    let jsFeatureType = new FeatureType(properties);

    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureType);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureType;

    return jsFeatureType;
}
