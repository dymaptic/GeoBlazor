import {buildDotNetBaseLayerViewGL2DRenderRenderParameters} from './baseLayerViewGL2DRenderRenderParameters';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsBaseLayerViewGL2DRenderRenderParametersGenerated(dotNetObject: any): Promise<any> {
    let jsBaseLayerViewGL2DRenderRenderParameters: any = {}
    if (hasValue(dotNetObject.state)) {
        let {buildJsViewState} = await import('./viewState');
        jsBaseLayerViewGL2DRenderRenderParameters.state = await buildJsViewState(dotNetObject.state, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.context)) {
        jsBaseLayerViewGL2DRenderRenderParameters.context = dotNetObject.context;
    }
    if (hasValue(dotNetObject.stationary)) {
        jsBaseLayerViewGL2DRenderRenderParameters.stationary = dotNetObject.stationary;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsBaseLayerViewGL2DRenderRenderParameters);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsBaseLayerViewGL2DRenderRenderParameters;

    let dnInstantiatedObject = await buildDotNetBaseLayerViewGL2DRenderRenderParameters(jsBaseLayerViewGL2DRenderRenderParameters);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BaseLayerViewGL2DRenderRenderParameters', e);
    }

    return jsBaseLayerViewGL2DRenderRenderParameters;
}

export async function buildDotNetBaseLayerViewGL2DRenderRenderParametersGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetBaseLayerViewGL2DRenderRenderParameters: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.state)) {
        let {buildDotNetViewState} = await import('./viewState');
        dotNetBaseLayerViewGL2DRenderRenderParameters.state = await buildDotNetViewState(jsObject.state);
    }
    if (hasValue(jsObject.context)) {
        dotNetBaseLayerViewGL2DRenderRenderParameters.context = jsObject.context;
    }
    if (hasValue(jsObject.stationary)) {
        dotNetBaseLayerViewGL2DRenderRenderParameters.stationary = jsObject.stationary;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetBaseLayerViewGL2DRenderRenderParameters.id = k;
                break;
            }
        }
    }

    return dotNetBaseLayerViewGL2DRenderRenderParameters;
}

