// override generated code in this file
import FullscreenWidgetGenerated from './fullscreenWidget.gb';
import Fullscreen from '@arcgis/core/widgets/Fullscreen';

export default class FullscreenWidgetWrapper extends FullscreenWidgetGenerated {

    constructor(widget: Fullscreen) {
        super(widget);
    }
    
}

export async function buildJsFullscreenWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFullscreenWidgetGenerated } = await import('./fullscreenWidget.gb');
    return await buildJsFullscreenWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFullscreenWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFullscreenWidgetGenerated } = await import('./fullscreenWidget.gb');
    return await buildDotNetFullscreenWidgetGenerated(jsObject, layerId, viewId);
}
