// override generated code in this file
import BasemapGalleryWidgetGenerated from './basemapGalleryWidget.gb';
import BasemapGallery from '@arcgis/core/widgets/BasemapGallery';

export default class BasemapGalleryWidgetWrapper extends BasemapGalleryWidgetGenerated {

    constructor(widget: BasemapGallery) {
        super(widget);
    }

}

export async function buildJsBasemapGalleryWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBasemapGalleryWidgetGenerated} = await import('./basemapGalleryWidget.gb');
    return await buildJsBasemapGalleryWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBasemapGalleryWidget(jsObject: any): Promise<any> {
    let {buildDotNetBasemapGalleryWidgetGenerated} = await import('./basemapGalleryWidget.gb');
    return await buildDotNetBasemapGalleryWidgetGenerated(jsObject);
}
