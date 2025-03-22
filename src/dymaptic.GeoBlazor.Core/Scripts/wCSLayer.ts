// override generated code in this file
import WCSLayerGenerated from './wCSLayer.gb';
import WCSLayer from '@arcgis/core/layers/WCSLayer';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export default class WCSLayerWrapper extends WCSLayerGenerated {

    constructor(layer: WCSLayer) {
        super(layer);
    }

}

export async function buildJsWCSLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let properties: any = {};
    if (hasValue(dotNetObject.coverageInfo)) {
        let { buildJsCoverageInfo } = await import('./coverageInfo');
        properties.coverageInfo = await buildJsCoverageInfo(dotNetObject.coverageInfo) as any;
    }
    if (hasValue(dotNetObject.effect)) {
        let { buildJsEffect } = await import('./effect');
        properties.effect = buildJsEffect(dotNetObject.effect) as any;
    }
    if (hasValue(dotNetObject.fullExtent)) {
        let { buildJsExtent } = await import('./extent');
        properties.fullExtent = buildJsExtent(dotNetObject.fullExtent) as any;
    }
    if (hasValue(dotNetObject.multidimensionalDefinition) && dotNetObject.multidimensionalDefinition.length > 0) {
        let { buildJsDimensionalDefinition } = await import('./dimensionalDefinition');
        properties.multidimensionalDefinition = await Promise.all(dotNetObject.multidimensionalDefinition.map(async i => await buildJsDimensionalDefinition(i))) as any;
    }
    if (hasValue(dotNetObject.multidimensionalSubset)) {
        let { buildJsMultidimensionalSubset } = await import('./multidimensionalSubset');
        properties.multidimensionalSubset = await buildJsMultidimensionalSubset(dotNetObject.multidimensionalSubset) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        properties.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.portalItem)) {
        let { buildJsPortalItem } = await import('./portalItem');
        properties.portalItem = await buildJsPortalItem(dotNetObject.portalItem, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.rasterFields) && dotNetObject.rasterFields.length > 0) {
        let { buildJsField } = await import('./field');
        properties.rasterFields = dotNetObject.rasterFields.map(i => buildJsField(i)) as any;
    }
    if (hasValue(dotNetObject.timeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.timeExtent = await buildJsTimeExtent(dotNetObject.timeExtent) as any;
    }
    if (hasValue(dotNetObject.timeInfo)) {
        let { buildJsTimeInfo } = await import('./timeInfo');
        properties.timeInfo = await buildJsTimeInfo(dotNetObject.timeInfo) as any;
    }
    if (hasValue(dotNetObject.timeOffset)) {
        let { buildJsTimeInterval } = await import('./timeInterval');
        properties.timeOffset = await buildJsTimeInterval(dotNetObject.timeOffset) as any;
    }
    if (hasValue(dotNetObject.visibilityTimeExtent)) {
        let { buildJsTimeExtent } = await import('./timeExtent');
        properties.visibilityTimeExtent = await buildJsTimeExtent(dotNetObject.visibilityTimeExtent) as any;
    }

    if (hasValue(dotNetObject.arcGISLayerId)) {
        properties.id = dotNetObject.arcGISLayerId;
    }
    if (hasValue(dotNetObject.bandIds) && dotNetObject.bandIds.length > 0) {
        properties.bandIds = dotNetObject.bandIds;
    }
    if (hasValue(dotNetObject.blendMode)) {
        properties.blendMode = dotNetObject.blendMode;
    }
    if (hasValue(dotNetObject.copyright)) {
        properties.copyright = dotNetObject.copyright;
    }
    if (hasValue(dotNetObject.coverageId)) {
        properties.coverageId = dotNetObject.coverageId;
    }
    if (hasValue(dotNetObject.customParameters)) {
        properties.customParameters = dotNetObject.customParameters;
    }
    if (hasValue(dotNetObject.interpolation)) {
        properties.interpolation = dotNetObject.interpolation;
    }
    if (hasValue(dotNetObject.legendEnabled)) {
        properties.legendEnabled = dotNetObject.legendEnabled;
    }
    if (hasValue(dotNetObject.listMode)) {
        properties.listMode = dotNetObject.listMode;
    }
    if (hasValue(dotNetObject.maxScale)) {
        properties.maxScale = dotNetObject.maxScale;
    }
    if (hasValue(dotNetObject.minScale)) {
        properties.minScale = dotNetObject.minScale;
    }
    if (hasValue(dotNetObject.opacity)) {
        properties.opacity = dotNetObject.opacity;
    }
    if (hasValue(dotNetObject.persistenceEnabled)) {
        properties.persistenceEnabled = dotNetObject.persistenceEnabled;
    }
    if (hasValue(dotNetObject.popupEnabled)) {
        properties.popupEnabled = dotNetObject.popupEnabled;
    }
    if (hasValue(dotNetObject.title)) {
        properties.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.url)) {
        properties.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.useViewTime)) {
        properties.useViewTime = dotNetObject.useViewTime;
    }
    if (hasValue(dotNetObject.version)) {
        properties.version = dotNetObject.version;
    }
    if (hasValue(dotNetObject.visible)) {
        properties.visible = dotNetObject.visible;
    }

    if (hasValue(dotNetObject.renderer)) {
        let {buildJsImageryRenderer} = await import('./imageryRenderer');
        properties.renderer = await buildJsImageryRenderer(dotNetObject.renderer, layerId, viewId);
    }
    
    let jsWCSLayer = new WCSLayer(properties);
    jsWCSLayer.on('layerview-create', async (evt: any) => {
        let { buildDotNetLayerViewCreateEvent } = await import('./layerViewCreateEvent');
        let dnEvent = await buildDotNetLayerViewCreateEvent(evt, layerId, viewId);
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsCreate', dnEvent);
    });

    jsWCSLayer.on('layerview-create-error', async (evt: any) => {
        let { buildDotNetLayerViewCreateErrorEvent } = await import('./layerViewCreateErrorEvent');
        let dnEvent = await buildDotNetLayerViewCreateErrorEvent(evt, layerId, viewId);
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsCreateError', dnEvent);
    });

    jsWCSLayer.on('layerview-destroy', async (evt: any) => {
        let { buildDotNetLayerViewDestroyEvent } = await import('./layerViewDestroyEvent');
        let dnEvent = await buildDotNetLayerViewDestroyEvent(evt, layerId, viewId);
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsDestroy', dnEvent);
    });
    
    let wCSLayerWrapper = new WCSLayerWrapper(jsWCSLayer);
    wCSLayerWrapper.geoBlazorId = dotNetObject.id;
    wCSLayerWrapper.viewId = viewId;
    wCSLayerWrapper.layerId = layerId;

    let jsObjectRef = DotNet.createJSObjectReference(wCSLayerWrapper);
    jsObjectRefs[dotNetObject.id] = wCSLayerWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsWCSLayer;

    let dnInstantiatedObject = await buildDotNetWCSLayer(jsWCSLayer);

    try {
        let seenObjects = new WeakMap();
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, JSON.stringify(dnInstantiatedObject, function (key, value) {
                if (key.startsWith('_') || key === 'jsComponentReference') {
                    return undefined;
                }
                if (typeof value === 'object' && value !== null
                    && !(Array.isArray(value) && value.length === 0)) {
                    if (seenObjects.has(value)) {
                        console.debug(`Circular reference in serializing type WCSLayer detected at path: ${key}, value: ${value.declaredClass}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                return value;
            }));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for WCSLayer', e);
    }

    return jsWCSLayer;
}

export async function buildDotNetWCSLayer(jsObject: any): Promise<any> {
    let {buildDotNetWCSLayerGenerated} = await import('./wCSLayer.gb');
    let dnObject = await buildDotNetWCSLayerGenerated(jsObject);
    
    if (hasValue(jsObject.renderer)) {
        let {buildDotNetImageryRenderer} = await import('./imageryRenderer');
        dnObject.renderer = await buildDotNetImageryRenderer(jsObject.renderer);
    }
    
    return dnObject;
}
