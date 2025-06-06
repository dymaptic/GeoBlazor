// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import Slider from '@arcgis/core/widgets/Slider';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, buildJsStreamReference, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class SliderWidgetGenerated implements IPropertyWrapper {
    public widget: Slider;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(widget: Slider) {
        this.widget = widget;
    }
    
    // region methods
   
    unwrap() {
        return this.widget;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.tickConfigs) && dotNetObject.tickConfigs.length > 0) {
            let { buildJsTickConfig } = await import('./tickConfig');
            this.widget.tickConfigs = dotNetObject.tickConfigs.map(i => buildJsTickConfig(i)) as any;
        }
        if (hasValue(dotNetObject.visibleElements)) {
            let { buildJsSliderVisibleElements } = await import('./sliderVisibleElements');
            this.widget.visibleElements = await buildJsSliderVisibleElements(dotNetObject.visibleElements) as any;
        }

        if (hasValue(dotNetObject.disabled)) {
            this.widget.disabled = dotNetObject.disabled;
        }
        if (hasValue(dotNetObject.draggableSegmentsEnabled)) {
            this.widget.draggableSegmentsEnabled = dotNetObject.draggableSegmentsEnabled;
        }
        if (hasValue(dotNetObject.effectiveMax)) {
            this.widget.effectiveMax = dotNetObject.effectiveMax;
        }
        if (hasValue(dotNetObject.effectiveMin)) {
            this.widget.effectiveMin = dotNetObject.effectiveMin;
        }
        if (hasValue(dotNetObject.icon)) {
            this.widget.icon = dotNetObject.icon;
        }
        if (hasValue(dotNetObject.label)) {
            this.widget.label = dotNetObject.label;
        }
        if (hasValue(dotNetObject.labelInputsEnabled)) {
            this.widget.labelInputsEnabled = dotNetObject.labelInputsEnabled;
        }
        if (hasValue(dotNetObject.layout)) {
            this.widget.layout = dotNetObject.layout;
        }
        if (hasValue(dotNetObject.max)) {
            this.widget.max = dotNetObject.max;
        }
        if (hasValue(dotNetObject.min)) {
            this.widget.min = dotNetObject.min;
        }
        if (hasValue(dotNetObject.precision)) {
            this.widget.precision = dotNetObject.precision;
        }
        if (hasValue(dotNetObject.rangeLabelInputsEnabled)) {
            this.widget.rangeLabelInputsEnabled = dotNetObject.rangeLabelInputsEnabled;
        }
        if (hasValue(dotNetObject.snapOnClickEnabled)) {
            this.widget.snapOnClickEnabled = dotNetObject.snapOnClickEnabled;
        }
        if (hasValue(dotNetObject.steps)) {
            this.widget.steps = dotNetObject.steps;
        }
        if (hasValue(dotNetObject.syncedSegmentsEnabled)) {
            this.widget.syncedSegmentsEnabled = dotNetObject.syncedSegmentsEnabled;
        }
        if (hasValue(dotNetObject.thumbsConstrained)) {
            this.widget.thumbsConstrained = dotNetObject.thumbsConstrained;
        }
        if (hasValue(dotNetObject.values) && dotNetObject.values.length > 0) {
            this.widget.values = dotNetObject.values;
        }
        if (hasValue(dotNetObject.visible)) {
            this.widget.visible = dotNetObject.visible;
        }
        if (hasValue(dotNetObject.widgetId)) {
            this.widget.id = dotNetObject.widgetId;
        }
    }
    
    async classes(): Promise<any> {
        return this.widget.classes();
    }

    async isFulfilled(): Promise<any> {
        return this.widget.isFulfilled();
    }

    async isRejected(): Promise<any> {
        return this.widget.isRejected();
    }

    async isResolved(): Promise<any> {
        return this.widget.isResolved();
    }

    async postInitialize(): Promise<void> {
        this.widget.postInitialize();
    }

    async render(): Promise<any> {
        let result = this.widget.render();
        
        return generateSerializableJson(result);
    }

    async renderNow(): Promise<void> {
        this.widget.renderNow();
    }

    async scheduleRender(): Promise<void> {
        this.widget.scheduleRender();
    }

    async when(callback: any,
        errback: any): Promise<any> {
        let result = await this.widget.when(callback,
            errback);
        
        return generateSerializableJson(result);
    }

    // region properties
    
    getIcon(): any {
        if (!hasValue(this.widget.icon)) {
            return null;
        }
        
        return generateSerializableJson(this.widget.icon);
    }
    
    setIcon(value: any): void {
        this.widget.icon = JSON.parse(value);
    }
    
    getLabel(): any {
        if (!hasValue(this.widget.label)) {
            return null;
        }
        
        return generateSerializableJson(this.widget.label);
    }
    
    setLabel(value: any): void {
        this.widget.label = JSON.parse(value);
    }
    
    async getTickConfigs(): Promise<any> {
        if (!hasValue(this.widget.tickConfigs)) {
            return null;
        }
        
        let { buildDotNetTickConfig } = await import('./tickConfig');
        return await Promise.all(this.widget.tickConfigs!.map(async i => await buildDotNetTickConfig(i)));
    }
    
    async setTickConfigs(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.widget.tickConfigs = [];
        }
        let { buildJsTickConfig } = await import('./tickConfig');
        this.widget.tickConfigs = await Promise.all(value.map(async i => await buildJsTickConfig(i))) as any;
    }
    
    async getViewModel(): Promise<any> {
        if (!hasValue(this.widget.viewModel)) {
            return null;
        }
        
        let { buildDotNetSliderViewModel } = await import('./sliderViewModel');
        return await buildDotNetSliderViewModel(this.widget.viewModel);
    }
    
    async setViewModel(value: any): Promise<void> {
        let { buildJsSliderViewModel } = await import('./sliderViewModel');
        this.widget.viewModel = await  buildJsSliderViewModel(value, this.layerId, this.viewId);
    }
    
    async getVisibleElements(): Promise<any> {
        if (!hasValue(this.widget.visibleElements)) {
            return null;
        }
        
        let { buildDotNetSliderVisibleElements } = await import('./sliderVisibleElements');
        return await buildDotNetSliderVisibleElements(this.widget.visibleElements);
    }
    
    async setVisibleElements(value: any): Promise<void> {
        let { buildJsSliderVisibleElements } = await import('./sliderVisibleElements');
        this.widget.visibleElements = await  buildJsSliderVisibleElements(value);
    }
    
    getWidgetId(): any {
        if (!hasValue(this.widget.id)) {
            return null;
        }
        
        return generateSerializableJson(this.widget.id);
    }
    
    setWidgetId(value: any): void {
        this.widget.id = JSON.parse(value);
    }
    
    getProperty(prop: string): any {
        return this.widget[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.widget[prop] = value;
    }
}


