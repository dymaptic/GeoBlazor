import {
    addArcGisLayer,
    graphicsRefs,
    buildArcGisMapView,
    loadProtobuf, 
    ProtoGraphicCollection,
    popupTemplateRefs,
    actionHandlers
} from './arcGisJsInterop';
import AuthenticationManager from "./authenticationManager";
import ProjectionWrapper from "./projection";
import GeometryEngineWrapper from "./geometryEngine";
import LocatorWrapper from "./locationService";

// backwards-compatibility re-export, since everything used to be in this module
export * from './arcGisJsInterop';
export const arcGisObjectRefs: Record<string, any> = {};
// this could be either the arcGIS object or a "wrapper" class
export const jsObjectRefs: Record<string, any> = {};
export const dotNetRefs: Record<string, any> = {};

const observers: Record<string, any> = {};
export let Pro: any;
export async function setPro(pro: any): Promise<void> {
    Pro = pro;
}

export async function buildMapView(abortSignal: AbortSignal, id: string, dotNetReference: any, long: number | null,
                                   lat: number | null, rotation: number | null, mapObject: any, zoom: number | null,
                                   scale: number, mapType: string, widgets: any[], graphics: any,
                                   spatialReference: any, constraints: any, extent: any, backgroundColor: any,
                                   eventRateLimitInMilliseconds: number | null, activeEventHandlers: Array<string>,
                                   isServer: boolean, highlightOptions?: any | null, popupEnabled?: boolean | null, 
                                   theme?: string | null, allowDefaultEsriLogin?: boolean | null, apiKey?: string | null,
                                   appId?: string | null, zIndex?: number, 
                                   tilt?: number) : Promise<any> {
    try {
        await setCursor('wait');
        
        if (allowDefaultEsriLogin !== true && !hasValue(apiKey) && !hasValue(appId)) {
            let errorMessage = `Please add an ArcGISApiKey or ArcGISAppId to use the selected resources. See https://docs.geoblazor.com/pages/authentication.html#arcgis-authentication for more information.`;
            let errorMessageHtml = `<p>Please add an ArcGISApiKey or ArcGISAppId to use the selected resources. See <a style="color: red; text-decoration: underline" target="_blank" href="https://docs.geoblazor.com/pages/authentication.html#arcgis-authentication">ArcGIS Authentication</a> for more information.</p>`;
            globalThis.overflowStyle ??= document.documentElement.style.overflow;
            // listen for the esri-identity-modal popup and hide it
            const observer = new MutationObserver((mutations) => {
                mutations.forEach((mutation) => {
                    if (mutation.type === 'childList') {
                        mutation.addedNodes.forEach((node) => {
                            if (node instanceof HTMLElement) {
                                // Check the node itself
                                if (node.classList.contains('esri-identity-modal')) {
                                    overrideEsriLoginModal(node, id, errorMessage, errorMessageHtml);
                                }
                                // Check descendants
                                node.querySelectorAll?.('.esri-identity-modal').forEach((modal) => {
                                    overrideEsriLoginModal(modal as HTMLElement, id, errorMessage, errorMessageHtml);
                                });
                            }
                        });
                    } else if (mutation.type === 'attributes') {
                        const target = mutation.target as HTMLElement;
                        if (target.classList.contains('esri-identity-modal')) {
                            overrideEsriLoginModal(target, id, errorMessage, errorMessageHtml)
                        } else if (target.tagName === 'html' && target.style.overflow === 'hidden') {
                            // reset overflow style
                            document.documentElement!.style.overflow = globalThis.overflowStyle ?? 'unset';
                        }
                    }
                });
            });

            observer.observe(document.body, { 
                childList: true, 
                subtree: true, 
                attributes: true, 
                attributeFilter: ['class', 'style'] 
            });
            
            observers[id] = observer;
        }
        

        await buildArcGisMapView(abortSignal, id, dotNetReference, long, lat, rotation, mapObject, zoom, scale, mapType,
            widgets, graphics, spatialReference, constraints, extent, backgroundColor, eventRateLimitInMilliseconds,
            activeEventHandlers, isServer, highlightOptions, popupEnabled, theme, zIndex, tilt);

    } catch (e) {
        if (abortSignal.aborted) {
            return;
        }
        throw e;
    } finally {
        await setCursor('unset');
    }
}

