// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetVersionManagementViewModelVersionInfo } from './versionManagementViewModelVersionInfo';

export async function buildJsVersionManagementViewModelVersionInfoGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsVersionManagementViewModelVersionInfo: any = {};
    if (hasValue(dotNetObject.versionIdentifier)) {
        let { buildJsVersionManagementServiceVersionIdentifier } = await import('./versionManagementServiceVersionIdentifier');
        jsVersionManagementViewModelVersionInfo.versionIdentifier = await buildJsVersionManagementServiceVersionIdentifier(dotNetObject.versionIdentifier, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.access)) {
        jsVersionManagementViewModelVersionInfo.access = dotNetObject.access;
    }
    if (hasValue(dotNetObject.creationDate)) {
        jsVersionManagementViewModelVersionInfo.creationDate = dotNetObject.creationDate;
    }
    if (hasValue(dotNetObject.description)) {
        jsVersionManagementViewModelVersionInfo.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.versionId)) {
        jsVersionManagementViewModelVersionInfo.versionId = dotNetObject.versionId;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsVersionManagementViewModelVersionInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsVersionManagementViewModelVersionInfo;
    
    return jsVersionManagementViewModelVersionInfo;
}


export async function buildDotNetVersionManagementViewModelVersionInfoGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetVersionManagementViewModelVersionInfo: any = {};
    
    if (hasValue(jsObject.versionIdentifier)) {
        let { buildDotNetVersionManagementServiceVersionIdentifier } = await import('./versionManagementServiceVersionIdentifier');
        dotNetVersionManagementViewModelVersionInfo.versionIdentifier = await buildDotNetVersionManagementServiceVersionIdentifier(jsObject.versionIdentifier, layerId, viewId);
    }
    
    if (hasValue(jsObject.access)) {
        dotNetVersionManagementViewModelVersionInfo.access = removeCircularReferences(jsObject.access);
    }
    
    if (hasValue(jsObject.creationDate)) {
        dotNetVersionManagementViewModelVersionInfo.creationDate = jsObject.creationDate;
    }
    
    if (hasValue(jsObject.description)) {
        dotNetVersionManagementViewModelVersionInfo.description = jsObject.description;
    }
    
    if (hasValue(jsObject.versionId)) {
        dotNetVersionManagementViewModelVersionInfo.versionId = jsObject.versionId;
    }
    

    return dotNetVersionManagementViewModelVersionInfo;
}

