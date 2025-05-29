// override generated code in this file

import {hasValue} from "./arcGisJsInterop";

export async function buildJsWMTSSublayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // custom implementation, don't instantiate the sublayer class directly, it breaks the layer constructor
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSublayer: any = {};
    if (hasValue(dotNetObject.fullExtent)) {
        let { buildJsExtent } = await import('./extent');
        jsSublayer.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.styles) && dotNetObject.styles.length > 0) {
        let { buildJsWMTSStyle } = await import('./wMTSStyle');
        jsSublayer.styles = await Promise.all(dotNetObject.styles.map(async i => await buildJsWMTSStyle(i))) as any;
    }
    if (hasValue(dotNetObject.tileMatrixSets) && dotNetObject.tileMatrixSets.length > 0) {
        let { buildJsTileMatrixSet } = await import('./tileMatrixSet');
        jsSublayer.tileMatrixSets = await Promise.all(dotNetObject.tileMatrixSets.map(async i => await buildJsTileMatrixSet(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.description)) {
        jsSublayer.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.imageFormat)) {
        jsSublayer.imageFormat = dotNetObject.imageFormat;
    }
    if (hasValue(dotNetObject.imageFormats) && dotNetObject.imageFormats.length > 0) {
        jsSublayer.imageFormats = dotNetObject.imageFormats;
    }
    if (hasValue(dotNetObject.styleId)) {
        jsSublayer.styleId = dotNetObject.styleId;
    }
    if (hasValue(dotNetObject.tileMatrixSetId)) {
        jsSublayer.tileMatrixSetId = dotNetObject.tileMatrixSetId;
    }
    if (hasValue(dotNetObject.title)) {
        jsSublayer.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.wMTSSublayerId)) {
        jsSublayer.id = dotNetObject.wMTSSublayerId;
    }
    return jsSublayer;
}

export async function buildDotNetWMTSSublayer(jsObject: any): Promise<any> {
    let {buildDotNetWMTSSublayerGenerated} = await import('./wMTSSublayer.gb');
    return await buildDotNetWMTSSublayerGenerated(jsObject);
}
