import {buildDotNetFeatureSetInfo} from './featureSetInfo';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFeatureSetInfoGenerated(dotNetObject: any): Promise<any> {
    let jsFeatureSetInfo: any = {}
    if (hasValue(dotNetObject.featureSet)) {
        let {buildJsFeatureSet} = await import('./featureSet');
        jsFeatureSetInfo.featureSet = buildJsFeatureSet(dotNetObject.featureSet) as any;
    }
    if (hasValue(dotNetObject.layer)) {
        let {buildJsFeatureLayer} = await import('./featureLayer');
        jsFeatureSetInfo.layer = await buildJsFeatureLayer(dotNetObject.layer, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFeatureSetInfo);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFeatureSetInfo;

    let dnInstantiatedObject = await buildDotNetFeatureSetInfo(jsFeatureSetInfo);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FeatureSetInfo', e);
    }

    return jsFeatureSetInfo;
}

export async function buildDotNetFeatureSetInfoGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFeatureSetInfo: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.featureSet)) {
        let {buildDotNetFeatureSet} = await import('./featureSet');
        dotNetFeatureSetInfo.featureSet = await buildDotNetFeatureSet(jsObject.featureSet, layerId, viewId);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFeatureSetInfo.id = k;
                break;
            }
        }
    }

    return dotNetFeatureSetInfo;
}

