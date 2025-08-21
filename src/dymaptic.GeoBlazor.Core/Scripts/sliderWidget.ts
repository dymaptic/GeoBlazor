import SliderWidgetGenerated from './sliderWidget.gb';
import Slider from '@arcgis/core/widgets/Slider';
import * as reactiveUtils from "@arcgis/core/core/reactiveUtils";

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
    let jsObject = await buildJsSliderWidgetGenerated(dotNetObject, layerId, viewId);

    reactiveUtils.watch(
        () => jsObject.values,
        async () => {
                await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsValueChanged', jsObject.values);
        }
    );
    
    return jsObject;
}

export async function buildDotNetSliderWidget(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSliderWidgetGenerated} = await import('./sliderWidget.gb');
    return await buildDotNetSliderWidgetGenerated(jsObject, viewId);
}
