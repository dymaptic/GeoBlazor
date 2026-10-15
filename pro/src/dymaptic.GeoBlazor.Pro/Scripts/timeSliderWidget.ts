import widgetsTimeSlider from '@arcgis/core/widgets/TimeSlider';
import TimeSliderWidgetGenerated from './timeSliderWidget.gb';
import TimeSlider from "@arcgis/core/widgets/TimeSlider";
import * as Core from './geoBlazorCore';
import MapView from "@arcgis/core/views/MapView";
import WebMap from "@arcgis/core/WebMap";
import {hasValue} from './geoBlazorCore';
import * as timeUtils from "@arcgis/core/support/timeUtils.js";

export default class TimeSliderWidgetWrapper extends TimeSliderWidgetGenerated {

    constructor(widget: TimeSlider) {
        super(widget);
    }

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.actions)) {
            let { buildJsActionBase } = await import('./actionBase');
            this.widget.actions = await Promise.all(dotNetObject.actions.map(async i => await buildJsActionBase(i))) as any;
        }
        if (hasValue(dotNetObject.fullTimeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.widget.fullTimeExtent = await buildJsTimeExtent(dotNetObject.fullTimeExtent) as any;
        }
        if (hasValue(dotNetObject.stops)) {
            let { buildJsTimeSliderStops } = await import('./timeSliderStops');
            this.widget.stops = await buildJsTimeSliderStops(dotNetObject.stops, this.layerId, this.viewId) as any;
        }
        if (hasValue(dotNetObject.tickConfigs)) {
            let { buildJsTickConfig } = await import('./tickConfig');
            this.widget.tickConfigs = dotNetObject.tickConfigs.map(i => buildJsTickConfig(i)) as any;
        }
        if (hasValue(dotNetObject.timeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.widget.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
        }
        if (hasValue(dotNetObject.viewModel)) {
            let { buildJsTimeSliderViewModel } = await import('./timeSliderViewModel');
            this.widget.viewModel = await buildJsTimeSliderViewModel(dotNetObject.viewModel, this.layerId, this.viewId) as any;
        }

        if (hasValue(dotNetObject.container)) {
            this.widget.container = dotNetObject.container;
        }
        if (hasValue(dotNetObject.disabled)) {
            this.widget.disabled = dotNetObject.disabled;
        }
        if (hasValue(dotNetObject.icon)) {
            this.widget.icon = dotNetObject.icon;
        }
        if (hasValue(dotNetObject.label)) {
            this.widget.label = dotNetObject.label;
        }
        if (hasValue(dotNetObject.layout)) {
            this.widget.layout = dotNetObject.layout;
        }
        if (hasValue(dotNetObject.loop)) {
            this.widget.loop = dotNetObject.loop;
        }
        if (hasValue(dotNetObject.mode)) {
            this.widget.mode = dotNetObject.mode;
        }
        if (hasValue(dotNetObject.playRate)) {
            this.widget.playRate = dotNetObject.playRate;
        }
        if (hasValue(dotNetObject.timeVisible)) {
            this.widget.timeVisible = dotNetObject.timeVisible;
        }
        if (hasValue(dotNetObject.timeZone)) {
            this.widget.timeZone = dotNetObject.timeZone;
        }
        if (hasValue(dotNetObject.widgetId)) {
            this.widget.id = dotNetObject.widgetId;
        }
    }
    
    async setLabelFormatFunction(labelFormatFunc: any) {
        let labelFormat: Function | null = new Function(labelFormatFunc);

        // ReSharper disable TS2322
        // @ts-ignore
        this.widget.labelFormatFunction = labelFormat;
        // ReSharper restore TS2322
    }

    async setPropertiesFromWebMap(properties: any) {
        
        if (!hasValue(properties)) {
            // if GeoBlazor did not send properties, look them up directly from the web map
            const view = Core.arcGisObjectRefs[this.viewId!] as MapView;
            const webMap = view.map as WebMap;
            properties = await timeUtils.getTimeSliderSettingsFromWebDocument(webMap);
            this.widget.fullTimeExtent = properties.fullTimeExtent;
            this.widget.loop = properties.loop;
            this.widget.playRate = properties.playRate;
            this.widget.mode = properties.mode;
            this.widget.stops = properties.stops;
            this.widget.timeExtent = properties.timeExtent;
            return;
        }
        
        if (hasValue(properties.fullTimeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.widget.fullTimeExtent = await buildJsTimeExtent(properties.fullTimeExtent);
        }
        if (hasValue(properties.loop)) {
            this.widget.loop = properties.loop;
        }
        if (hasValue(properties.playRate)) {
            this.widget.playRate = properties.playRate;
        }
        if (hasValue(properties.mode)) {
            this.widget.mode = properties.mode;
        }
        if (hasValue(properties.stops)) {
            let { buildJsTimeSliderStops } = await import('./timeSliderStops');
            this.widget.stops = await buildJsTimeSliderStops(properties.stops, this.layerId, this.viewId);
        }
        if (hasValue(properties.timeExtent)) {
            let { buildJsTimeExtent } = await import('./timeExtent');
            this.widget.timeExtent = await buildJsTimeExtent(properties.timeExtent);
        }
    }

    async getPropertiesFromWebMap(signal: any): Promise<any> {
        const view = Core.arcGisObjectRefs[this.viewId!] as MapView;
        const webMap = view.map as WebMap;
        const properties = await timeUtils.getTimeSliderSettingsFromWebDocument(webMap, signal);
        if (properties == null) {
            return null;
        }
        
        const result : any = {};
        if (hasValue(properties.fullTimeExtent)) {
            let { buildDotNetTimeExtent } = await import('./timeExtent');
            result.fullTimeExtent = await buildDotNetTimeExtent(properties.fullTimeExtent);
        }
        if (hasValue(properties.loop)) {
            result.loop = properties.loop;
        }
        if (hasValue(properties.playRate)) {
            result.playRate = properties.playRate;
        }
        if (hasValue(properties.mode)) {
            result.mode = properties.mode;
        }
        if (hasValue(properties.stops)) {
            let { buildDotNetTimeSliderStops } = await import('./timeSliderStops');
            result.stops = await buildDotNetTimeSliderStops(properties.stops);
        }
        if (hasValue(properties.timeExtent)) {
            let { buildDotNetTimeExtent } = await import('./timeExtent');
            result.timeExtent = await buildDotNetTimeExtent(properties.timeExtent);
        }
        
        return result;
    }
    
    async setStops(stops: any) : Promise<any> {
        let { buildJsTimeSliderStops } = await import('./timeSliderStops');
        this.widget.stops = await buildJsTimeSliderStops(stops, this.layerId, this.viewId);
    }
}
export async function buildJsTimeSliderWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeSliderWidgetGenerated } = await import('./timeSliderWidget.gb');
    let jsWidget = await buildJsTimeSliderWidgetGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.stops)) {
        let { buildJsTimeSliderStops } = await import('./timeSliderStops');
        jsWidget.stops = await buildJsTimeSliderStops(dotNetObject.stops, layerId, viewId);
    }
    return jsWidget;
}
export async function buildDotNetTimeSliderWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTimeSliderWidgetGenerated } = await import('./timeSliderWidget.gb');
    let dotNetWidget = await buildDotNetTimeSliderWidgetGenerated(jsObject, layerId, viewId);
    if (hasValue(jsObject.stops)) {
        let { buildDotNetTimeSliderStops } = await import('./timeSliderStops');
        dotNetWidget.stops = await buildDotNetTimeSliderStops(jsObject.stops);
    }
    return dotNetWidget;
}
