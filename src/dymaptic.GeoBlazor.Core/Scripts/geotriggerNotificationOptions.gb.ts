// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import GeotriggerNotificationOptions from '@arcgis/core/webdoc/geotriggersInfo/GeotriggerNotificationOptions';
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetGeotriggerNotificationOptions } from './geotriggerNotificationOptions';

export async function buildJsGeotriggerNotificationOptionsGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.expressionInfo)) {
        let { buildJsGeotriggersInfoExpressionInfo } = await import('./geotriggersInfoExpressionInfo');
        properties.expressionInfo = await buildJsGeotriggersInfoExpressionInfo(dotNetObject.expressionInfo, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.requestedActions) && dotNetObject.requestedActions.length > 0) {
        properties.requestedActions = dotNetObject.requestedActions;
    }
    let jsGeotriggerNotificationOptions = new GeotriggerNotificationOptions(properties);
    
    let jsObjectRef = DotNet.createJSObjectReference(jsGeotriggerNotificationOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsGeotriggerNotificationOptions;
    
    return jsGeotriggerNotificationOptions;
}


export async function buildDotNetGeotriggerNotificationOptionsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetGeotriggerNotificationOptions: any = {};
    
    if (hasValue(jsObject.expressionInfo)) {
        let { buildDotNetGeotriggersInfoExpressionInfo } = await import('./geotriggersInfoExpressionInfo');
        dotNetGeotriggerNotificationOptions.expressionInfo = await buildDotNetGeotriggersInfoExpressionInfo(jsObject.expressionInfo, layerId, viewId);
    }
    
    if (hasValue(jsObject.requestedActions)) {
        dotNetGeotriggerNotificationOptions.requestedActions = jsObject.requestedActions;
    }
    

    return dotNetGeotriggerNotificationOptions;
}

