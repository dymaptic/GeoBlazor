import {buildDotNetScaleDependentIcons} from './scaleDependentIcons';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsScaleDependentIconsGenerated(dotNetObject: any): Promise<any> {
    let jsScaleDependentIcons: any = {}
    if (hasValue(dotNetObject.maxSize)) {
        let {buildJsScaleDependentStops} = await import('./scaleDependentStops');
        jsScaleDependentIcons.maxSize = await buildJsScaleDependentStops(dotNetObject.maxSize, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.minSize)) {
        let {buildJsScaleDependentStops} = await import('./scaleDependentStops');
        jsScaleDependentIcons.minSize = await buildJsScaleDependentStops(dotNetObject.minSize, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.field)) {
        jsScaleDependentIcons.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.maxDataValue)) {
        jsScaleDependentIcons.maxDataValue = dotNetObject.maxDataValue;
    }
    if (hasValue(dotNetObject.minDataValue)) {
        jsScaleDependentIcons.minDataValue = dotNetObject.minDataValue;
    }
    if (hasValue(dotNetObject.normalizationField)) {
        jsScaleDependentIcons.normalizationField = dotNetObject.normalizationField;
    }
    if (hasValue(dotNetObject.valueExpression)) {
        jsScaleDependentIcons.valueExpression = dotNetObject.valueExpression;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsScaleDependentIcons);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsScaleDependentIcons;

    let dnInstantiatedObject = await buildDotNetScaleDependentIcons(jsScaleDependentIcons);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ScaleDependentIcons', e);
    }

    return jsScaleDependentIcons;
}

export async function buildDotNetScaleDependentIconsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetScaleDependentIcons: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.maxSize)) {
        let {buildDotNetScaleDependentStops} = await import('./scaleDependentStops');
        dotNetScaleDependentIcons.maxSize = await buildDotNetScaleDependentStops(jsObject.maxSize);
    }
    if (hasValue(jsObject.minSize)) {
        let {buildDotNetScaleDependentStops} = await import('./scaleDependentStops');
        dotNetScaleDependentIcons.minSize = await buildDotNetScaleDependentStops(jsObject.minSize);
    }
    if (hasValue(jsObject.field)) {
        dotNetScaleDependentIcons.field = jsObject.field;
    }
    if (hasValue(jsObject.maxDataValue)) {
        dotNetScaleDependentIcons.maxDataValue = jsObject.maxDataValue;
    }
    if (hasValue(jsObject.minDataValue)) {
        dotNetScaleDependentIcons.minDataValue = jsObject.minDataValue;
    }
    if (hasValue(jsObject.normalizationField)) {
        dotNetScaleDependentIcons.normalizationField = jsObject.normalizationField;
    }
    if (hasValue(jsObject.type)) {
        dotNetScaleDependentIcons.type = jsObject.type;
    }
    if (hasValue(jsObject.valueExpression)) {
        dotNetScaleDependentIcons.valueExpression = jsObject.valueExpression;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetScaleDependentIcons.id = k;
                break;
            }
        }
    }

    return dotNetScaleDependentIcons;
}

