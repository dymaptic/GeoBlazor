// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import BasemapToggle from '@arcgis/core/widgets/BasemapToggle';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, buildJsStreamReference, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class BasemapToggleWidgetGenerated implements IPropertyWrapper {
    public widget: BasemapToggle;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(widget: BasemapToggle) {
        this.widget = widget;
    }
    
    // region methods
   
    unwrap() {
        return this.widget;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.nextBasemap)) {
            let { buildJsBasemap } = await import('./basemap');
            this.widget.nextBasemap = await buildJsBasemap(dotNetObject.nextBasemap, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.visibleElements)) {
            let { buildJsBasemapToggleVisibleElements } = await import('./basemapToggleVisibleElements');
            this.widget.visibleElements = await buildJsBasemapToggleVisibleElements(dotNetObject.visibleElements) as any;
        }

        if (hasValue(dotNetObject.icon)) {
            this.widget.icon = dotNetObject.icon;
        }
        if (hasValue(dotNetObject.label)) {
            this.widget.label = dotNetObject.label;
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

    async toggle(): Promise<any> {
        let result = await this.widget.toggle();
        
        return generateSerializableJson(result);
    }

    async when(callback: any,
        errback: any): Promise<any> {
        let result = await this.widget.when(callback,
            errback);
        
        return generateSerializableJson(result);
    }

    // region properties
    
    async getActiveBasemap(): Promise<any> {
        if (!hasValue(this.widget.activeBasemap)) {
            return null;
        }
        
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.widget.activeBasemap);
    }
    
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
    
    async getNextBasemap(): Promise<any> {
        if (!hasValue(this.widget.nextBasemap)) {
            return null;
        }
        
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.widget.nextBasemap);
    }
    
    async setNextBasemap(value: any): Promise<void> {
        let { buildJsBasemap } = await import('./basemap');
        this.widget.nextBasemap = await  buildJsBasemap(value, this.layerId, this.viewId);
    }
    
    async getViewModel(): Promise<any> {
        if (!hasValue(this.widget.viewModel)) {
            return null;
        }
        
        let { buildDotNetBasemapToggleViewModel } = await import('./basemapToggleViewModel');
        return await buildDotNetBasemapToggleViewModel(this.widget.viewModel);
    }
    
    async setViewModel(value: any): Promise<void> {
        let { buildJsBasemapToggleViewModel } = await import('./basemapToggleViewModel');
        this.widget.viewModel = await  buildJsBasemapToggleViewModel(value, this.layerId, this.viewId);
    }
    
    async getVisibleElements(): Promise<any> {
        if (!hasValue(this.widget.visibleElements)) {
            return null;
        }
        
        let { buildDotNetBasemapToggleVisibleElements } = await import('./basemapToggleVisibleElements');
        return await buildDotNetBasemapToggleVisibleElements(this.widget.visibleElements);
    }
    
    async setVisibleElements(value: any): Promise<void> {
        let { buildJsBasemapToggleVisibleElements } = await import('./basemapToggleVisibleElements');
        this.widget.visibleElements = await  buildJsBasemapToggleVisibleElements(value);
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


export async function buildJsBasemapToggleWidgetGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(viewId)) {
        properties.view = arcGisObjectRefs[viewId!];
    }
    if (hasValue(dotNetObject.nextBasemap)) {
        let { buildJsBasemap } = await import('./basemap');
        properties.nextBasemap = await buildJsBasemap(dotNetObject.nextBasemap, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.viewModel)) {
        let { buildJsBasemapToggleViewModel } = await import('./basemapToggleViewModel');
        properties.viewModel = await buildJsBasemapToggleViewModel(dotNetObject.viewModel, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.visibleElements)) {
        let { buildJsBasemapToggleVisibleElements } = await import('./basemapToggleVisibleElements');
        properties.visibleElements = await buildJsBasemapToggleVisibleElements(dotNetObject.visibleElements) as any;
    }

    if (hasValue(dotNetObject.icon)) {
        properties.icon = dotNetObject.icon;
    }
    if (hasValue(dotNetObject.label)) {
        properties.label = dotNetObject.label;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }
    if (hasValue(dotNetObject.widgetId)) {
        properties.id = dotNetObject.widgetId;
    }
    let jsBasemapToggle = new BasemapToggle(properties);

    let { default: BasemapToggleWidgetWrapper } = await import('./basemapToggleWidget');
    let basemapToggleWidgetWrapper = new BasemapToggleWidgetWrapper(jsBasemapToggle);
    basemapToggleWidgetWrapper.geoBlazorId = dotNetObject.id;
    basemapToggleWidgetWrapper.viewId = viewId;
    basemapToggleWidgetWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = basemapToggleWidgetWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsBasemapToggle;
    
    try {
        let jsObjectRef = DotNet.createJSObjectReference(basemapToggleWidgetWrapper);
        let { buildDotNetBasemapToggleWidget } = await import('./basemapToggleWidget');
        let dnInstantiatedObject = await buildDotNetBasemapToggleWidget(jsBasemapToggle);

        let dnStream = buildJsStreamReference(dnInstantiatedObject);
        await dotNetObject.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated', 
            jsObjectRef, dnStream);
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for BasemapToggleWidget', e);
    }
    
    return jsBasemapToggle;
}


export async function buildDotNetBasemapToggleWidgetGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetBasemapToggleWidget: any = {};
    
    if (hasValue(jsObject.viewModel)) {
        let { buildDotNetBasemapToggleViewModel } = await import('./basemapToggleViewModel');
        dotNetBasemapToggleWidget.viewModel = await buildDotNetBasemapToggleViewModel(jsObject.viewModel);
    }
    
    if (hasValue(jsObject.visibleElements)) {
        let { buildDotNetBasemapToggleVisibleElements } = await import('./basemapToggleVisibleElements');
        dotNetBasemapToggleWidget.visibleElements = await buildDotNetBasemapToggleVisibleElements(jsObject.visibleElements);
    }
    
    if (hasValue(jsObject.icon)) {
        dotNetBasemapToggleWidget.icon = jsObject.icon;
    }
    
    if (hasValue(jsObject.label)) {
        dotNetBasemapToggleWidget.label = jsObject.label;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetBasemapToggleWidget.type = removeCircularReferences(jsObject.type);
    }
    
    if (hasValue(jsObject.visible)) {
        dotNetBasemapToggleWidget.visible = jsObject.visible;
    }
    
    if (hasValue(jsObject.id)) {
        dotNetBasemapToggleWidget.widgetId = jsObject.id;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetBasemapToggleWidget.id = geoBlazorId;
    }

    return dotNetBasemapToggleWidget;
}