export async function buildJsSliderWidgetGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.hasInputCreatedFunction) && dotNetObject.hasInputCreatedFunction) {
        properties.inputCreatedFunction = async (inputElement,
        type,
        thumbIndex) => {

            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsInputCreatedFunction', inputElement,
            type,
            thumbIndex);
        };
    }
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
    if (hasValue(dotNetObject.hasThumbCreatedFunction) && dotNetObject.hasThumbCreatedFunction) {
        properties.thumbCreatedFunction = async (index,
        value,
        thumbElement,
        labelElement) => {

            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsThumbCreatedFunction', index,
            value,
            thumbElement,
            labelElement);
        };
    }
    if (hasValue(dotNetObject.tickConfigs) && dotNetObject.tickConfigs.length > 0) {
        let { buildJsTickConfig } = await import('./tickConfig');
        properties.tickConfigs = dotNetObject.tickConfigs.map(i => buildJsTickConfig(i)) as any;
    }
    if (hasValue(dotNetObject.viewModel)) {
        let { buildJsSliderViewModel } = await import('./sliderViewModel');
        properties.viewModel = await buildJsSliderViewModel(dotNetObject.viewModel, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.visibleElements)) {
        let { buildJsSliderVisibleElements } = await import('./sliderVisibleElements');
        properties.visibleElements = await buildJsSliderVisibleElements(dotNetObject.visibleElements) as any;
    }

    if (hasValue(dotNetObject.disabled)) {
        properties.disabled = dotNetObject.disabled;
    }
    if (hasValue(dotNetObject.draggableSegmentsEnabled)) {
        properties.draggableSegmentsEnabled = dotNetObject.draggableSegmentsEnabled;
    }
    if (hasValue(dotNetObject.effectiveMax)) {
        properties.effectiveMax = dotNetObject.effectiveMax;
    }
    if (hasValue(dotNetObject.effectiveMin)) {
        properties.effectiveMin = dotNetObject.effectiveMin;
    }
    if (hasValue(dotNetObject.icon)) {
        properties.icon = dotNetObject.icon;
    }
    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.labelInputsEnabled)) {
        properties.labelInputsEnabled = dotNetObject.labelInputsEnabled;
    }
    if (hasValue(dotNetObject.layout)) {
        properties.layout = dotNetObject.layout;
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
    if (hasValue(dotNetObject.rangeLabelInputsEnabled)) {
        properties.rangeLabelInputsEnabled = dotNetObject.rangeLabelInputsEnabled;
    }
    if (hasValue(dotNetObject.snapOnClickEnabled)) {
        properties.snapOnClickEnabled = dotNetObject.snapOnClickEnabled;
    }
    if (hasValue(dotNetObject.steps)) {
        properties.steps = dotNetObject.steps;
    }
    if (hasValue(dotNetObject.syncedSegmentsEnabled)) {
        properties.syncedSegmentsEnabled = dotNetObject.syncedSegmentsEnabled;
    }
    if (hasValue(dotNetObject.thumbsConstrained)) {
        properties.thumbsConstrained = dotNetObject.thumbsConstrained;
    }
    if (hasValue(dotNetObject.values) && dotNetObject.values.length > 0) {
        properties.values = dotNetObject.values;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    if (hasValue(dotNetObject.widgetId)) {
        properties.id = dotNetObject.widgetId;
    }
    let jsSlider = new Slider(properties);
    if (hasValue(dotNetObject.hasMaxChangeListener) && dotNetObject.hasMaxChangeListener) {
        jsSlider.on('max-change', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsMaxChange', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasMaxClickListener) && dotNetObject.hasMaxClickListener) {
        jsSlider.on('max-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsMaxClick', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasMinChangeListener) && dotNetObject.hasMinChangeListener) {
        jsSlider.on('min-change', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsMinChange', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasMinClickListener) && dotNetObject.hasMinClickListener) {
        jsSlider.on('min-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsMinClick', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasSegmentClickListener) && dotNetObject.hasSegmentClickListener) {
        jsSlider.on('segment-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSegmentClick', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasSegmentDragListener) && dotNetObject.hasSegmentDragListener) {
        jsSlider.on('segment-drag', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSegmentDrag', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasThumbChangeListener) && dotNetObject.hasThumbChangeListener) {
        jsSlider.on('thumb-change', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsThumbChange', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasThumbClickListener) && dotNetObject.hasThumbClickListener) {
        jsSlider.on('thumb-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsThumbClick', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasThumbDragListener) && dotNetObject.hasThumbDragListener) {
        jsSlider.on('thumb-drag', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsThumbDrag', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasTickClickListener) && dotNetObject.hasTickClickListener) {
        jsSlider.on('tick-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsTickClick', streamRef);
        });
    }
    
    if (hasValue(dotNetObject.hasTrackClickListener) && dotNetObject.hasTrackClickListener) {
        jsSlider.on('track-click', async (evt: any) => {
            let streamRef = buildJsStreamReference(evt ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsTrackClick', streamRef);
        });
    }
    

    let { default: SliderWidgetWrapper } = await import('./sliderWidget');
    let sliderWidgetWrapper = new SliderWidgetWrapper(jsSlider);
    sliderWidgetWrapper.geoBlazorId = dotNetObject.id;
    sliderWidgetWrapper.viewId = viewId;
    sliderWidgetWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = sliderWidgetWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsSlider;
    
    try {
        let jsObjectRef = DotNet.createJSObjectReference(sliderWidgetWrapper);
        let { buildDotNetSliderWidget } = await import('./sliderWidget');
        let dnInstantiatedObject = await buildDotNetSliderWidget(jsSlider);

        let dnStream = buildJsStreamReference(dnInstantiatedObject);
        await dotNetObject.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated', 
            jsObjectRef, dnStream);
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for SliderWidget', e);
    }
    
    return jsSlider;
}


export async function buildDotNetSliderWidgetGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetSliderWidget: any = {};
    
    if (hasValue(jsObject.tickConfigs)) {
        let { buildDotNetTickConfig } = await import('./tickConfig');
        dotNetSliderWidget.tickConfigs = await Promise.all(jsObject.tickConfigs.map(async i => await buildDotNetTickConfig(i)));
    }
    
    if (hasValue(jsObject.viewModel)) {
        let { buildDotNetSliderViewModel } = await import('./sliderViewModel');
        dotNetSliderWidget.viewModel = await buildDotNetSliderViewModel(jsObject.viewModel);
    }
    
    if (hasValue(jsObject.visibleElements)) {
        let { buildDotNetSliderVisibleElements } = await import('./sliderVisibleElements');
        dotNetSliderWidget.visibleElements = await buildDotNetSliderVisibleElements(jsObject.visibleElements);
    }
    
    if (hasValue(jsObject.disabled)) {
        dotNetSliderWidget.disabled = jsObject.disabled;
    }
    
    if (hasValue(jsObject.draggableSegmentsEnabled)) {
        dotNetSliderWidget.draggableSegmentsEnabled = jsObject.draggableSegmentsEnabled;
    }
    
    if (hasValue(jsObject.effectiveMax)) {
        dotNetSliderWidget.effectiveMax = jsObject.effectiveMax;
    }
    
    if (hasValue(jsObject.effectiveMin)) {
        dotNetSliderWidget.effectiveMin = jsObject.effectiveMin;
    }
    
    if (hasValue(jsObject.effectiveSegmentElements)) {
        dotNetSliderWidget.effectiveSegmentElements = jsObject.effectiveSegmentElements;
    }
    
    if (hasValue(jsObject.icon)) {
        dotNetSliderWidget.icon = jsObject.icon;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetSliderWidget.label = jsObject.label;
    }
    
    if (hasValue(jsObject.labelElements)) {
        dotNetSliderWidget.labelElements = jsObject.labelElements;
    }
    
    if (hasValue(jsObject.labelInputsEnabled)) {
        dotNetSliderWidget.labelInputsEnabled = jsObject.labelInputsEnabled;
    }
    
    if (hasValue(jsObject.labels)) {
        dotNetSliderWidget.labels = removeCircularReferences(jsObject.labels);
    }
    
    if (hasValue(jsObject.layout)) {
        dotNetSliderWidget.layout = removeCircularReferences(jsObject.layout);
    }
    
    if (hasValue(jsObject.max)) {
        dotNetSliderWidget.max = jsObject.max;
    }
    
    if (hasValue(jsObject.maxLabelElement)) {
        dotNetSliderWidget.maxLabelElement = jsObject.maxLabelElement;
    }
    
    if (hasValue(jsObject.min)) {
        dotNetSliderWidget.min = jsObject.min;
    }
    
    if (hasValue(jsObject.minLabelElement)) {
        dotNetSliderWidget.minLabelElement = jsObject.minLabelElement;
    }
    
    if (hasValue(jsObject.precision)) {
        dotNetSliderWidget.precision = jsObject.precision;
    }
    
    if (hasValue(jsObject.rangeLabelInputsEnabled)) {
        dotNetSliderWidget.rangeLabelInputsEnabled = jsObject.rangeLabelInputsEnabled;
    }
    
    if (hasValue(jsObject.segmentElements)) {
        dotNetSliderWidget.segmentElements = jsObject.segmentElements;
    }
    
    if (hasValue(jsObject.snapOnClickEnabled)) {
        dotNetSliderWidget.snapOnClickEnabled = jsObject.snapOnClickEnabled;
    }
    
    if (hasValue(jsObject.state)) {
        dotNetSliderWidget.state = removeCircularReferences(jsObject.state);
    }
    
    if (hasValue(jsObject.steps)) {
        dotNetSliderWidget.steps = jsObject.steps;
    }
    
    if (hasValue(jsObject.syncedSegmentsEnabled)) {
        dotNetSliderWidget.syncedSegmentsEnabled = jsObject.syncedSegmentsEnabled;
    }
    
    if (hasValue(jsObject.thumbElements)) {
        dotNetSliderWidget.thumbElements = jsObject.thumbElements;
    }
    
    if (hasValue(jsObject.thumbsConstrained)) {
        dotNetSliderWidget.thumbsConstrained = jsObject.thumbsConstrained;
    }
    
    if (hasValue(jsObject.tickElements)) {
        dotNetSliderWidget.tickElements = removeCircularReferences(jsObject.tickElements);
    }
    
    if (hasValue(jsObject.trackElement)) {
        dotNetSliderWidget.trackElement = jsObject.trackElement;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetSliderWidget.type = removeCircularReferences(jsObject.type);
    }
    
    if (hasValue(jsObject.values)) {
        dotNetSliderWidget.values = jsObject.values;
    }
    
    if (hasValue(jsObject.visible)) {
        dotNetSliderWidget.visible = jsObject.visible;
    }
    
    if (hasValue(jsObject.id)) {
        dotNetSliderWidget.widgetId = jsObject.id;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetSliderWidget.id = geoBlazorId;
    }

    return dotNetSliderWidget;
}