// hides the ArcGIS popup modal login screen, and shows the warning to add an ArcGIS API key instead.
function overrideEsriLoginModal(element: HTMLElement, viewId: string, errorMessageString: string, 
                                errorMessageHtml: string): void {
    element.parentElement?.removeChild(element);
    // reset overflow style
    document.documentElement!.style.overflow = globalThis.overflowStyle ?? 'unset';
    showError(viewId, errorMessageHtml);
    console.error(errorMessageString);
}

function showError(viewId: string, errorMessage: string) {
    let mapViewContainer = document.querySelector(`#map-container-${viewId}`);
    let errorDiv: HTMLDivElement | null = mapViewContainer?.querySelector('.validation-message') as HTMLDivElement;
    if (!errorDiv) {
        errorDiv = document.createElement('div');
        errorDiv.style.cssText = `
        position: absolute; 
        top: 15px; 
        left: 15px; 
        z-index: 1000; 
        max-width: calc(100% - 30px);
        padding: 1rem;
        background-color: white;
        border-radius: 1rem;
        color: red;`;
        errorDiv.className = 'validation-message';
        errorDiv.innerHTML = errorMessage;
        mapViewContainer?.appendChild(errorDiv);
    } else {
        errorDiv.innerHTML = errorMessage;
    }
}

export async function disposeMapComponent(componentId: string, viewId: string): Promise<void> {
    try {
        // dispose observer when disposing the map view
        if (observers.hasOwnProperty(componentId)) {
            observers[componentId].disconnect();
            delete observers[componentId];
        }
        
        const component = arcGisObjectRefs[componentId];

        if (!hasValue(component)) {
            return;
        }

        switch (component?.declaredClass) {
            case 'esri.Graphic':
                await disposeGraphic(componentId);
                return;
        }

        if (arcGisObjectRefs.hasOwnProperty(componentId)) {
            delete arcGisObjectRefs[componentId];
        }
        if (dotNetRefs.hasOwnProperty(componentId)) {
            delete dotNetRefs[componentId];
        }
        if (jsObjectRefs.hasOwnProperty(componentId)) {
            delete jsObjectRefs[componentId];
        }
        // @ts-ignore hasOwn error
        if (popupTemplateRefs.hasOwnProperty(componentId)) {
            delete popupTemplateRefs[componentId];
        }
        if (actionHandlers.hasOwnProperty(componentId)) {
            actionHandlers[componentId].remove();
            delete actionHandlers[componentId];
        }
        const view = arcGisObjectRefs[viewId];
        view?.ui?.remove(component as any);
        component.destroy();
    }
    catch {
        // ignore
    }
}

export async function disposeGraphic(graphicId: string) {
    for (const groupId in graphicsRefs) {
        const graphics = graphicsRefs[groupId];
        // @ts-ignore hasOwn error
        if (graphics.hasOwnProperty(graphicId)) {
            delete graphics[graphicId];
            return;
        }
    }
}

export async function addLayer(layerObject: any, mapId: string | null, viewId: string, isBasemapLayer?: boolean, isReferenceLayer?: boolean,
                               isQueryLayer?: boolean, callback?: Function){
    return addArcGisLayer(layerObject, mapId, viewId, isBasemapLayer, isReferenceLayer, isQueryLayer, callback);
}

export function registerGeoBlazorObject(jsObjectRef: any, geoBlazorId: string) {
    if (arcGisObjectRefs.hasOwnProperty(geoBlazorId)) {
        return;
    }
    jsObjectRefs[geoBlazorId] = jsObjectRef;
    arcGisObjectRefs[geoBlazorId] = typeof jsObjectRef.unwrap === 'function'
        ? jsObjectRef.unwrap()
        : jsObjectRef;
}

