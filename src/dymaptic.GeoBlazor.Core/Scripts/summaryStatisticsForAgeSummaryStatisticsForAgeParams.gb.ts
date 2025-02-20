import {
    buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams
} from './summaryStatisticsForAgeSummaryStatisticsForAgeParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated(dotNetObject: any): Promise<any> {
    let jssummaryStatisticsForAgeSummaryStatisticsForAgeParams: any = {}
    if (hasValue(dotNetObject.layer)) {
        let {buildJsLayer} = await import('./layer');
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.layer = await buildJsLayer(dotNetObject.layer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.endTime)) {
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.endTime = dotNetObject.endTime;
    }
    if (hasValue(dotNetObject.signal)) {
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.signal = dotNetObject.signal;
    }
    if (hasValue(dotNetObject.startTime)) {
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.startTime = dotNetObject.startTime;
    }
    if (hasValue(dotNetObject.unit)) {
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.unit = dotNetObject.unit;
    }
    if (hasValue(dotNetObject.view)) {
        jssummaryStatisticsForAgeSummaryStatisticsForAgeParams.view = dotNetObject.view;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jssummaryStatisticsForAgeSummaryStatisticsForAgeParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jssummaryStatisticsForAgeSummaryStatisticsForAgeParams;

    let dnInstantiatedObject = await buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams(jssummaryStatisticsForAgeSummaryStatisticsForAgeParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SummaryStatisticsForAgeSummaryStatisticsForAgeParams', e);
    }

    return jssummaryStatisticsForAgeSummaryStatisticsForAgeParams;
}

export async function buildDotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.endTime)) {
        dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.endTime = jsObject.endTime;
    }
    if (hasValue(jsObject.signal)) {
        dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.signal = jsObject.signal;
    }
    if (hasValue(jsObject.startTime)) {
        dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.startTime = jsObject.startTime;
    }
    if (hasValue(jsObject.unit)) {
        dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.unit = jsObject.unit;
    }
    if (hasValue(jsObject.view)) {
        dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.view = jsObject.view;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams.id = k;
                break;
            }
        }
    }

    return dotNetSummaryStatisticsForAgeSummaryStatisticsForAgeParams;
}

