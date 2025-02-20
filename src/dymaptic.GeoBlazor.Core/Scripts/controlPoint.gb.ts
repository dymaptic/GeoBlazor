import {buildDotNetControlPoint} from './controlPoint';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsControlPointGenerated(dotNetObject: any): Promise<any> {
    let jsControlPoint: any = {}
    if (hasValue(dotNetObject.mapPoint)) {
        let {buildJsPoint} = await import('./point');
        jsControlPoint.mapPoint = buildJsPoint(dotNetObject.mapPoint) as any;
    }

    if (hasValue(dotNetObject.sourcePoint)) {
        const {id, dotNetComponentReference, layerId, viewId, ...sanitizedSourcePoint} = dotNetObject.sourcePoint;
        jsControlPoint.sourcePoint = sanitizedSourcePoint;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsControlPoint);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsControlPoint;

    let dnInstantiatedObject = await buildDotNetControlPoint(jsControlPoint);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ControlPoint', e);
    }

    return jsControlPoint;
}

export async function buildDotNetControlPointGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetControlPoint: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.mapPoint)) {
        let {buildDotNetPoint} = await import('./point');
        dotNetControlPoint.mapPoint = buildDotNetPoint(jsObject.mapPoint);
    }
    if (hasValue(jsObject.sourcePoint)) {
        dotNetControlPoint.sourcePoint = jsObject.sourcePoint;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetControlPoint.id = k;
                break;
            }
        }
    }

    return dotNetControlPoint;
}

