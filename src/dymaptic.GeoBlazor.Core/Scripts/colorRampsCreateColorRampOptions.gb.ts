import {buildDotNetColorRampsCreateColorRampOptions} from './colorRampsCreateColorRampOptions';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorRampsCreateColorRampOptionsGenerated(dotNetObject: any): Promise<any> {
    let jscolorRampsCreateColorRampOptions: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jscolorRampsCreateColorRampOptions.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }

    if (hasValue(dotNetObject.algorithm)) {
        jscolorRampsCreateColorRampOptions.algorithm = dotNetObject.algorithm;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jscolorRampsCreateColorRampOptions);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jscolorRampsCreateColorRampOptions;

    let dnInstantiatedObject = await buildDotNetColorRampsCreateColorRampOptions(jscolorRampsCreateColorRampOptions);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorRampsCreateColorRampOptions', e);
    }

    return jscolorRampsCreateColorRampOptions;
}

export async function buildDotNetColorRampsCreateColorRampOptionsGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorRampsCreateColorRampOptions: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorRampsCreateColorRampOptions.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.algorithm)) {
        dotNetColorRampsCreateColorRampOptions.algorithm = jsObject.algorithm;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorRampsCreateColorRampOptions.id = k;
                break;
            }
        }
    }

    return dotNetColorRampsCreateColorRampOptions;
}

