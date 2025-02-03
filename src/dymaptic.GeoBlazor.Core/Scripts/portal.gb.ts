// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import Portal from '@arcgis/core/portal/Portal';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class PortalGenerated implements IPropertyWrapper {
    public component: Portal;
    public readonly geoBlazorId: string = '';

    constructor(component: Portal) {
        this.component = component;
        // set all properties from component
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    
    async createElevationLayers(): Promise<any> {
        let result = await this.component.createElevationLayers();
        let { buildDotNetElevationLayer } = await import('./elevationLayer');
        return result.map(async i => await buildDotNetElevationLayer(i));
    }

    async fetchBasemaps(basemapGalleryGroupQuery: any,
        options: any): Promise<any> {
        let result = await this.component.fetchBasemaps(basemapGalleryGroupQuery,
            options);
        let { buildDotNetBasemap } = await import('./basemap');
        return result.map(async i => await buildDotNetBasemap(i));
    }

    async fetchCategorySchema(options: any): Promise<any> {
        return await this.component.fetchCategorySchema(options);
    }

    async fetchFeaturedGroups(options: any): Promise<any> {
        return await this.component.fetchFeaturedGroups(options);
    }

    async fetchRegions(options: any): Promise<any> {
        return await this.component.fetchRegions(options);
    }

    async fetchSettings(options: any): Promise<any> {
        return await this.component.fetchSettings(options);
    }

    async queryGroups(queryParams: any,
        options: any): Promise<any> {
        return await this.component.queryGroups(queryParams,
            options);
    }

    async queryItems(queryParams: any,
        options: any): Promise<any> {
        return await this.component.queryItems(queryParams,
            options);
    }

    async queryUsers(queryParams: any,
        options: any): Promise<any> {
        return await this.component.queryUsers(queryParams,
            options);
    }

    // region properties
    
    async getDefaultBasemap(): Promise<any> {
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.component.defaultBasemap);
    }
    async setDefaultBasemap(value: any): Promise<void> {
        let { buildJsBasemap } = await import('./basemap');
        this.component.defaultBasemap = await buildJsBasemap(value);
    }
    async getDefaultDevBasemap(): Promise<any> {
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.component.defaultDevBasemap);
    }
    async setDefaultDevBasemap(value: any): Promise<void> {
        let { buildJsBasemap } = await import('./basemap');
        this.component.defaultDevBasemap = await buildJsBasemap(value);
    }
    async getDefaultVectorBasemap(): Promise<any> {
        let { buildDotNetBasemap } = await import('./basemap');
        return await buildDotNetBasemap(this.component.defaultVectorBasemap);
    }
    async setDefaultVectorBasemap(value: any): Promise<void> {
        let { buildJsBasemap } = await import('./basemap');
        this.component.defaultVectorBasemap = await buildJsBasemap(value);
    }
    async getFeaturedGroups(): Promise<any> {
        let { buildDotNetPortalFeaturedGroups } = await import('./portalFeaturedGroups');
        return this.component.featuredGroups.map(async i => await buildDotNetPortalFeaturedGroups(i));
    }
    
    async setFeaturedGroups(value: any): Promise<void> {
        let { buildJsPortalFeaturedGroups } = await import('./portalFeaturedGroups');
        this.component.featuredGroups = value.map(async i => await buildJsPortalFeaturedGroups(i));
    }
    
    async getUser(): Promise<any> {
        let { buildDotNetPortalUser } = await import('./portalUser');
        return await buildDotNetPortalUser(this.component.user);
    }
    async setUser(value: any): Promise<void> {
        let { buildJsPortalUser } = await import('./portalUser');
        this.component.user = await buildJsPortalUser(value);
    }
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsPortalGenerated(dotNetObject: any): Promise<any> {
    let { default: Portal } = await import('@arcgis/core/portal/Portal');
    let jsPortal = new Portal();
    if (hasValue(dotNetObject.defaultExtent)) {
        let { buildJsExtent } = await import('extent');
        jsPortal.defaultExtent = buildJsExtent(dotNetObject.defaultExtent) as any;

    }
    if (hasValue(dotNetObject.featuredGroups)) {
        let { buildJsPortalFeaturedGroups } = await import('portalFeaturedGroups');
        jsPortal.featuredGroups = dotNetObject.featuredGroups.map(async i => await buildJsPortalFeaturedGroups(i)) as any;

    }
    if (hasValue(dotNetObject.access)) {
        jsPortal.access = dotNetObject.access;
    }
    if (hasValue(dotNetObject.allSSL)) {
        jsPortal.allSSL = dotNetObject.allSSL;
    }
    if (hasValue(dotNetObject.authMode)) {
        jsPortal.authMode = dotNetObject.authMode;
    }
    if (hasValue(dotNetObject.authorizedCrossOriginDomains)) {
        jsPortal.authorizedCrossOriginDomains = dotNetObject.authorizedCrossOriginDomains;
    }
    if (hasValue(dotNetObject.basemapGalleryGroupQuery)) {
        jsPortal.basemapGalleryGroupQuery = dotNetObject.basemapGalleryGroupQuery;
    }
    if (hasValue(dotNetObject.basemapGalleryGroupQuery3D)) {
        jsPortal.basemapGalleryGroupQuery3D = dotNetObject.basemapGalleryGroupQuery3D;
    }
    if (hasValue(dotNetObject.bingKey)) {
        jsPortal.bingKey = dotNetObject.bingKey;
    }
    if (hasValue(dotNetObject.canListApps)) {
        jsPortal.canListApps = dotNetObject.canListApps;
    }
    if (hasValue(dotNetObject.canListData)) {
        jsPortal.canListData = dotNetObject.canListData;
    }
    if (hasValue(dotNetObject.canListPreProvisionedItems)) {
        jsPortal.canListPreProvisionedItems = dotNetObject.canListPreProvisionedItems;
    }
    if (hasValue(dotNetObject.canProvisionDirectPurchase)) {
        jsPortal.canProvisionDirectPurchase = dotNetObject.canProvisionDirectPurchase;
    }
    if (hasValue(dotNetObject.canSearchPublic)) {
        jsPortal.canSearchPublic = dotNetObject.canSearchPublic;
    }
    if (hasValue(dotNetObject.canShareBingPublic)) {
        jsPortal.canShareBingPublic = dotNetObject.canShareBingPublic;
    }
    if (hasValue(dotNetObject.canSharePublic)) {
        jsPortal.canSharePublic = dotNetObject.canSharePublic;
    }
    if (hasValue(dotNetObject.canSignInArcGIS)) {
        jsPortal.canSignInArcGIS = dotNetObject.canSignInArcGIS;
    }
    if (hasValue(dotNetObject.canSignInIDP)) {
        jsPortal.canSignInIDP = dotNetObject.canSignInIDP;
    }
    if (hasValue(dotNetObject.colorSetsGroupQuery)) {
        jsPortal.colorSetsGroupQuery = dotNetObject.colorSetsGroupQuery;
    }
    if (hasValue(dotNetObject.commentsEnabled)) {
        jsPortal.commentsEnabled = dotNetObject.commentsEnabled;
    }
    if (hasValue(dotNetObject.created)) {
        jsPortal.created = dotNetObject.created;
    }
    if (hasValue(dotNetObject.culture)) {
        jsPortal.culture = dotNetObject.culture;
    }
    if (hasValue(dotNetObject.customBaseUrl)) {
        jsPortal.customBaseUrl = dotNetObject.customBaseUrl;
    }
    if (hasValue(dotNetObject.description)) {
        jsPortal.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.devBasemapGalleryGroupQuery)) {
        jsPortal.devBasemapGalleryGroupQuery = dotNetObject.devBasemapGalleryGroupQuery;
    }
    if (hasValue(dotNetObject.eueiEnabled)) {
        jsPortal.eueiEnabled = dotNetObject.eueiEnabled;
    }
    if (hasValue(dotNetObject.featuredItemsGroupQuery)) {
        jsPortal.featuredItemsGroupQuery = dotNetObject.featuredItemsGroupQuery;
    }
    if (hasValue(dotNetObject.galleryTemplatesGroupQuery)) {
        jsPortal.galleryTemplatesGroupQuery = dotNetObject.galleryTemplatesGroupQuery;
    }
    if (hasValue(dotNetObject.hasCategorySchema)) {
        jsPortal.hasCategorySchema = dotNetObject.hasCategorySchema;
    }
    if (hasValue(dotNetObject.helperServices)) {
        jsPortal.helperServices = dotNetObject.helperServices;
    }
    if (hasValue(dotNetObject.homePageFeaturedContent)) {
        jsPortal.homePageFeaturedContent = dotNetObject.homePageFeaturedContent;
    }
    if (hasValue(dotNetObject.homePageFeaturedContentCount)) {
        jsPortal.homePageFeaturedContentCount = dotNetObject.homePageFeaturedContentCount;
    }
    if (hasValue(dotNetObject.httpPort)) {
        jsPortal.httpPort = dotNetObject.httpPort;
    }
    if (hasValue(dotNetObject.httpsPort)) {
        jsPortal.httpsPort = dotNetObject.httpsPort;
    }
    if (hasValue(dotNetObject.ipCntryCode)) {
        jsPortal.ipCntryCode = dotNetObject.ipCntryCode;
    }
    if (hasValue(dotNetObject.isPortal)) {
        jsPortal.isPortal = dotNetObject.isPortal;
    }
    if (hasValue(dotNetObject.isReadOnly)) {
        jsPortal.isReadOnly = dotNetObject.isReadOnly;
    }
    if (hasValue(dotNetObject.layerTemplatesGroupQuery)) {
        jsPortal.layerTemplatesGroupQuery = dotNetObject.layerTemplatesGroupQuery;
    }
    if (hasValue(dotNetObject.maxTokenExpirationMinutes)) {
        jsPortal.maxTokenExpirationMinutes = dotNetObject.maxTokenExpirationMinutes;
    }
    if (hasValue(dotNetObject.modified)) {
        jsPortal.modified = dotNetObject.modified;
    }
    if (hasValue(dotNetObject.name)) {
        jsPortal.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.portalHostname)) {
        jsPortal.portalHostname = dotNetObject.portalHostname;
    }
    if (hasValue(dotNetObject.portalId)) {
        jsPortal.id = dotNetObject.portalId;
    }
    if (hasValue(dotNetObject.portalMode)) {
        jsPortal.portalMode = dotNetObject.portalMode;
    }
    if (hasValue(dotNetObject.portalProperties)) {
        jsPortal.portalProperties = dotNetObject.portalProperties;
    }
    if (hasValue(dotNetObject.recycleBinEnabled)) {
        jsPortal.recycleBinEnabled = dotNetObject.recycleBinEnabled;
    }
    if (hasValue(dotNetObject.region)) {
        jsPortal.region = dotNetObject.region;
    }
    if (hasValue(dotNetObject.rotatorPanels)) {
        jsPortal.rotatorPanels = dotNetObject.rotatorPanels;
    }
    if (hasValue(dotNetObject.showHomePageDescription)) {
        jsPortal.showHomePageDescription = dotNetObject.showHomePageDescription;
    }
    if (hasValue(dotNetObject.supportsHostedServices)) {
        jsPortal.supportsHostedServices = dotNetObject.supportsHostedServices;
    }
    if (hasValue(dotNetObject.symbolSetsGroupQuery)) {
        jsPortal.symbolSetsGroupQuery = dotNetObject.symbolSetsGroupQuery;
    }
    if (hasValue(dotNetObject.templatesGroupQuery)) {
        jsPortal.templatesGroupQuery = dotNetObject.templatesGroupQuery;
    }
    if (hasValue(dotNetObject.units)) {
        jsPortal.units = dotNetObject.units;
    }
    if (hasValue(dotNetObject.url)) {
        jsPortal.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.urlKey)) {
        jsPortal.urlKey = dotNetObject.urlKey;
    }
    if (hasValue(dotNetObject.use3dBasemaps)) {
        jsPortal.use3dBasemaps = dotNetObject.use3dBasemaps;
    }
    if (hasValue(dotNetObject.useStandardizedQuery)) {
        jsPortal.useStandardizedQuery = dotNetObject.useStandardizedQuery;
    }
    if (hasValue(dotNetObject.useVectorBasemaps)) {
        jsPortal.useVectorBasemaps = dotNetObject.useVectorBasemaps;
    }
    if (hasValue(dotNetObject.vectorBasemapGalleryGroupQuery)) {
        jsPortal.vectorBasemapGalleryGroupQuery = dotNetObject.vectorBasemapGalleryGroupQuery;
    }
    let { default: PortalWrapper } = await import('./portal');
    let portalWrapper = new PortalWrapper(jsPortal);
    jsPortal.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(portalWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = portalWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsPortal;
    
    return jsPortal;
}

