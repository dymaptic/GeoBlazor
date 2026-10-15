// override generated code in this file
import SizeVariableGenerated from './sizeVariable.gb';
import SizeVariable from '@arcgis/core/renderers/visualVariables/SizeVariable';
import {arcGisObjectRefs, dotNetRefs, hasValue, jsObjectRefs, lookupGeoBlazorId} from './geoBlazorCore';

export default class SizeVariableWrapper extends SizeVariableGenerated {

    constructor(component: SizeVariable) {
        super(component);
    }

    async setStops(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.component.stops = [];
        }
        let { buildJsSizeStop } = await import('./sizeStop');
        this.component.stops = await Promise.all(value.map(async i => await buildJsSizeStop(i))) as any;
    }


}

export async function buildJsSizeVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeVariableGenerated} = await import('./sizeVariable.gb');
    return await buildJsSizeVariableGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSizeVariableGenerated} = await import('./sizeVariable.gb');
    let dotNetSizeVariable = await buildDotNetSizeVariableGenerated(jsObject, layerId, viewId);

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSizeVariable.id = geoBlazorId;
    } else if (hasValue(viewId)) {
        let dotNetRef = dotNetRefs[viewId!];
        dotNetSizeVariable.id = await dotNetRef.invokeMethodAsync('GetId');
    }
    if (hasValue(dotNetSizeVariable.id)) {
        jsObjectRefs[dotNetSizeVariable.id] ??= jsObject;
        arcGisObjectRefs[dotNetSizeVariable.id] ??= jsObject;
    }
    
    return dotNetSizeVariable;
}
