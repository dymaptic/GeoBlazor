import {buildDotNetCoverageDescriptionV201EoMetadata} from './coverageDescriptionV201EoMetadata';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCoverageDescriptionV201EoMetadataGenerated(dotNetObject: any): Promise<any> {
    let jsCoverageDescriptionV201EoMetadata: any = {}
    if (hasValue(dotNetObject.observation)) {
        let {buildJsCoverageDescriptionV201EoMetadataObservation} = await import('./coverageDescriptionV201EoMetadataObservation');
        jsCoverageDescriptionV201EoMetadata.observation = await buildJsCoverageDescriptionV201EoMetadataObservation(dotNetObject.observation, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCoverageDescriptionV201EoMetadata);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCoverageDescriptionV201EoMetadata;

    let dnInstantiatedObject = await buildDotNetCoverageDescriptionV201EoMetadata(jsCoverageDescriptionV201EoMetadata);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CoverageDescriptionV201EoMetadata', e);
    }

    return jsCoverageDescriptionV201EoMetadata;
}

export async function buildDotNetCoverageDescriptionV201EoMetadataGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCoverageDescriptionV201EoMetadata: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.observation)) {
        let {buildDotNetCoverageDescriptionV201EoMetadataObservation} = await import('./coverageDescriptionV201EoMetadataObservation');
        dotNetCoverageDescriptionV201EoMetadata.observation = await buildDotNetCoverageDescriptionV201EoMetadataObservation(jsObject.observation);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCoverageDescriptionV201EoMetadata.id = k;
                break;
            }
        }
    }

    return dotNetCoverageDescriptionV201EoMetadata;
}

