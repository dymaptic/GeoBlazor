import SliderWidgetGenerated from './sliderWidget.gb';
import Slider from '@arcgis/core/widgets/Slider';

export default class SliderWidgetWrapper extends SliderWidgetGenerated {
    constructor(widget: Slider) {
        super(widget);
    }

    getEffectiveSegmentElements() {
        return this.widget.effectiveSegmentElements;
    }

    getLabelElements() {
        return this.widget.labelElements;
    }

    getLabels() {
        return this.widget.labels;
    }

    getMaxLabelElement() {
        return this.widget.maxLabelElement;
    }

    getMinLabelElement() {
        return this.widget.minLabelElement;
    }

    getSegmentElements() {
        return this.widget.segmentElements;
    }

    getState() {
        return this.widget.state;
    }

    getThumbElements() {
        return this.widget.thumbElements;
    }

    getTickElements() {
        return this.widget.tickElements;
    }

    getTrackElement() {
        return this.widget.trackElement;
    }


}

export async function buildJsSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSliderWidgetGenerated } = await import('./sliderWidget.gb');
    return await buildJsSliderWidgetGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSliderWidget(jsObject: any): Promise<any> {
    let {buildDotNetSliderWidgetGenerated} = await import('./sliderWidget.gb');
    return await buildDotNetSliderWidgetGenerated(jsObject);
}
