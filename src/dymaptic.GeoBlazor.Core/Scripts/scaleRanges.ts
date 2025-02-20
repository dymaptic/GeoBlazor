// override generated code in this file
import ScaleRangesGenerated from './scaleRanges.gb';
import ScaleRanges from '@arcgis/core/widgets/ScaleRangeSlider/ScaleRanges';

export default class ScaleRangesWrapper extends ScaleRangesGenerated {

    constructor(component: ScaleRanges) {
        super(component);
    }

}

export async function buildJsScaleRanges(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsScaleRangesGenerated} = await import('./scaleRanges.gb');
    return await buildJsScaleRangesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetScaleRanges(jsObject: any): Promise<any> {
    let {buildDotNetScaleRangesGenerated} = await import('./scaleRanges.gb');
    return await buildDotNetScaleRangesGenerated(jsObject);
}
