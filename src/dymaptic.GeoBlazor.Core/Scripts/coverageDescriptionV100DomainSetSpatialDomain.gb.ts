// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetCoverageDescriptionV100DomainSetSpatialDomain } from './coverageDescriptionV100DomainSetSpatialDomain';

export async function buildJsCoverageDescriptionV100DomainSetSpatialDomainGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsCoverageDescriptionV100DomainSetSpatialDomain: any = {};
    if (hasValue(dotNetObject.envelope)) {
        let { buildJsExtent } = await import('./extent');
        jsCoverageDescriptionV100DomainSetSpatialDomain.envelope = buildJsExtent(dotNetObject.envelope) as any;
    }

    if (hasValue(dotNetObject.columns)) {
        jsCoverageDescriptionV100DomainSetSpatialDomain.columns = dotNetObject.columns;
    }
    if (hasValue(dotNetObject.offset)) {
        jsCoverageDescriptionV100DomainSetSpatialDomain.offset = dotNetObject.offset;
    }
    if (hasValue(dotNetObject.origin)) {
        jsCoverageDescriptionV100DomainSetSpatialDomain.origin = dotNetObject.origin;
    }
    if (hasValue(dotNetObject.rows)) {
        jsCoverageDescriptionV100DomainSetSpatialDomain.rows = dotNetObject.rows;
    }
    
    jsObjectRefs[dotNetObject.id] = jsCoverageDescriptionV100DomainSetSpatialDomain;
    arcGisObjectRefs[dotNetObject.id] = jsCoverageDescriptionV100DomainSetSpatialDomain;
    
    return jsCoverageDescriptionV100DomainSetSpatialDomain;
}


export async function buildDotNetCoverageDescriptionV100DomainSetSpatialDomainGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetCoverageDescriptionV100DomainSetSpatialDomain: any = {};
    
    if (hasValue(jsObject.envelope)) {
        let { buildDotNetExtent } = await import('./extent');
        dotNetCoverageDescriptionV100DomainSetSpatialDomain.envelope = buildDotNetExtent(jsObject.envelope);
    }
    
    if (hasValue(jsObject.columns)) {
        dotNetCoverageDescriptionV100DomainSetSpatialDomain.columns = jsObject.columns;
    }
    
    if (hasValue(jsObject.offset)) {
        dotNetCoverageDescriptionV100DomainSetSpatialDomain.offset = removeCircularReferences(jsObject.offset);
    }
    
    if (hasValue(jsObject.origin)) {
        dotNetCoverageDescriptionV100DomainSetSpatialDomain.origin = removeCircularReferences(jsObject.origin);
    }
    
    if (hasValue(jsObject.rows)) {
        dotNetCoverageDescriptionV100DomainSetSpatialDomain.rows = jsObject.rows;
    }
    

    return dotNetCoverageDescriptionV100DomainSetSpatialDomain;
}

