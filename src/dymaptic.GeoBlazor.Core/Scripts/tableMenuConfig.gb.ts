import {buildDotNetTableMenuConfig} from './tableMenuConfig';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsTableMenuConfigGenerated(dotNetObject: any): Promise<any> {
    let jsTableMenuConfig: any = {}
    if (hasValue(dotNetObject.items)) {
        let {buildJsTableMenuItemConfig} = await import('./tableMenuItemConfig');
        jsTableMenuConfig.items = await Promise.all(dotNetObject.items.map(async i => await buildJsTableMenuItemConfig(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.disabled)) {
        jsTableMenuConfig.disabled = dotNetObject.disabled;
    }
    if (hasValue(dotNetObject.open)) {
        jsTableMenuConfig.open = dotNetObject.open;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsTableMenuConfig);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsTableMenuConfig;

    let dnInstantiatedObject = await buildDotNetTableMenuConfig(jsTableMenuConfig);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for TableMenuConfig', e);
    }

    return jsTableMenuConfig;
}

export async function buildDotNetTableMenuConfigGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetTableMenuConfig: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.items)) {
        let {buildDotNetTableMenuItemConfig} = await import('./tableMenuItemConfig');
        dotNetTableMenuConfig.items = await Promise.all(jsObject.items.map(async i => await buildDotNetTableMenuItemConfig(i)));
    }
    if (hasValue(jsObject.disabled)) {
        dotNetTableMenuConfig.disabled = jsObject.disabled;
    }
    if (hasValue(jsObject.open)) {
        dotNetTableMenuConfig.open = jsObject.open;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetTableMenuConfig.id = k;
                break;
            }
        }
    }

    return dotNetTableMenuConfig;
}

