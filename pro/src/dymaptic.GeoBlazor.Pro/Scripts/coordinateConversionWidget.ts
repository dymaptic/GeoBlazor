// override generated code in this file
import { hasValue } from './geoBlazorCore';
import CoordinateConversionWidgetGenerated from './coordinateConversionWidget.gb';
import CoordinateConversion from '@arcgis/core/widgets/CoordinateConversion';

export default class CoordinateConversionWidgetWrapper extends CoordinateConversionWidgetGenerated {

    constructor(widget: CoordinateConversion) {
        super(widget);
    }

    async getFormats(): Promise<any> {
        if (!hasValue(this.widget.formats)) {
            return null;
        }

        let { buildDotNetFormat } = await import('./format');
        return await Promise.all(this.widget.formats!.map(async i => await buildDotNetFormat(i, this.layerId, this.viewId)));
    }

    async setFormats(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.widget.formats = [];
        }
        let { buildJsFormat } = await import('./format');
        this.widget.formats = await Promise.all(value.map(async i => await buildJsFormat(i, this.layerId, this.viewId))) as any;
    }
}

export async function buildJsCoordinateConversionWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoordinateConversionWidgetGenerated } = await import('./coordinateConversionWidget.gb');
    return await buildJsCoordinateConversionWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoordinateConversionWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCoordinateConversionWidgetGenerated } = await import('./coordinateConversionWidget.gb');
    return await buildDotNetCoordinateConversionWidgetGenerated(jsObject, layerId, viewId);
}
