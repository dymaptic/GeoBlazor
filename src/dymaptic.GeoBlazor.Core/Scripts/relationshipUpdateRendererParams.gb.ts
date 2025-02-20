import {buildDotNetRelationshipUpdateRendererParams} from './relationshipUpdateRendererParams';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRelationshipUpdateRendererParamsGenerated(dotNetObject: any): Promise<any> {
    let jsrelationshipUpdateRendererParams: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsrelationshipUpdateRendererParams.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.renderer)) {
        let {buildJsUniqueValueRenderer} = await import('./uniqueValueRenderer');
        jsrelationshipUpdateRendererParams.renderer = await buildJsUniqueValueRenderer(dotNetObject.renderer, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.field1)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedField1} = dotNetObject.field1;
        jsrelationshipUpdateRendererParams.field1 = sanitizedField1;
    }
    if (hasValue(dotNetObject.field2)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedField2} = dotNetObject.field2;
        jsrelationshipUpdateRendererParams.field2 = sanitizedField2;
    }
    if (hasValue(dotNetObject.focus)) {
        jsrelationshipUpdateRendererParams.focus = dotNetObject.focus;
    }
    if (hasValue(dotNetObject.numClasses)) {
        jsrelationshipUpdateRendererParams.numClasses = dotNetObject.numClasses;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsrelationshipUpdateRendererParams);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsrelationshipUpdateRendererParams;

    let dnInstantiatedObject = await buildDotNetRelationshipUpdateRendererParams(jsrelationshipUpdateRendererParams);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RelationshipUpdateRendererParams', e);
    }

    return jsrelationshipUpdateRendererParams;
}

export async function buildDotNetRelationshipUpdateRendererParamsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelationshipUpdateRendererParams: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetRelationshipUpdateRendererParams.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetUniqueValueRenderer} = await import('./uniqueValueRenderer');
        dotNetRelationshipUpdateRendererParams.renderer = await buildDotNetUniqueValueRenderer(jsObject.renderer);
    }
    if (hasValue(jsObject.field1)) {
        dotNetRelationshipUpdateRendererParams.field1 = jsObject.field1;
    }
    if (hasValue(jsObject.field2)) {
        dotNetRelationshipUpdateRendererParams.field2 = jsObject.field2;
    }
    if (hasValue(jsObject.focus)) {
        dotNetRelationshipUpdateRendererParams.focus = jsObject.focus;
    }
    if (hasValue(jsObject.numClasses)) {
        dotNetRelationshipUpdateRendererParams.numClasses = jsObject.numClasses;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRelationshipUpdateRendererParams.id = k;
                break;
            }
        }
    }

    return dotNetRelationshipUpdateRendererParams;
}

