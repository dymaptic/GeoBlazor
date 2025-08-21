// override generated code in this file

import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export async function buildDotNetFeatureType(jsObject: any): Promise<any> {
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
        dotNetFeatureType.featureTypeId = jsObject.id;
    }
    
    if (hasValue(jsObject.name)) {
        dotNetFeatureType.name = jsObject.name;
    }
    
    if (hasValue(jsObject.templates)) {
        let {buildDotNetIFeatureTemplate} = await import('./iFeatureTemplate');
        dotNetFeatureType.templates = 
            await Promise.all(jsObject.templates.map(async t => await buildDotNetIFeatureTemplate(t)));
    }
    
    return dotNetFeatureType;
}

export async function buildJsFeatureType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsFeatureType: any = {};
    if (hasValue(dotNetObject.domains)) {
        let { buildJsDomain } = await import('./domain');
        jsFeatureType.domains = buildJsDomain(dotNetObject.domains) as any;
    }

    if (hasValue(dotNetObject.featureTypeId)) {
        jsFeatureType.id = dotNetObject.featureTypeId;
    }
    if (hasValue(dotNetObject.name)) {
        jsFeatureType.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.templates)) {
        let { buildJsIFeatureTemplate } = await import('./iFeatureTemplate');
        jsFeatureType.templates = 
            await Promise.all(dotNetObject.templates.map(async t => await buildJsIFeatureTemplate(t, layerId, viewId)));
    }

    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureType);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureType;

    return jsFeatureType;
}
