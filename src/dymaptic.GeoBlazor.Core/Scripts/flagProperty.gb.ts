import {buildDotNetFlagProperty} from './flagProperty';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsFlagPropertyGenerated(dotNetObject: any): Promise<any> {
    let jsFlagProperty: any = {}
    if (hasValue(dotNetObject.mapGraphic)) {
        let {buildJsGraphic} = await import('./graphic');
        jsFlagProperty.mapGraphic = buildJsGraphic(dotNetObject.mapGraphic) as any;
    }
    if (hasValue(dotNetObject.mapPoint)) {
        let {buildJsPoint} = await import('./point');
        jsFlagProperty.mapPoint = buildJsPoint(dotNetObject.mapPoint) as any;
    }

    if (hasValue(dotNetObject.allTerminals)) {
        jsFlagProperty.allTerminals = dotNetObject.allTerminals;
    }
    if (hasValue(dotNetObject.details)) {
        jsFlagProperty.details = dotNetObject.details;
    }
    if (hasValue(dotNetObject.displayField)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedDisplayField} = dotNetObject.displayField;
        jsFlagProperty.displayField = sanitizedDisplayField;
    }
    if (hasValue(dotNetObject.flagPropertyId)) {
        jsFlagProperty.id = dotNetObject.flagPropertyId;
    }
    if (hasValue(dotNetObject.selectedTerminals)) {
        jsFlagProperty.selectedTerminals = dotNetObject.selectedTerminals;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsFlagProperty);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsFlagProperty;

    let dnInstantiatedObject = await buildDotNetFlagProperty(jsFlagProperty);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for FlagProperty', e);
    }

    return jsFlagProperty;
}

export async function buildDotNetFlagPropertyGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFlagProperty: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.mapGraphic)) {
        let {buildDotNetGraphic} = await import('./graphic');
        dotNetFlagProperty.mapGraphic = buildDotNetGraphic(jsObject.mapGraphic, layerId, viewId);
    }
    if (hasValue(jsObject.mapPoint)) {
        let {buildDotNetPoint} = await import('./point');
        dotNetFlagProperty.mapPoint = buildDotNetPoint(jsObject.mapPoint);
    }
    if (hasValue(jsObject.allTerminals)) {
        dotNetFlagProperty.allTerminals = jsObject.allTerminals;
    }
    if (hasValue(jsObject.details)) {
        dotNetFlagProperty.details = jsObject.details;
    }
    if (hasValue(jsObject.displayField)) {
        dotNetFlagProperty.displayField = jsObject.displayField;
    }
    if (hasValue(jsObject.id)) {
        dotNetFlagProperty.flagPropertyId = jsObject.id;
    }
    if (hasValue(jsObject.selectedTerminals)) {
        dotNetFlagProperty.selectedTerminals = jsObject.selectedTerminals;
    }
    if (hasValue(jsObject.type)) {
        dotNetFlagProperty.type = jsObject.type;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetFlagProperty.id = k;
                break;
            }
        }
    }

    return dotNetFlagProperty;
}

