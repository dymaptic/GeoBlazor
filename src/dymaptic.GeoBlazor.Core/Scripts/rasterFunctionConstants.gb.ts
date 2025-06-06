// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetRasterFunctionConstants } from './rasterFunctionConstants';

export async function buildJsRasterFunctionConstantsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsrasterFunctionConstants: any = {};
    if (hasValue(dotNetObject.localArithmeticOperation)) {
        let { buildJsRasterFunctionConstantsLocalArithmeticOperation } = await import('./rasterFunctionConstantsLocalArithmeticOperation');
        jsrasterFunctionConstants.localArithmeticOperation = await buildJsRasterFunctionConstantsLocalArithmeticOperation(dotNetObject.localArithmeticOperation, layerId, viewId) as any;
    }

    
    let jsObjectRef = DotNet.createJSObjectReference(jsrasterFunctionConstants);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrasterFunctionConstants;
    
    return jsrasterFunctionConstants;
}


export async function buildDotNetRasterFunctionConstantsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetRasterFunctionConstants: any = {};
    
    if (hasValue(jsObject.localArithmeticOperation)) {
        let { buildDotNetRasterFunctionConstantsLocalArithmeticOperation } = await import('./rasterFunctionConstantsLocalArithmeticOperation');
        dotNetRasterFunctionConstants.localArithmeticOperation = await buildDotNetRasterFunctionConstantsLocalArithmeticOperation(jsObject.localArithmeticOperation, layerId, viewId);
    }
    
    if (hasValue(jsObject.bandIndexType)) {
        dotNetRasterFunctionConstants.bandIndexType = removeCircularReferences(jsObject.bandIndexType);
    }
    
    if (hasValue(jsObject.cellStatisticalOperation)) {
        dotNetRasterFunctionConstants.cellStatisticalOperation = removeCircularReferences(jsObject.cellStatisticalOperation);
    }
    
    if (hasValue(jsObject.colormapName)) {
        dotNetRasterFunctionConstants.colormapName = removeCircularReferences(jsObject.colormapName);
    }
    
    if (hasValue(jsObject.colorRampName)) {
        dotNetRasterFunctionConstants.colorRampName = removeCircularReferences(jsObject.colorRampName);
    }
    
    if (hasValue(jsObject.convolutionKernel)) {
        dotNetRasterFunctionConstants.convolutionKernel = removeCircularReferences(jsObject.convolutionKernel);
    }
    
    if (hasValue(jsObject.localConditionalOperation)) {
        dotNetRasterFunctionConstants.localConditionalOperation = removeCircularReferences(jsObject.localConditionalOperation);
    }
    
    if (hasValue(jsObject.localLogicalOperation)) {
        dotNetRasterFunctionConstants.localLogicalOperation = removeCircularReferences(jsObject.localLogicalOperation);
    }
    
    if (hasValue(jsObject.localTrigonometricOperation)) {
        dotNetRasterFunctionConstants.localTrigonometricOperation = removeCircularReferences(jsObject.localTrigonometricOperation);
    }
    
    if (hasValue(jsObject.missingBandAction)) {
        dotNetRasterFunctionConstants.missingBandAction = removeCircularReferences(jsObject.missingBandAction);
    }
    
    if (hasValue(jsObject.noDataInterpretation)) {
        dotNetRasterFunctionConstants.noDataInterpretation = removeCircularReferences(jsObject.noDataInterpretation);
    }
    
    if (hasValue(jsObject.slopeType)) {
        dotNetRasterFunctionConstants.slopeType = removeCircularReferences(jsObject.slopeType);
    }
    
    if (hasValue(jsObject.stretchType)) {
        dotNetRasterFunctionConstants.stretchType = removeCircularReferences(jsObject.stretchType);
    }
    

    return dotNetRasterFunctionConstants;
}