export function lookupGeoBlazorId(jsObject: any): string | null {
    for (const key in arcGisObjectRefs) {
        if (key === 'undefined') {
            delete arcGisObjectRefs[key];
            continue;
        }
        let item = arcGisObjectRefs[key];
        if (!hasValue(item)) {
            delete arcGisObjectRefs[key];
            continue;
        }
        if (item === jsObject
            || (hasValue(jsObject.uid) && item.uid === jsObject.uid)) {
            return key;
        }
    }

    return null;
}

export function lookupGeoBlazorGraphicId(jsObject: any): string | null {
    for (const key in graphicsRefs) {
        let group = graphicsRefs[key];
        if (!hasValue(group)) {
            continue;
        }
        for (const k2 in group) {
            let item = group[k2];
            if (!hasValue(item)) {
                delete group[k2];
                continue;
            }

            if (item === jsObject
                // @ts-ignore
                || (hasValue(jsObject.uid) && item.uid === jsObject.uid)) {
                return k2;
            }
        }
    }

    return null;
}

// region Utility Functions

export function checkHeadLink(source: string): boolean {
    if (!hasValue(source)) {
        return false;
    }

    const link = document.querySelector(`link[href="${source}"]`);
    return link !== null;
}

export function removeHeadLink(source: string) : boolean {
    if (!hasValue(source)) {
        return false;
    }

    // just match the end of the href to allow for versioning or different original sources
    const link = document.querySelector(`link[href$="${source}"]`);
    if (link !== null) {
        link.remove();
        return true;
    }

    return false;
}

export function addHeadLink(source: string) {
    if (!hasValue(source)) {
        return;
    }

    if (document.querySelector(`link[href="${source}"]`) !== null) {
        return;
    }

    let link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = source;

    let geoblazorLink = document.querySelector('link[href*="_content/dymaptic.GeoBlazor.Core"]');
    document.head.insertBefore(link, geoblazorLink);
}

export function getJsComponent(id: string) {
    const component = jsObjectRefs[id];

    if (hasValue(component)) {
        return component;
    }
    return null;
}

export function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

// we have to wrap the JsObjectReference because a null will throw an error
// https://github.com/dotnet/aspnetcore/issues/52070
export async function getObjectRefForProperty(obj: any, prop: string): Promise<any> {
    const val = await getProperty(obj, prop);
    return {
        value: hasValue(val) ? DotNet.createJSObjectReference(val) : null
    };
}

export async function getProperty(obj: any, prop: string): Promise<any> {
    let val: any;
    if ('getProperty' in obj) {
        val = obj.getProperty(prop);
    } else {
        val = obj[prop];
    }

    return val;
}

// nullable value types cannot be correctly deserialized directly with the current Blazor implementation, so we have to wrap them
export async function getNullableValueTypedProperty(obj: any, prop: string): Promise<any> {
    const val = await getProperty(obj, prop);
    return {
        value: val
    };
}

export async function setProperty(obj: any, prop: string, value: any): Promise<void> {
    if ('setProperty' in obj) {
        obj.setProperty(prop, value);
    } else {
        obj[prop] = value;
    }
}

export function addToProperty(obj, prop, value) {
    if ('addToProperty' in obj) {
        obj.addToProperty(prop, value);
    } else if (Array.isArray(value)) {
        obj[prop].addMany(value);
    } else {
        obj[prop].add(value);
    }
}

export function removeFromProperty(obj, prop, value) {
    if ('removeFromProperty' in obj) {
        obj.removeFromProperty(prop, value);
    } else if (Array.isArray(value)) {
        obj[prop].removeMany(value);
    } else {
        obj[prop].remove(value);
    }
}

// this function should only be used for simple types that are guaranteed to succeed in serialization and conversion
export function copyValuesIfExists(originalObject: any, newObject: any, ...params: Array<string>) {
    if (hasValue(originalObject)) {
        params.forEach(p => {
            if (hasValue(originalObject[p]) && originalObject[p] !== newObject[p]) {
                newObject[p] = originalObject[p];
            }
        });
    }
}