export async function buildDotNetPortalGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetPortal: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.defaultExtent)) {
            let { buildDotNetExtent } = await import('./dotNetBuilder');
            dotNetPortal.defaultExtent = await buildDotNetExtent(jsObject.defaultExtent);
        }
        if (hasValue(jsObject.featuredGroups)) {
            let { buildDotNetPortalFeaturedGroups } = await import('./portalFeaturedGroups');
            dotNetPortal.featuredGroups = jsObject.featuredGroups.map(async i => await buildDotNetPortalFeaturedGroups(i));
        }
        dotNetPortal.access = jsObject.access;
        dotNetPortal.allSSL = jsObject.allSSL;
        dotNetPortal.authMode = jsObject.authMode;
        dotNetPortal.authorizedCrossOriginDomains = jsObject.authorizedCrossOriginDomains;
        dotNetPortal.basemapGalleryGroupQuery = jsObject.basemapGalleryGroupQuery;
        dotNetPortal.basemapGalleryGroupQuery3D = jsObject.basemapGalleryGroupQuery3D;
        dotNetPortal.bingKey = jsObject.bingKey;
        dotNetPortal.canListApps = jsObject.canListApps;
        dotNetPortal.canListData = jsObject.canListData;
        dotNetPortal.canListPreProvisionedItems = jsObject.canListPreProvisionedItems;
        dotNetPortal.canProvisionDirectPurchase = jsObject.canProvisionDirectPurchase;
        dotNetPortal.canSearchPublic = jsObject.canSearchPublic;
        dotNetPortal.canShareBingPublic = jsObject.canShareBingPublic;
        dotNetPortal.canSharePublic = jsObject.canSharePublic;
        dotNetPortal.canSignInArcGIS = jsObject.canSignInArcGIS;
        dotNetPortal.canSignInIDP = jsObject.canSignInIDP;
        dotNetPortal.colorSetsGroupQuery = jsObject.colorSetsGroupQuery;
        dotNetPortal.commentsEnabled = jsObject.commentsEnabled;
        dotNetPortal.created = jsObject.created;
        dotNetPortal.culture = jsObject.culture;
        dotNetPortal.customBaseUrl = jsObject.customBaseUrl;
        dotNetPortal.description = jsObject.description;
        dotNetPortal.devBasemapGalleryGroupQuery = jsObject.devBasemapGalleryGroupQuery;
        dotNetPortal.eueiEnabled = jsObject.eueiEnabled;
        dotNetPortal.featuredItemsGroupQuery = jsObject.featuredItemsGroupQuery;
        dotNetPortal.galleryTemplatesGroupQuery = jsObject.galleryTemplatesGroupQuery;
        dotNetPortal.hasCategorySchema = jsObject.hasCategorySchema;
        dotNetPortal.helperServices = jsObject.helperServices;
        dotNetPortal.homePageFeaturedContent = jsObject.homePageFeaturedContent;
        dotNetPortal.homePageFeaturedContentCount = jsObject.homePageFeaturedContentCount;
        dotNetPortal.httpPort = jsObject.httpPort;
        dotNetPortal.httpsPort = jsObject.httpsPort;
        dotNetPortal.ipCntryCode = jsObject.ipCntryCode;
        dotNetPortal.isOrganization = jsObject.isOrganization;
        dotNetPortal.isPortal = jsObject.isPortal;
        dotNetPortal.isReadOnly = jsObject.isReadOnly;
        dotNetPortal.layerTemplatesGroupQuery = jsObject.layerTemplatesGroupQuery;
        dotNetPortal.loaded = jsObject.loaded;
        dotNetPortal.maxTokenExpirationMinutes = jsObject.maxTokenExpirationMinutes;
        dotNetPortal.modified = jsObject.modified;
        dotNetPortal.name = jsObject.name;
        dotNetPortal.portalHostname = jsObject.portalHostname;
        dotNetPortal.portalId = jsObject.id;
        dotNetPortal.portalMode = jsObject.portalMode;
        dotNetPortal.portalProperties = jsObject.portalProperties;
        dotNetPortal.recycleBinEnabled = jsObject.recycleBinEnabled;
        dotNetPortal.region = jsObject.region;
        dotNetPortal.restUrl = jsObject.restUrl;
        dotNetPortal.rotatorPanels = jsObject.rotatorPanels;
        dotNetPortal.showHomePageDescription = jsObject.showHomePageDescription;
        dotNetPortal.sourceJSON = jsObject.sourceJSON;
        dotNetPortal.supportsHostedServices = jsObject.supportsHostedServices;
        dotNetPortal.symbolSetsGroupQuery = jsObject.symbolSetsGroupQuery;
        dotNetPortal.templatesGroupQuery = jsObject.templatesGroupQuery;
        dotNetPortal.thumbnailUrl = jsObject.thumbnailUrl;
        dotNetPortal.units = jsObject.units;
        dotNetPortal.url = jsObject.url;
        dotNetPortal.urlKey = jsObject.urlKey;
        dotNetPortal.use3dBasemaps = jsObject.use3dBasemaps;
        dotNetPortal.useStandardizedQuery = jsObject.useStandardizedQuery;
        dotNetPortal.useVectorBasemaps = jsObject.useVectorBasemaps;
        dotNetPortal.vectorBasemapGalleryGroupQuery = jsObject.vectorBasemapGalleryGroupQuery;
    return dotNetPortal;
}

