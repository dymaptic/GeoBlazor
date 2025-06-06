// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetIBreakpointsOwner } from './iBreakpointsOwner';

export async function buildJsIBreakpointsOwnerGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsBreakpointsOwner: any = {};
    if (hasValue(dotNetObject.breakpoints)) {
        let { buildJsBreakpointsOwnerBreakpoints } = await import('./breakpointsOwnerBreakpoints');
        jsBreakpointsOwner.breakpoints = await buildJsBreakpointsOwnerBreakpoints(dotNetObject.breakpoints, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.heightBreakpoint)) {
        jsBreakpointsOwner.heightBreakpoint = dotNetObject.heightBreakpoint;
    }
    if (hasValue(dotNetObject.widthBreakpoint)) {
        jsBreakpointsOwner.widthBreakpoint = dotNetObject.widthBreakpoint;
    }
    
    let jsObjectRef = DotNet.createJSObjectReference(jsBreakpointsOwner);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBreakpointsOwner;
    
    return jsBreakpointsOwner;
}


export async function buildDotNetIBreakpointsOwnerGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetIBreakpointsOwner: any = {};
    
    if (hasValue(jsObject.breakpoints)) {
        let { buildDotNetBreakpointsOwnerBreakpoints } = await import('./breakpointsOwnerBreakpoints');
        dotNetIBreakpointsOwner.breakpoints = await buildDotNetBreakpointsOwnerBreakpoints(jsObject.breakpoints, layerId, viewId);
    }
    
    if (hasValue(jsObject.orientation)) {
        let { buildDotNetOrientation } = await import('./orientation');
        dotNetIBreakpointsOwner.orientation = await buildDotNetOrientation(jsObject.orientation);
    }
    
    if (hasValue(jsObject.heightBreakpoint)) {
        dotNetIBreakpointsOwner.heightBreakpoint = removeCircularReferences(jsObject.heightBreakpoint);
    }
    
    if (hasValue(jsObject.widthBreakpoint)) {
        dotNetIBreakpointsOwner.widthBreakpoint = removeCircularReferences(jsObject.widthBreakpoint);
    }
    

    return dotNetIBreakpointsOwner;
}

