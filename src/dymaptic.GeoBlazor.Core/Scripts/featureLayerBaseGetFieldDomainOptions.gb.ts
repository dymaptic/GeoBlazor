import {buildDotNetFeatureLayerBaseGetFieldDomainOptions} from './featureLayerBaseGetFieldDomainOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFeatureLayerBaseGetFieldDomainOptionsGenerated(dotNetObject: any): Promise<any> {
    let jsFeatureLayerBaseGetFieldDomainOptions: any = {}
    if (hasValue(dotNetObject.feature)) {
        let {buildJsGraphic} = await import('./graphic');
        jsFeatureLayerBaseGetFieldDomainOptions.feature = buildJsGraphic(dotNetObject.feature) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureLayerBaseGetFieldDomainOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureLayerBaseGetFieldDomainOptions;

    let dnInstantiatedObject = await buildDotNetFeatureLayerBaseGetFieldDomainOptions(jsFeatureLayerBaseGetFieldDomainOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FeatureLayerBaseGetFieldDomainOptions', e);
    }

    return jsFeatureLayerBaseGetFieldDomainOptions;
}

export async function buildDotNetFeatureLayerBaseGetFieldDomainOptionsGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFeatureLayerBaseGetFieldDomainOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.feature)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetFeatureLayerBaseGetFieldDomainOptions.feature = buildDotNetGraphic(jsObject.feature, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFeatureLayerBaseGetFieldDomainOptions.id = k;
                break;
            }
        }
    }

    return dotNetFeatureLayerBaseGetFieldDomainOptions;
}

