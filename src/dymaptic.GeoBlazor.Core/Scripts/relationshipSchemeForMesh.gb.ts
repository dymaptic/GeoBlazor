import {buildDotNetRelationshipSchemeForMesh} from './relationshipSchemeForMesh';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';

export async function buildJsRelationshipSchemeForMeshGenerated(dotNetObject: any): Promise<any> {
    let jsRelationshipSchemeForMesh: any = {}
    if (hasValue(dotNetObject.colorsForClassBreaks)) {
        let {buildJsRelationshipSchemeForMeshColorsForClassBreaks} = await import('./relationshipSchemeForMeshColorsForClassBreaks');
        jsRelationshipSchemeForMesh.colorsForClassBreaks = await Promise.all(dotNetObject.colorsForClassBreaks.map(async i => await buildJsRelationshipSchemeForMeshColorsForClassBreaks(i, layerId, viewId))) as any;
    }
    if (hasValue(dotNetObject.noDataColor)) {
        let {buildJsMapColor} = await import('./mapColor');
        jsRelationshipSchemeForMesh.noDataColor = buildJsMapColor(dotNetObject.noDataColor) as any;
    }

    if (hasValue(dotNetObject.name)) {
        jsRelationshipSchemeForMesh.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.opacity)) {
        jsRelationshipSchemeForMesh.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.relationshipSchemeForMeshId)) {
        jsRelationshipSchemeForMesh.id = dotNetObject.relationshipSchemeForMeshId;
    }
    if (hasValue(dotNetObject.tags)) {
        jsRelationshipSchemeForMesh.tags = dotNetObject.tags;
    }

    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsRelationshipSchemeForMesh);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;
    arcGisObjectRefs[dotNetObject.id] = jsRelationshipSchemeForMesh;

    let dnInstantiatedObject = await buildDotNetRelationshipSchemeForMesh(jsRelationshipSchemeForMesh);

    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for RelationshipSchemeForMesh', e);
    }

    return jsRelationshipSchemeForMesh;
}

export async function buildDotNetRelationshipSchemeForMeshGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetRelationshipSchemeForMesh: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
    if (hasValue(jsObject.colorsForClassBreaks)) {
        let {buildDotNetRelationshipSchemeForMeshColorsForClassBreaks} = await import('./relationshipSchemeForMeshColorsForClassBreaks');
        dotNetRelationshipSchemeForMesh.colorsForClassBreaks = await Promise.all(jsObject.colorsForClassBreaks.map(async i => await buildDotNetRelationshipSchemeForMeshColorsForClassBreaks(i)));
    }
    if (hasValue(jsObject.noDataColor)) {
        let {buildDotNetMapColor} = await import('./mapColor');
        dotNetRelationshipSchemeForMesh.noDataColor = buildDotNetMapColor(jsObject.noDataColor);
    }
    if (hasValue(jsObject.name)) {
        dotNetRelationshipSchemeForMesh.name = jsObject.name;
    }
    if (hasValue(jsObject.opacity)) {
        dotNetRelationshipSchemeForMesh.opacity = jsObject.opacity;
    }
    if (hasValue(jsObject.id)) {
        dotNetRelationshipSchemeForMesh.relationshipSchemeForMeshId = jsObject.id;
    }
    if (hasValue(jsObject.tags)) {
        dotNetRelationshipSchemeForMesh.tags = jsObject.tags;
    }

    if (Object.values(arcGisObjectRefs).includes(jsObject)) {
        for (const k of Object.keys(arcGisObjectRefs)) {
            if (arcGisObjectRefs[k] === jsObject) {
                dotNetRelationshipSchemeForMesh.id = k;
                break;
            }
        }
    }

    return dotNetRelationshipSchemeForMesh;
}

