import {generateSerializableJson, hasValue} from "./geoBlazorCore";

export async function buildJsIMeshComponentMaterial(dotNetObject: any): Promise<any> {
    if (hasValue(dotNetObject.emissiveColor)
        || hasValue(dotNetObject.emissiveTexture)
        || hasValue(dotNetObject.emissiveTextureTransform)
        || hasValue(dotNetObject.metallic)
        || hasValue(dotNetObject.metallicRoughnessTexture)
        || hasValue(dotNetObject.occlusionTexture)
        || hasValue(dotNetObject.occlusionTextureTransform)
        || hasValue(dotNetObject.roughness)) {
        let { buildJsMeshMaterialMetallicRoughness } = await import('./meshMaterialMetallicRoughness');
        return await buildJsMeshMaterialMetallicRoughness(dotNetObject);
    }
    
    let { buildJsMeshMaterial } = await import('./meshMaterial');
    return await buildJsMeshMaterial(dotNetObject);
}

export async function buildDotNetIMeshComponentMaterial(jsObject: any): Promise<any> {
    return generateSerializableJson(jsObject);
}
