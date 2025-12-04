import MeshMaterial from "@arcgis/core/geometry/support/MeshMaterial";
import {
    arcGisObjectRefs, dotNetRefs,
    hasValue,
    jsObjectRefs,
    lookupGeoBlazorId,
    removeCircularReferences,
    sanitize
} from "./geoBlazorCore";

export async function buildJsMeshMaterial(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.color)) {
        let { buildJsMapColor } = await import('./mapColor');
        properties.color = buildJsMapColor(dotNetObject.color) as any;
    }
    if (hasValue(dotNetObject.colorTextureTransform)) {
        let { buildJsMeshTextureTransform } = await import('./meshTextureTransform');
        properties.colorTextureTransform = await buildJsMeshTextureTransform(dotNetObject.colorTextureTransform) as any;
    }
    if (hasValue(dotNetObject.normalTextureTransform)) {
        let { buildJsMeshTextureTransform } = await import('./meshTextureTransform');
        properties.normalTextureTransform = await buildJsMeshTextureTransform(dotNetObject.normalTextureTransform) as any;
    }

    if (hasValue(dotNetObject.alphaCutoff)) {
        properties.alphaCutoff = dotNetObject.alphaCutoff;
    }
    if (hasValue(dotNetObject.alphaMode)) {
        properties.alphaMode = dotNetObject.alphaMode;
    }
    if (hasValue(dotNetObject.colorTexture)) {
        properties.colorTexture = sanitize(dotNetObject.colorTexture);
    }
    if (hasValue(dotNetObject.doubleSided)) {
        properties.doubleSided = dotNetObject.doubleSided;
    }
    if (hasValue(dotNetObject.normalTexture)) {
        properties.normalTexture = sanitize(dotNetObject.normalTexture);
    }
    
    let jsMeshMaterial = new MeshMaterial(properties);

    jsObjectRefs[dotNetObject.id] = jsMeshMaterial;
    arcGisObjectRefs[dotNetObject.id] = jsMeshMaterial;

    return jsMeshMaterial;
}     

export async function buildDotNetMeshMaterial(jsObject: any, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMeshMaterial: any = {};

    if (hasValue(jsObject.color)) {
        let { buildDotNetMapColor } = await import('./mapColor');
        dotNetMeshMaterial.color = buildDotNetMapColor(jsObject.color);
    }

    if (hasValue(jsObject.colorTextureTransform)) {
        let { buildDotNetMeshTextureTransform } = await import('./meshTextureTransform');
        dotNetMeshMaterial.colorTextureTransform = await buildDotNetMeshTextureTransform(jsObject.colorTextureTransform, viewId);
    }

    if (hasValue(jsObject.normalTextureTransform)) {
        let { buildDotNetMeshTextureTransform } = await import('./meshTextureTransform');
        dotNetMeshMaterial.normalTextureTransform = await buildDotNetMeshTextureTransform(jsObject.normalTextureTransform, viewId);
    }

    if (hasValue(jsObject.alphaCutoff)) {
        dotNetMeshMaterial.alphaCutoff = jsObject.alphaCutoff;
    }

    if (hasValue(jsObject.alphaMode)) {
        dotNetMeshMaterial.alphaMode = removeCircularReferences(jsObject.alphaMode);
    }

    if (hasValue(jsObject.colorTexture)) {
        dotNetMeshMaterial.colorTexture = removeCircularReferences(jsObject.colorTexture);
    }

    if (hasValue(jsObject.doubleSided)) {
        dotNetMeshMaterial.doubleSided = jsObject.doubleSided;
    }

    if (hasValue(jsObject.normalTexture)) {
        dotNetMeshMaterial.normalTexture = removeCircularReferences(jsObject.normalTexture);
    }

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetMeshMaterial.id = geoBlazorId;
    } else if (hasValue(viewId)) {
        let dotNetRef = dotNetRefs[viewId!];
        if (hasValue(dotNetRef)) {
            try {
                dotNetMeshMaterial.id = await dotNetRef.invokeMethodAsync('GetId');
            } catch (e) {
                console.error('Error invoking GetId for MeshMaterial', e);
            }
        }
    }
    if (hasValue(dotNetMeshMaterial.id)) {
        jsObjectRefs[dotNetMeshMaterial.id] ??= jsObject;
        arcGisObjectRefs[dotNetMeshMaterial.id] ??= jsObject;
    }

    return dotNetMeshMaterial;
}
