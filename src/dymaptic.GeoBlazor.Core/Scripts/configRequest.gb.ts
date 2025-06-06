// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetConfigRequest } from './configRequest';

export async function buildJsConfigRequestGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsconfigRequest: any = {};
    if (hasValue(dotNetObject.interceptors) && dotNetObject.interceptors.length > 0) {
        let { buildJsRequestInterceptor } = await import('./requestInterceptor');
        jsconfigRequest.interceptors = await Promise.all(dotNetObject.interceptors.map(async i => await buildJsRequestInterceptor(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.proxyRules) && dotNetObject.proxyRules.length > 0) {
        let { buildJsConfigRequestProxyRules } = await import('./configRequestProxyRules');
        jsconfigRequest.proxyRules = await Promise.all(dotNetObject.proxyRules.map(async i => await buildJsConfigRequestProxyRules(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.httpsDomains) && dotNetObject.httpsDomains.length > 0) {
        jsconfigRequest.httpsDomains = dotNetObject.httpsDomains;
    }
    if (hasValue(dotNetObject.maxUrlLength)) {
        jsconfigRequest.maxUrlLength = dotNetObject.maxUrlLength;
    }
    if (hasValue(dotNetObject.priority)) {
        jsconfigRequest.priority = dotNetObject.priority;
    }
    if (hasValue(dotNetObject.proxyUrl)) {
        jsconfigRequest.proxyUrl = dotNetObject.proxyUrl;
    }
    if (hasValue(dotNetObject.timeout)) {
        jsconfigRequest.timeout = dotNetObject.timeout;
    }
    if (hasValue(dotNetObject.trustedServers) && dotNetObject.trustedServers.length > 0) {
        jsconfigRequest.trustedServers = dotNetObject.trustedServers;
    }
    if (hasValue(dotNetObject.useIdentity)) {
        jsconfigRequest.useIdentity = dotNetObject.useIdentity;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsconfigRequest);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsconfigRequest;
    
    return jsconfigRequest;
}


export async function buildDotNetConfigRequestGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetConfigRequest: any = {};
    
    if (hasValue(jsObject.interceptors)) {
        let { buildDotNetRequestInterceptor } = await import('./requestInterceptor');
        dotNetConfigRequest.interceptors = await Promise.all(jsObject.interceptors.map(async i => await buildDotNetRequestInterceptor(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.proxyRules)) {
        let { buildDotNetConfigRequestProxyRules } = await import('./configRequestProxyRules');
        dotNetConfigRequest.proxyRules = await Promise.all(jsObject.proxyRules.map(async i => await buildDotNetConfigRequestProxyRules(i, layerId, viewId)));
    }
    
    if (hasValue(jsObject.httpsDomains)) {
        dotNetConfigRequest.httpsDomains = jsObject.httpsDomains;
    }
    
    if (hasValue(jsObject.maxUrlLength)) {
        dotNetConfigRequest.maxUrlLength = jsObject.maxUrlLength;
    }
    
    if (hasValue(jsObject.priority)) {
        dotNetConfigRequest.priority = removeCircularReferences(jsObject.priority);
    }
    
    if (hasValue(jsObject.proxyUrl)) {
        dotNetConfigRequest.proxyUrl = jsObject.proxyUrl;
    }
    
    if (hasValue(jsObject.timeout)) {
        dotNetConfigRequest.timeout = jsObject.timeout;
    }
    
    if (hasValue(jsObject.trustedServers)) {
        dotNetConfigRequest.trustedServers = jsObject.trustedServers;
    }
    
    if (hasValue(jsObject.useIdentity)) {
        dotNetConfigRequest.useIdentity = jsObject.useIdentity;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetConfigRequest.id = geoBlazorId;
    }

    return dotNetConfigRequest;
}

