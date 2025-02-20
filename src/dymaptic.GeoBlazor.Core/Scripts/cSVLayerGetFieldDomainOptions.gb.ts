import {buildDotNetCSVLayerGetFieldDomainOptions} from './cSVLayerGetFieldDomainOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCSVLayerGetFieldDomainOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsCSVLayerGetFieldDomainOptions: any = {}
    if (hasValue(dotNetObject.feature)) {
        let {buildJsGraphic} = await import('./graphic');
        jsCSVLayerGetFieldDomainOptions.feature = buildJsGraphic(dotNetObject.feature) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCSVLayerGetFieldDomainOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCSVLayerGetFieldDomainOptions;

    let dnInstantiatedObject = await buildDotNetCSVLayerGetFieldDomainOptions(jsCSVLayerGetFieldDomainOptions, layerId, viewId);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CSVLayerGetFieldDomainOptions', e);
    }

    return jsCSVLayerGetFieldDomainOptions;
}

export async function buildDotNetCSVLayerGetFieldDomainOptionsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCSVLayerGetFieldDomainOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.feature)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetCSVLayerGetFieldDomainOptions.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCSVLayerGetFieldDomainOptions.id = k;
                break;
            }
        }
    }

    return dotNetCSVLayerGetFieldDomainOptions;
}

