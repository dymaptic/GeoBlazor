import { buildDotNetColorSizeStop } from './colorSizeStop';import ColorSizeStop from '@arcgis/core/renderers/visualVariables/support/ColorSizeStop';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
export async function buildJsColorSizeStopGenerated(dotNetObject: any): Promise<any> {
    let jsColorSizeStop = new ColorSizeStop();
    if (hasValue(dotNetObject.color)) {
        let { buildJsMapColor } = await import('./mapColor');
        jsColorSizeStop.color = buildJsMapColor(dotNetObject.color) as any;
    }

    if (hasValue(dotNetObject.label)) {
        jsColorSizeStop.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.size)) {
        jsColorSizeStop.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.value)) {
        jsColorSizeStop.value = dotNetObject.value;
    }
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSizeStop);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSizeStop;
    
    let dnInstantiatedObject = await buildDotNetColorSizeStop(jsColorSizeStop);
    
    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSizeStop', e);
    }
    
    return jsColorSizeStop;
}
export async function buildDotNetColorSizeStopGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetColorSizeStop: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.color)) {
            let { buildDotNetMapColor } = await import('./mapColor');
            dotNetColorSizeStop.color = buildDotNetMapColor(jsObject.color);
        }
        if (hasValue(jsObject.label)) {
            dotNetColorSizeStop.label = jsObject.label;
        }
        if (hasValue(jsObject.size)) {
            dotNetColorSizeStop.size = jsObject.size;
        }
        if (hasValue(jsObject.value)) {
            dotNetColorSizeStop.value = jsObject.value;
        }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSizeStop.id = k;
                break;
            }
        }
    }

    return dotNetColorSizeStop;
}

