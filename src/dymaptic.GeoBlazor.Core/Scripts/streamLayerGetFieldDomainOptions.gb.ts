import {buildDotNetStreamLayerGetFieldDomainOptions} from './streamLayerGetFieldDomainOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsStreamLayerGetFieldDomainOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsStreamLayerGetFieldDomainOptions: any = {}
    if (hasValue(dotNetObject.feature)) {
        let {buildJsGraphic} = await import('./graphic');
        jsStreamLayerGetFieldDomainOptions.feature = buildJsGraphic(dotNetObject.feature) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsStreamLayerGetFieldDomainOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsStreamLayerGetFieldDomainOptions;

    let dnInstantiatedObject = await buildDotNetStreamLayerGetFieldDomainOptions(jsStreamLayerGetFieldDomainOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for StreamLayerGetFieldDomainOptions', e);
    }

    return jsStreamLayerGetFieldDomainOptions;
}

export async function buildDotNetStreamLayerGetFieldDomainOptionsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetStreamLayerGetFieldDomainOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.feature)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetStreamLayerGetFieldDomainOptions.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetStreamLayerGetFieldDomainOptions.id = k;
                break;
            }
        }
    }

    return dotNetStreamLayerGetFieldDomainOptions;
}

