// override generated code in this file
import PortalItemGenerated from './portalItem.gb';
import PortalItem from '@arcgis/core/portal/PortalItem';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from "./arcGisJsInterop";

export default class PortalItemWrapper extends PortalItemGenerated {

    constructor(component: PortalItem) {
        super(component);
    }

}
export async function buildJsPortalItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let jsPortalItem: any = {};
    if (hasValue(dotNetObject.extent)) {
        let { buildJsExtent } = await import('./extent');
        jsPortalItem.extent = buildJsExtent(dotNetObject.extent) as any;
    }
    if (hasValue(dotNetObject.portal)) {
        let { buildJsPortal } = await import('./portal');
        jsPortalItem.portal = await buildJsPortal(dotNetObject.portal, layerId, viewId) as any;
    }

    if (hasValue(dotNetObject.access)) {
        jsPortalItem.access = dotNetObject.access;
    }
    if (hasValue(dotNetObject.accessInformation)) {
        jsPortalItem.accessInformation = dotNetObject.accessInformation;
    }
    if (hasValue(dotNetObject.apiKey)) {
        jsPortalItem.apiKey = dotNetObject.apiKey;
    }
    if (hasValue(dotNetObject.avgRating)) {
        jsPortalItem.avgRating = dotNetObject.avgRating;
    }
    if (hasValue(dotNetObject.categories) && dotNetObject.categories.length > 0) {
        jsPortalItem.categories = dotNetObject.categories;
    }
    if (hasValue(dotNetObject.created)) {
        jsPortalItem.created = dotNetObject.created;
    }
    if (hasValue(dotNetObject.culture)) {
        jsPortalItem.culture = dotNetObject.culture;
    }
    if (hasValue(dotNetObject.description)) {
        jsPortalItem.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.groupCategories) && dotNetObject.groupCategories.length > 0) {
        jsPortalItem.groupCategories = dotNetObject.groupCategories;
    }
    if (hasValue(dotNetObject.licenseInfo)) {
        jsPortalItem.licenseInfo = dotNetObject.licenseInfo;
    }
    if (hasValue(dotNetObject.modified)) {
        jsPortalItem.modified = dotNetObject.modified;
    }
    if (hasValue(dotNetObject.name)) {
        jsPortalItem.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.numComments)) {
        jsPortalItem.numComments = dotNetObject.numComments;
    }
    if (hasValue(dotNetObject.numRatings)) {
        jsPortalItem.numRatings = dotNetObject.numRatings;
    }
    if (hasValue(dotNetObject.numViews)) {
        jsPortalItem.numViews = dotNetObject.numViews;
    }
    if (hasValue(dotNetObject.owner)) {
        jsPortalItem.owner = dotNetObject.owner;
    }
    if (hasValue(dotNetObject.ownerFolder)) {
        jsPortalItem.ownerFolder = dotNetObject.ownerFolder;
    }
    if (hasValue(dotNetObject.portalItemId)) {
        jsPortalItem.id = dotNetObject.portalItemId;
    }
    if (hasValue(dotNetObject.screenshots) && dotNetObject.screenshots.length > 0) {
        jsPortalItem.screenshots = dotNetObject.screenshots;
    }
    if (hasValue(dotNetObject.size)) {
        jsPortalItem.size = dotNetObject.size;
    }
    if (hasValue(dotNetObject.snippet)) {
        jsPortalItem.snippet = dotNetObject.snippet;
    }
    if (hasValue(dotNetObject.tags) && dotNetObject.tags.length > 0) {
        jsPortalItem.tags = dotNetObject.tags;
    }
    if (hasValue(dotNetObject.title)) {
        jsPortalItem.title = dotNetObject.title;
    }
    if (hasValue(dotNetObject.typeKeywords) && dotNetObject.typeKeywords.length > 0) {
        jsPortalItem.typeKeywords = dotNetObject.typeKeywords;
    }
    if (hasValue(dotNetObject.url)) {
        jsPortalItem.url = dotNetObject.url;
    }

    let portalItemWrapper = new PortalItemWrapper(jsPortalItem);
    portalItemWrapper.geoBlazorId = dotNetObject.id;
    portalItemWrapper.viewId = viewId;
    portalItemWrapper.layerId = layerId;

    let jsObjectRef = DotNet.createJSObjectReference(portalItemWrapper);
    jsObjectRefs[dotNetObject.id] = portalItemWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsPortalItem;

    try {
        let dnInstantiatedObject = await buildDotNetPortalItem(jsPortalItem);

        let seenObjects = new WeakMap();
        await dotNetObject.dotNetComponentReference?.invokeMethodAsync('OnJsComponentCreated',
            jsObjectRef, JSON.stringify(dnInstantiatedObject, function (key, value) {
                if (key.startsWith('_') || key === 'jsComponentReference') {
                    return undefined;
                }
                if (typeof value === 'object' && value !== null
                    && !(Array.isArray(value) && value.length === 0)) {
                    if (seenObjects.has(value)) {
                        console.debug(`Circular reference in serializing type PortalItem detected at path: ${key}, value: ${value.declaredClass}`);
                        return undefined;
                    }
                    seenObjects.set(value, true);
                }
                return value;
            }));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for PortalItem', e);
    }

    return jsPortalItem;
}

export async function buildDotNetPortalItem(jsObject: any): Promise<any> {
    let {buildDotNetPortalItemGenerated} = await import('./portalItem.gb');
    return await buildDotNetPortalItemGenerated(jsObject);
}
