// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import DeviceLocationFeed from '@arcgis/core/webdoc/geotriggersInfo/DeviceLocationFeed';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetDeviceLocationFeed } from './deviceLocationFeed';

export async function buildJsDeviceLocationFeedGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.filterExpression)) {
        let { buildJsGeotriggersInfoExpressionInfo } = await import('./geotriggersInfoExpressionInfo');
        properties.filterExpression = await buildJsGeotriggersInfoExpressionInfo(dotNetObject.filterExpression, layerId, viewId) as any;
    }

    let jsDeviceLocationFeed = new DeviceLocationFeed(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsDeviceLocationFeed);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsDeviceLocationFeed;
    
    return jsDeviceLocationFeed;
}


export async function buildDotNetDeviceLocationFeedGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetDeviceLocationFeed: any = {};
    
    if (hasValue(jsObject.filterExpression)) {
        let { buildDotNetGeotriggersInfoExpressionInfo } = await import('./geotriggersInfoExpressionInfo');
        dotNetDeviceLocationFeed.filterExpression = await buildDotNetGeotriggersInfoExpressionInfo(jsObject.filterExpression, layerId, viewId);
    }
    
    if (hasValue(jsObject.type)) {
        dotNetDeviceLocationFeed.type = removeCircularReferences(jsObject.type);
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetDeviceLocationFeed.id = geoBlazorId;
    }

    return dotNetDeviceLocationFeed;
}

