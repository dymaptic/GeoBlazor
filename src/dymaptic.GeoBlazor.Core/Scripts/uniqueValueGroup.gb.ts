// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import UniqueValueGroup from '@arcgis/core/renderers/support/UniqueValueGroup';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId } from './arcGisJsInterop';
import { buildDotNetUniqueValueGroup } from './uniqueValueGroup';

export async function buildJsUniqueValueGroupGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.classes) && dotNetObject.classes.length > 0) {
        let { buildJsUniqueValueClass } = await import('./uniqueValueClass');
        properties.classes = await Promise.all(dotNetObject.classes.map(async i => await buildJsUniqueValueClass(i))) as any;
    }

    if (hasValue(dotNetObject.heading)) {
        properties.heading = dotNetObject.heading;
    }
    let jsUniqueValueGroup = new UniqueValueGroup(properties);
    
    jsObjectRefs[dotNetObject.id] = jsUniqueValueGroup;
    arcGisObjectRefs[dotNetObject.id] = jsUniqueValueGroup;
    
    return jsUniqueValueGroup;
}


export async function buildDotNetUniqueValueGroupGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetUniqueValueGroup: any = {};
    
    if (hasValue(jsObject.classes)) {
        let { buildDotNetUniqueValueClass } = await import('./uniqueValueClass');
        dotNetUniqueValueGroup.classes = await Promise.all(jsObject.classes.map(async i => await buildDotNetUniqueValueClass(i)));
    }
    
    if (hasValue(jsObject.heading)) {
        dotNetUniqueValueGroup.heading = jsObject.heading;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetUniqueValueGroup.id = geoBlazorId;
    }

    return dotNetUniqueValueGroup;
}

