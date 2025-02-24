import SliderWidgetGenerated from './sliderWidget.gb';
import Slider from '@arcgis/core/widgets/Slider';

export default class SliderWidgetWrapper extends SliderWidgetGenerated {
    private slider: Slider;

    constructor(widget: Slider) {
        super(widget);
    }

    getEffectiveSegmentElements() {
        return this.slider.effectiveSegmentElements;
    }

    getLabelElements() {
        return this.slider.labelElements;
    }

    getLabels() {
        return this.slider.labels;
    }

    getMaxLabelElement() {
        return this.slider.maxLabelElement;
    }

    getMinLabelElement() {
        return this.slider.minLabelElement;
    }

    getSegmentElements() {
        return this.slider.segmentElements;
    }

    getState() {
        return this.slider.state;
    }

    getThumbElements() {
        return this.slider.thumbElements;
    }

    getTickElements() {
        return this.slider.tickElements;
    }

    getTrackElement() {
        return this.slider.trackElement;
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
