import {buildDotNetClusterRendererResult} from './clusterRendererResult';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsClusterRendererResultGenerated(dotNetObject: any): Promise<any> {
    let jsClusterRendererResult: any = {}
    if (hasValue(dotNetObject.fields)) {
        let {buildJsAggregateField} = await import('./aggregateField');
        jsClusterRendererResult.fields = await Promise.all(dotNetObject.fields.map(async i => await buildJsAggregateField(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsPieChartRenderer} = await import('./pieChartRenderer');
        jsClusterRendererResult.renderer = await buildJsPieChartRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }


    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsClusterRendererResult);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsClusterRendererResult;

    let dnInstantiatedObject = await buildDotNetClusterRendererResult(jsClusterRendererResult);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ClusterRendererResult', e);
    }

    return jsClusterRendererResult;
}

export async function buildDotNetClusterRendererResultGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetClusterRendererResult: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.fields)) {
        let {buildDotNetAggregateField} = await import('./aggregateField');
        dotNetClusterRendererResult.fields = await Promise.all(jsObject.fields.map(async i => await buildDotNetAggregateField(i)));
    }
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetPieChartRenderer} = await import('./pieChartRenderer');
        dotNetClusterRendererResult.renderer = await buildDotNetPieChartRenderer(jsObject.renderer);
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetClusterRendererResult.id = k;
                break;
            }
        }
    }

    return dotNetClusterRendererResult;
}

