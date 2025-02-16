import {buildJsRasterStretchRenderer} from "./jsBuilder";

export async function buildJsImageryRenderer(dnRenderer: any, layerId: string | null, viewId: string | null) {
    switch (dnRenderer?.imageryRendererType) {
        case 'unique-value':
            let { buildJsUniqueValueRenderer } = await import('./uniqueValueRenderer');
            return await buildJsUniqueValueRenderer(dnRenderer, layerId, viewId);
        case 'raster-stretch':
            return buildJsRasterStretchRenderer(dnRenderer);
    }

    return null;
}