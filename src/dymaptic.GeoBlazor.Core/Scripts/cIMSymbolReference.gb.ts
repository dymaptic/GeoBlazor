import {buildDotNetCIMSymbolReference} from './cIMSymbolReference';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsCIMSymbolReferenceGenerated(dotNetObject: any): Promise<any> {
    let jsCIMSymbolReference: any = {}
    if (hasValue(dotNetObject.symbol)) {
        let {buildJsSymbol} = await import('./symbol');
        jsCIMSymbolReference.symbol = buildJsSymbol(dotNetObject.symbol) as any;
    }

    if (hasValue(dotNetObject.maxDistance)) {
        jsCIMSymbolReference.maxDistance = dotNetObject.maxDistance;
    }
    if (hasValue(dotNetObject.maxScale)) {
        jsCIMSymbolReference.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minDistance)) {
        jsCIMSymbolReference.minDistance = dotNetObject.minDistance;
    }
    if (hasValue(dotNetObject.minScale)) {
        jsCIMSymbolReference.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.primitiveOverrides)) {
        const {
            id,
            dotNetComponentReference,
            layerId,
            viewId,
            ...sanitizedPrimitiveOverrides
        } = dotNetObject.primitiveOverrides;
        jsCIMSymbolReference.primitiveOverrides = sanitizedPrimitiveOverrides;
    }
    if (hasValue(dotNetObject.scaleDependentSizeVariation)) {
        const {
            id,
            dotNetComponentReference,
            layerId,
            viewId,
            ...sanitizedScaleDependentSizeVariation
        } = dotNetObject.scaleDependentSizeVariation;
        jsCIMSymbolReference.scaleDependentSizeVariation = sanitizedScaleDependentSizeVariation;
    }
    if (hasValue(dotNetObject.stylePath)) {
        jsCIMSymbolReference.stylePath = dotNetObject.stylePath;
    }
    if (hasValue(dotNetObject.symbolName)) {
        jsCIMSymbolReference.symbolName = dotNetObject.symbolName;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsCIMSymbolReference);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsCIMSymbolReference;

    let dnInstantiatedObject = await buildDotNetCIMSymbolReference(jsCIMSymbolReference);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for CIMSymbolReference', e);
    }

    return jsCIMSymbolReference;
}

export async function buildDotNetCIMSymbolReferenceGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetCIMSymbolReference: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.symbol)) {
        let {buildDotNetSymbol} = await import('./symbol');
        dotNetCIMSymbolReference.symbol = buildDotNetSymbol(jsObject.symbol);
    }
    if (hasValue(jsObject.maxDistance)) {
        dotNetCIMSymbolReference.maxDistance = jsObject.maxDistance;
    }
    if (hasValue(jsObject.maxScale)) {
        dotNetCIMSymbolReference.maxScale = jsObject.maxScale;
    }
    if (hasValue(jsObject.minDistance)) {
        dotNetCIMSymbolReference.minDistance = jsObject.minDistance;
    }
    if (hasValue(jsObject.minScale)) {
        dotNetCIMSymbolReference.minScale = jsObject.minScale;
    }
    if (hasValue(jsObject.primitiveOverrides)) {
        dotNetCIMSymbolReference.primitiveOverrides = jsObject.primitiveOverrides;
    }
    if (hasValue(jsObject.scaleDependentSizeVariation)) {
        dotNetCIMSymbolReference.scaleDependentSizeVariation = jsObject.scaleDependentSizeVariation;
    }
    if (hasValue(jsObject.stylePath)) {
        dotNetCIMSymbolReference.stylePath = jsObject.stylePath;
    }
    if (hasValue(jsObject.symbolName)) {
        dotNetCIMSymbolReference.symbolName = jsObject.symbolName;
    }
    if (hasValue(jsObject.type)) {
        dotNetCIMSymbolReference.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetCIMSymbolReference.id = k;
                break;
            }
        }
    }

    return dotNetCIMSymbolReference;
}

