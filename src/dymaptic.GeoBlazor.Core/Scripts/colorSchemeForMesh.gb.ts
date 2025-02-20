import {buildDotNetColorSchemeForMesh} from './colorSchemeForMesh';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsColorSchemeForMeshGenerated(dotNetObject: any): Promise<any> {
    let jsColorSchemeForMesh: any = {}
    if (hasValue(dotNetObject.colors)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForMesh.colors = dotNetObject.colors.map(i => buildJsMapColor(i)) as any;
    }
    if (hasValue(dotNetObject.colorsForClassBreaks)) {
        let {buildJsColorSchemeForMeshColorsForClassBreaks} = await import('./colorSchemeForMeshColorsForClassBreaks');
        jsColorSchemeForMesh.colorsForClassBreaks = await Promise.all(dotNetObject.colorsForClassBreaks.map(async i => await buildJsColorSchemeForMeshColorsForClassBreaks(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.noDataColor)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsColorSchemeForMesh.noDataColor = buildJsMapColor(dotNetObject.noDataColor) as any;
    }

    if (hasValue(dotNetObject.colorSchemeForMeshId)) {
        jsColorSchemeForMesh.id = dotNetObject.colorSchemeForMeshId;
    }
    if (hasValue(dotNetObject.name)) {
        jsColorSchemeForMesh.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsColorSchemeForMesh.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.tags)) {
        jsColorSchemeForMesh.tags = dotNetObject.tags;
    }
    if (hasValue(dotNetObject.theme)) {
        jsColorSchemeForMesh.theme = dotNetObject.theme;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsColorSchemeForMesh);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsColorSchemeForMesh;

    let dnInstantiatedObject = await buildDotNetColorSchemeForMesh(jsColorSchemeForMesh);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for ColorSchemeForMesh', e);
    }

    return jsColorSchemeForMesh;
}

export async function buildDotNetColorSchemeForMeshGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetColorSchemeForMesh: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colors)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForMesh.colors = jsObject.colors.map(i => buildDotNetMapColor(i));
    }
    if (hasValue(jsObject.colorsForClassBreaks)) {
        let {buildDotNetColorSchemeForMeshColorsForClassBreaks} = await import('./colorSchemeForMeshColorsForClassBreaks');
        dotNetColorSchemeForMesh.colorsForClassBreaks = await Promise.all(jsObject.colorsForClassBreaks.map(async i => await buildDotNetColorSchemeForMeshColorsForClassBreaks(i)));
    }
    if (hasValue(jsObject.noDataColor)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetColorSchemeForMesh.noDataColor = buildDotNetMapColor(jsObject.noDataColor);
    }
    if (hasValue(jsObject.id)) {
        dotNetColorSchemeForMesh.colorSchemeForMeshId = jsObject.id;
    }
    if (hasValue(jsObject.name)) {
        dotNetColorSchemeForMesh.name = jsObject.name;
    }
    if (hasValue(jsObject.opacity)) {
        dotNetColorSchemeForMesh.opacity = jsObject.opacity;
    }
    if (hasValue(jsObject.tags)) {
        dotNetColorSchemeForMesh.tags = jsObject.tags;
    }
    if (hasValue(jsObject.theme)) {
        dotNetColorSchemeForMesh.theme = jsObject.theme;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetColorSchemeForMesh.id = k;
                break;
            }
        }
    }

    return dotNetColorSchemeForMesh;
}