export function toUpperFirstChar(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function toLowerFirstChar(str: string): string {
    return str.charAt(0).toLowerCase() + str.slice(1);
}

export function getBrowserLanguage(): string {
    return navigator.language;
}

export function createAbortControllerAndSignal() {
    const controller = new AbortController();
    const signal = controller.signal;
    return {
        abortControllerRef: DotNet.createJSObjectReference(controller),
        abortSignalRef: DotNet.createJSObjectReference(signal)
    }
}

export function getCursor(viewId: string): string {
    const view = document.getElementById(`map-container-${viewId}`) as HTMLDivElement;
    return view.parentElement!.style.cursor;
}

export async function setCursor(cursorType: string, viewId: string | null = null) {
    requestAnimationFrame(() => {
        const view = document.getElementById(`map-container-${viewId}`) as HTMLDivElement;
        if (hasValue(view)) {
            view.parentElement!.style.cursor = cursorType;
        } else {
            document.body.style.cursor = cursorType;
        }
    });
}

export function sanitize(dotNetObject: any): any {
    let {id, dotNetComponentReference, layerId, viewId, ...sanitizedDotNetObject} = dotNetObject;

    for (const key in sanitizedDotNetObject) {
        if (typeof sanitizedDotNetObject[key] === 'object' && sanitizedDotNetObject[key] !== null) {
            sanitizedDotNetObject[key] = sanitize(sanitizedDotNetObject[key]);
        }
    }

    return sanitizedDotNetObject;
}

export function generateSerializableJson(object: any): string | null {
    if (!hasValue(object)) {
        return null;
    }

    if (typeof object !== 'object') {
        return object.toString();
    }

    // Create a path-based tracking for circular references
    const ancestors: any[] = [];
    let json = JSON.stringify(object, function(key, value) {
        if (key.startsWith('_') || key === 'jsComponentReference') {
            return undefined;
        }

        // If value is an object (and not null or empty array), check for circularity
        if (typeof value === 'object' && value !== null &&
            !(Array.isArray(value) && value.length === 0)) {

            // `this` is the object that value is contained in,
            // i.e., its direct parent.
            while (ancestors.length > 0 && ancestors.at(-1) !== this) {
                // this pops us back up one level in the tree to find the actual parent
                ancestors.pop();
            }

            if (ancestors.includes(value)) {
                return undefined;
            }
            ancestors.push(value);
            return value;
        }

        return value;
    });

    return json;
}

export function removeCircularReferences(jsObject: any) {
    if (typeof jsObject !== 'object') {
        return jsObject;
    }
    let json = generateSerializableJson(jsObject);
    if (!hasValue(json)) {
        return null;
    }
    return JSON.parse(json!);
}

export function buildJsStreamReference(dnObject: any) {
    let json = generateSerializableJson(dnObject);
    if (!hasValue(json)) {
        return null;
    }
    let encoder = new TextEncoder();
    let encodedArray = encoder.encode(json!);
    return DotNet.createJSStreamReference(encodedArray);
}

export function buildEncodedJson(object: any) {
    let json = generateSerializableJson(object);
    if (!hasValue(json)) {
        return null;
    }
    let encoder = new TextEncoder();
    let encodedArray = encoder.encode(json!);
    return encodedArray;
}

// Converts a base64 string to an ArrayBuffer
export function base64ToArrayBuffer(base64): Uint8Array {
    const binaryString = atob(base64);
    const bytes = new Uint8Array(binaryString.length);
    for (let i = 0; i < binaryString.length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes;
}

// endregion

// region Load Modules

let _authenticationManager: AuthenticationManager | null = null;
export function getAuthenticationManager(dotNetRef: any, apiKey: string | null, appId: string | null,
                                         portalUrl: string | null, trustedServers: string[] | null, fontsUrl: string | null): AuthenticationManager {
    if (_authenticationManager === null) {
        _authenticationManager = new AuthenticationManager(dotNetRef, apiKey, appId, portalUrl, trustedServers, fontsUrl);
    }
    return _authenticationManager;
}

export async function getProjectionEngineWrapper(): Promise<ProjectionWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new ProjectionWrapper();
}

export async function getGeometryEngineWrapper(): Promise<GeometryEngineWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }
    return new GeometryEngineWrapper();
}

export async function getLocationServiceWrapper(): Promise<LocatorWrapper> {
    if (ProtoGraphicCollection === undefined) {
        await loadProtobuf();
    }

    return new LocatorWrapper();
}

// endregion