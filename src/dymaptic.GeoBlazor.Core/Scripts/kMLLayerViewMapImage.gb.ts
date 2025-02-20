import {buildDotNetKMLLayerViewMapImage} from './kMLLayerViewMapImage';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsKMLLayerViewMapImageGenerated(dotNetObject: any): Promise<any> {
    let jsKMLLayerViewMapImage: any = {}
    if (hasValue(dotNetObject.extent)) {
        let {buildJsExtent} = await import('./extent');
        jsKMLLayerViewMapImage.Extent = buildJsExtent(dotNetObject.extent) as any;
    }

    if (hasValue(dotNetObject.href)) {
        jsKMLLayerViewMapImage.href = dotNetObject.href;
    }
    if (hasValue(dotNetObject.kMLLayerViewMapImageId)) {
        jsKMLLayerViewMapImage.id = dotNetObject.kMLLayerViewMapImageId;
    }
    if (hasValue(dotNetObject.rotation)) {
        jsKMLLayerViewMapImage.rotation = dotNetObject.rotation;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsKMLLayerViewMapImage);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsKMLLayerViewMapImage;

    let dnInstantiatedObject = await buildDotNetKMLLayerViewMapImage(jsKMLLayerViewMapImage);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for KMLLayerViewMapImage', e);
    }

    return jsKMLLayerViewMapImage;
}

export async function buildDotNetKMLLayerViewMapImageGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetKMLLayerViewMapImage: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.Extent)) {
        let {buildDotNetExtent} = await import('./extent');
        dotNetKMLLayerViewMapImage.extent = buildDotNetExtent(jsObject.Extent);
    }
    if (hasValue(jsObject.href)) {
        dotNetKMLLayerViewMapImage.href = jsObject.href;
    }
    if (hasValue(jsObject.id)) {
        dotNetKMLLayerViewMapImage.kMLLayerViewMapImageId = jsObject.id;
    }
    if (hasValue(jsObject.rotation)) {
        dotNetKMLLayerViewMapImage.rotation = jsObject.rotation;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetKMLLayerViewMapImage.id = k;
                break;
            }
        }
    }

    return dotNetKMLLayerViewMapImage;
}

