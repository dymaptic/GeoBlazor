import Slider from '@arcgis/core/widgets/Slider';
import {IPropertyWrapper} from './definitions';
import {copyValuesIfExists, hasValue} from "./arcGisJsInterop";

export default class SliderWidgetWrapper implements IPropertyWrapper {
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

    unwrap() {
        return this.slider;
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

    setProperty(prop, value) {
        this.slider[prop] = value;
    }

    getProperty(prop: string) {
        return this.slider[prop];
    }

    addToProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.slider[prop].addMany(value);
        } else {
            this.slider[prop].add(value);
        }
    }

    removeFromProperty(prop: string, value: any) {
        if (Array.isArray(value)) {
            this.slider[prop].removeMany(value);
        } else {
            this.slider[prop].remove(value);
        }
    }
}

export async function buildJsSliderWidget(dotNetObject: any): Promise<any> {
    let slider = new Slider(dotNetObject);
    return new SliderWidgetWrapper(slider);
}

export function buildJsTickConfig(dnTickConfig: any) {
    let tickConfig: any = {
        mode: dnTickConfig.mode ?? undefined,
        values: dnTickConfig.values ?? undefined
    };
    copyValuesIfExists(dnTickConfig, tickConfig, 'labelsVisible');
    if (hasValue(dnTickConfig.tickCreatedFunction)) {
        tickConfig.tickCreatedFunction = (value, tickElement, labelElement) => {
            return new Function('value', 'tickElement', 'labelElement', dnTickConfig.tickCreatedFunction)(value, tickElement, labelElement);
        };
    }
    if (hasValue(dnTickConfig.labelFormatFunction)) {
        tickConfig.labelFormatFunction = (value, type, index) => {
            return new Function('value', 'type', 'index', dnTickConfig.labelFormatFunction)(value, type, index);
        };
    }

    return tickConfig;
}