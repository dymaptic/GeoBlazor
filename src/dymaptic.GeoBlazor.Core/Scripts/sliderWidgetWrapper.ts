import {buildDotNetGraphic} from "./dotNetBuilder";
import {DotNetGraphic} from "./definitions";
import {dotNetRefs, graphicsRefs} from "./arcGisJsInterop";
import {buildJsSymbol} from "./jsBuilder";
import Symbol from "@arcgis/core/symbols/Symbol";
import Slider from "@arcgis/core/widgets/Slider";

export default class SliderWidgetWrapper {
    private slider: Slider;

    constructor(slider: Slider) {
        this.slider = slider;
        // set all properties from graphic
        for (let prop in slider) {
            if (prop.hasOwnProperty(prop)) {
                this[prop] = slider[prop];
            }
        }
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