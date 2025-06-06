// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import SliderViewModel from '@arcgis/core/widgets/Slider/SliderViewModel';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class SliderViewModelGenerated implements IPropertyWrapper {
    public component: SliderViewModel;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: SliderViewModel) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {

        if (hasValue(dotNetObject.effectiveMax)) {
            this.component.effectiveMax = dotNetObject.effectiveMax;
        }
        if (hasValue(dotNetObject.effectiveMin)) {
            this.component.effectiveMin = dotNetObject.effectiveMin;
        }
        if (hasValue(dotNetObject.max)) {
            this.component.max = dotNetObject.max;
        }
        if (hasValue(dotNetObject.min)) {
            this.component.min = dotNetObject.min;
        }
        if (hasValue(dotNetObject.precision)) {
            this.component.precision = dotNetObject.precision;
        }
        if (hasValue(dotNetObject.thumbsConstrained)) {
            this.component.thumbsConstrained = dotNetObject.thumbsConstrained;
        }
        if (hasValue(dotNetObject.values) && dotNetObject.values.length > 0) {
            this.component.values = dotNetObject.values;
        }
    }
    
    async defaultInputFormatFunction(value: any): Promise<any> {
        return this.component.defaultInputFormatFunction(value);
    }

    async defaultInputParseFunction(value: any): Promise<any> {
        return this.component.defaultInputParseFunction(value);
    }

    async defaultLabelFormatFunction(value: any): Promise<any> {
        return this.component.defaultLabelFormatFunction(value);
    }

    async getBounds(): Promise<any> {
        return this.component.getBounds();
    }

    async getBoundsForValueAtIndex(index: any): Promise<any> {
        let result = this.component.getBoundsForValueAtIndex(index);
        
        return generateSerializableJson(result);
    }

    async getLabelForValue(value: any,
        type: any,
        index: any): Promise<any> {
        return this.component.getLabelForValue(value,
            type,
            index);
    }

    async setValue(index: any,
        value: any): Promise<void> {
        this.component.setValue(index,
            value);
    }

    async toPrecision(value: any): Promise<any> {
        return this.component.toPrecision(value);
    }

    // region properties
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsSliderViewModelGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.hasInputFormatFunction) && dotNetObject.hasInputFormatFunction) {
        properties.inputFormatFunction = async (value,
        type,
        index) => {

            let func = new Function('value',
            'type',
            'index', dotNetObject.inputFormatFunction.javaScriptFunction);
            return func(value,
            type,
            index);
        };
    }
    if (hasValue(dotNetObject.hasInputParseFunction) && dotNetObject.hasInputParseFunction) {
        properties.inputParseFunction = async (value,
        type,
        index) => {

            let func = new Function('value',
            'type',
            'index', dotNetObject.inputParseFunction.javaScriptFunction);
            return func(value,
            type,
            index);
        };
    }
    if (hasValue(dotNetObject.hasLabelFormatFunction) && dotNetObject.hasLabelFormatFunction) {
        properties.labelFormatFunction = async (value,
        type,
        index) => {

            let func = new Function('value',
            'type',
            'index', dotNetObject.labelFormatFunction.javaScriptFunction);
            return func(value,
            type,
            index);
        };
    }

    if (hasValue(dotNetObject.effectiveMax)) {
        properties.effectiveMax = dotNetObject.effectiveMax;
    }
    if (hasValue(dotNetObject.effectiveMin)) {
        properties.effectiveMin = dotNetObject.effectiveMin;
    }
    if (hasValue(dotNetObject.max)) {
        properties.max = dotNetObject.max;
    }
    if (hasValue(dotNetObject.min)) {
        properties.min = dotNetObject.min;
    }
    if (hasValue(dotNetObject.precision)) {
        properties.precision = dotNetObject.precision;
    }
    if (hasValue(dotNetObject.thumbsConstrained)) {
        properties.thumbsConstrained = dotNetObject.thumbsConstrained;
    }
    if (hasValue(dotNetObject.values) && dotNetObject.values.length > 0) {
        properties.values = dotNetObject.values;
    }
    let jsSliderViewModel = new SliderViewModel(properties);

    let { default: SliderViewModelWrapper } = await import('./sliderViewModel');
    let sliderViewModelWrapper = new SliderViewModelWrapper(jsSliderViewModel);
    sliderViewModelWrapper.geoBlazorId = dotNetObject.id;
    sliderViewModelWrapper.viewId = viewId;
    sliderViewModelWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = sliderViewModelWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsSliderViewModel;
    
    return jsSliderViewModel;
}


export async function buildDotNetSliderViewModelGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSliderViewModel: any = {};
    
    if (hasValue(jsObject.effectiveMax)) {
        dotNetSliderViewModel.effectiveMax = jsObject.effectiveMax;
    }
    
    if (hasValue(jsObject.effectiveMin)) {
        dotNetSliderViewModel.effectiveMin = jsObject.effectiveMin;
    }
    
    if (hasValue(jsObject.labels)) {
        dotNetSliderViewModel.labels = removeCircularReferences(jsObject.labels);
    }
    
    if (hasValue(jsObject.max)) {
        dotNetSliderViewModel.max = jsObject.max;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetSliderViewModel.min = jsObject.min;
    }
    
    if (hasValue(jsObject.precision)) {
        dotNetSliderViewModel.precision = jsObject.precision;
    }
    
    if (hasValue(jsObject.state)) {
        dotNetSliderViewModel.state = removeCircularReferences(jsObject.state);
    }
    
    if (hasValue(jsObject.thumbsConstrained)) {
        dotNetSliderViewModel.thumbsConstrained = jsObject.thumbsConstrained;
    }
    
    if (hasValue(jsObject.values)) {
        dotNetSliderViewModel.values = jsObject.values;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSliderViewModel.id = geoBlazorId;
    }

    return dotNetSliderViewModel;
}

