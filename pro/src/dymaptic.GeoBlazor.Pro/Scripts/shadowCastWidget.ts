// override generated code in this file
import ShadowCastWidgetGenerated from './shadowCastWidget.gb';
import ShadowCast from '@arcgis/core/widgets/ShadowCast';

export default class ShadowCastWidgetWrapper extends ShadowCastWidgetGenerated {

    constructor(widget: ShadowCast) {
        super(widget);
    }
    
}

export async function buildJsShadowCastWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsShadowCastWidgetGenerated } = await import('./shadowCastWidget.gb');
    return await buildJsShadowCastWidgetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetShadowCastWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetShadowCastWidgetGenerated } = await import('./shadowCastWidget.gb');
    return await buildDotNetShadowCastWidgetGenerated(jsObject, layerId, viewId);
}
