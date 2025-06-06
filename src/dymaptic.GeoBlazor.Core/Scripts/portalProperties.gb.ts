// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue, removeCircularReferences } from './arcGisJsInterop';
import { buildDotNetPortalProperties } from './portalProperties';

export async function buildJsPortalPropertiesGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsPortalProperties: any = {};

    if (hasValue(dotNetObject.access)) {
        jsPortalProperties.access = dotNetObject.access;
    }
    if (hasValue(dotNetObject.allSSL)) {
        jsPortalProperties.allSSL = dotNetObject.allSSL;
    }
    if (hasValue(dotNetObject.authMode)) {
        jsPortalProperties.authMode = dotNetObject.authMode;
    }
    if (hasValue(dotNetObject.authorizedCrossOriginDomains)) {
        jsPortalProperties.authorizedCrossOriginDomains = dotNetObject.authorizedCrossOriginDomains;
    }
    if (hasValue(dotNetObject.basemapGalleryGroupQuery)) {
        jsPortalProperties.basemapGalleryGroupQuery = dotNetObject.basemapGalleryGroupQuery;
    }
    if (hasValue(dotNetObject.basemapGalleryGroupQuery3D)) {
        jsPortalProperties.basemapGalleryGroupQuery3D = dotNetObject.basemapGalleryGroupQuery3D;
    }
    if (hasValue(dotNetObject.bingKey)) {
        jsPortalProperties.bingKey = dotNetObject.bingKey;
    }
    if (hasValue(dotNetObject.canListApps)) {
        jsPortalProperties.canListApps = dotNetObject.canListApps;
    }
    if (hasValue(dotNetObject.canListData)) {
        jsPortalProperties.canListData = dotNetObject.canListData;
    }
    if (hasValue(dotNetObject.canListPreProvisionedItems)) {
        jsPortalProperties.canListPreProvisionedItems = dotNetObject.canListPreProvisionedItems;
    }
    if (hasValue(dotNetObject.canProvisionDirectPurchase)) {
        jsPortalProperties.canProvisionDirectPurchase = dotNetObject.canProvisionDirectPurchase;
    }
    if (hasValue(dotNetObject.canSearchPublic)) {
        jsPortalProperties.canSearchPublic = dotNetObject.canSearchPublic;
    }
    if (hasValue(dotNetObject.canShareBingPublic)) {
        jsPortalProperties.canShareBingPublic = dotNetObject.canShareBingPublic;
    }
    if (hasValue(dotNetObject.canSharePublic)) {
        jsPortalProperties.canSharePublic = dotNetObject.canSharePublic;
    }
    if (hasValue(dotNetObject.canSignInArcGIS)) {
        jsPortalProperties.canSignInArcGIS = dotNetObject.canSignInArcGIS;
    }
    if (hasValue(dotNetObject.canSignInIDP)) {
        jsPortalProperties.canSignInIDP = dotNetObject.canSignInIDP;
    }
    if (hasValue(dotNetObject.colorSetsGroupQuery)) {
        jsPortalProperties.colorSetsGroupQuery = dotNetObject.colorSetsGroupQuery;
    }
    if (hasValue(dotNetObject.commentsEnabled)) {
        jsPortalProperties.commentsEnabled = dotNetObject.commentsEnabled;
    }
    if (hasValue(dotNetObject.created)) {
        jsPortalProperties.created = dotNetObject.created;
    }
    if (hasValue(dotNetObject.culture)) {
        jsPortalProperties.culture = dotNetObject.culture;
    }
    if (hasValue(dotNetObject.customBaseUrl)) {
        jsPortalProperties.customBaseUrl = dotNetObject.customBaseUrl;
    }
    if (hasValue(dotNetObject.default3DBasemapQuery)) {
        jsPortalProperties.default3DBasemapQuery = dotNetObject.default3DBasemapQuery;
    }
    if (hasValue(dotNetObject.defaultBasemap)) {
        jsPortalProperties.defaultBasemap = dotNetObject.defaultBasemap;
    }
    if (hasValue(dotNetObject.defaultDevBasemap)) {
        jsPortalProperties.defaultDevBasemap = dotNetObject.defaultDevBasemap;
    }
    if (hasValue(dotNetObject.defaultExtent)) {
        jsPortalProperties.defaultExtent = dotNetObject.defaultExtent;
    }
    if (hasValue(dotNetObject.defaultVectorBasemap)) {
        jsPortalProperties.defaultVectorBasemap = dotNetObject.defaultVectorBasemap;
    }
    if (hasValue(dotNetObject.description)) {
        jsPortalProperties.description = dotNetObject.description;
    }
    if (hasValue(dotNetObject.devBasemapGalleryGroupQuery)) {
        jsPortalProperties.devBasemapGalleryGroupQuery = dotNetObject.devBasemapGalleryGroupQuery;
    }
    if (hasValue(dotNetObject.eueiEnabled)) {
        jsPortalProperties.eueiEnabled = dotNetObject.eueiEnabled;
    }
    if (hasValue(dotNetObject.featuredGroups)) {
        jsPortalProperties.featuredGroups = dotNetObject.featuredGroups;
    }
    if (hasValue(dotNetObject.featuredItemsGroupQuery)) {
        jsPortalProperties.featuredItemsGroupQuery = dotNetObject.featuredItemsGroupQuery;
    }
    if (hasValue(dotNetObject.galleryTemplatesGroupQuery)) {
        jsPortalProperties.galleryTemplatesGroupQuery = dotNetObject.galleryTemplatesGroupQuery;
    }
    if (hasValue(dotNetObject.hasCategorySchema)) {
        jsPortalProperties.hasCategorySchema = dotNetObject.hasCategorySchema;
    }
    if (hasValue(dotNetObject.hasClassificationSchema)) {
        jsPortalProperties.hasClassificationSchema = dotNetObject.hasClassificationSchema;
    }
    if (hasValue(dotNetObject.helperServices)) {
        jsPortalProperties.helperServices = dotNetObject.helperServices;
    }
    if (hasValue(dotNetObject.homePageFeaturedContent)) {
        jsPortalProperties.homePageFeaturedContent = dotNetObject.homePageFeaturedContent;
    }
    if (hasValue(dotNetObject.homePageFeaturedContentCount)) {
        jsPortalProperties.homePageFeaturedContentCount = dotNetObject.homePageFeaturedContentCount;
    }
    if (hasValue(dotNetObject.httpPort)) {
        jsPortalProperties.httpPort = dotNetObject.httpPort;
    }
    if (hasValue(dotNetObject.httpsPort)) {
        jsPortalProperties.httpsPort = dotNetObject.httpsPort;
    }
    if (hasValue(dotNetObject.ipCntryCode)) {
        jsPortalProperties.ipCntryCode = dotNetObject.ipCntryCode;
    }
    if (hasValue(dotNetObject.isPortal)) {
        jsPortalProperties.isPortal = dotNetObject.isPortal;
    }
    if (hasValue(dotNetObject.isReadOnly)) {
        jsPortalProperties.isReadOnly = dotNetObject.isReadOnly;
    }
    if (hasValue(dotNetObject.layerTemplatesGroupQuery)) {
        jsPortalProperties.layerTemplatesGroupQuery = dotNetObject.layerTemplatesGroupQuery;
    }
    if (hasValue(dotNetObject.maxTokenExpirationMinutes)) {
        jsPortalProperties.maxTokenExpirationMinutes = dotNetObject.maxTokenExpirationMinutes;
    }
    if (hasValue(dotNetObject.modified)) {
        jsPortalProperties.modified = dotNetObject.modified;
    }
    if (hasValue(dotNetObject.name)) {
        jsPortalProperties.name = dotNetObject.name;
    }
    if (hasValue(dotNetObject.portalHostname)) {
        jsPortalProperties.portalHostname = dotNetObject.portalHostname;
    }
    if (hasValue(dotNetObject.portalId)) {
        jsPortalProperties.id = dotNetObject.portalId;
    }
    if (hasValue(dotNetObject.portalMode)) {
        jsPortalProperties.portalMode = dotNetObject.portalMode;
    }
    if (hasValue(dotNetObject.portalProperties)) {
        jsPortalProperties.portalProperties = dotNetObject.portalProperties;
    }
    if (hasValue(dotNetObject.recycleBinEnabled)) {
        jsPortalProperties.recycleBinEnabled = dotNetObject.recycleBinEnabled;
    }
    if (hasValue(dotNetObject.region)) {
        jsPortalProperties.region = dotNetObject.region;
    }
    if (hasValue(dotNetObject.rotatorPanels)) {
        jsPortalProperties.rotatorPanels = dotNetObject.rotatorPanels;
    }
    if (hasValue(dotNetObject.showHomePageDescription)) {
        jsPortalProperties.showHomePageDescription = dotNetObject.showHomePageDescription;
    }
    if (hasValue(dotNetObject.sourceJSON)) {
        jsPortalProperties.sourceJSON = dotNetObject.sourceJSON;
    }
    if (hasValue(dotNetObject.supportsHostedServices)) {
        jsPortalProperties.supportsHostedServices = dotNetObject.supportsHostedServices;
    }
    if (hasValue(dotNetObject.symbolSetsGroupQuery)) {
        jsPortalProperties.symbolSetsGroupQuery = dotNetObject.symbolSetsGroupQuery;
    }
    if (hasValue(dotNetObject.templatesGroupQuery)) {
        jsPortalProperties.templatesGroupQuery = dotNetObject.templatesGroupQuery;
    }
    if (hasValue(dotNetObject.units)) {
        jsPortalProperties.units = dotNetObject.units;
    }
    if (hasValue(dotNetObject.url)) {
        jsPortalProperties.url = dotNetObject.url;
    }
    if (hasValue(dotNetObject.urlKey)) {
        jsPortalProperties.urlKey = dotNetObject.urlKey;
    }
    if (hasValue(dotNetObject.use3dBasemaps)) {
        jsPortalProperties.use3dBasemaps = dotNetObject.use3dBasemaps;
    }
    if (hasValue(dotNetObject.useDefault3dBasemap)) {
        jsPortalProperties.useDefault3dBasemap = dotNetObject.useDefault3dBasemap;
    }
    if (hasValue(dotNetObject.user)) {
        jsPortalProperties.user = dotNetObject.user;
    }
    if (hasValue(dotNetObject.useStandardizedQuery)) {
        jsPortalProperties.useStandardizedQuery = dotNetObject.useStandardizedQuery;
    }
    if (hasValue(dotNetObject.useVectorBasemaps)) {
        jsPortalProperties.useVectorBasemaps = dotNetObject.useVectorBasemaps;
    }
    if (hasValue(dotNetObject.vectorBasemapGalleryGroupQuery)) {
        jsPortalProperties.vectorBasemapGalleryGroupQuery = dotNetObject.vectorBasemapGalleryGroupQuery;
    }
    
    jsObjectRefs[dotNetObject.id] = jsPortalProperties;
    arcGisObjectRefs[dotNetObject.id] = jsPortalProperties;
    
    return jsPortalProperties;
}


export async function buildDotNetPortalPropertiesGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetPortalProperties: any = {};
    
    if (hasValue(jsObject.access)) {
        dotNetPortalProperties.access = removeCircularReferences(jsObject.access);
    }
    
    if (hasValue(jsObject.allSSL)) {
        dotNetPortalProperties.allSSL = removeCircularReferences(jsObject.allSSL);
    }
    
    if (hasValue(jsObject.authMode)) {
        dotNetPortalProperties.authMode = removeCircularReferences(jsObject.authMode);
    }
    
    if (hasValue(jsObject.authorizedCrossOriginDomains)) {
        dotNetPortalProperties.authorizedCrossOriginDomains = removeCircularReferences(jsObject.authorizedCrossOriginDomains);
    }
    
    if (hasValue(jsObject.basemapGalleryGroupQuery)) {
        dotNetPortalProperties.basemapGalleryGroupQuery = removeCircularReferences(jsObject.basemapGalleryGroupQuery);
    }
    
    if (hasValue(jsObject.basemapGalleryGroupQuery3D)) {
        dotNetPortalProperties.basemapGalleryGroupQuery3D = removeCircularReferences(jsObject.basemapGalleryGroupQuery3D);
    }
    
    if (hasValue(jsObject.bingKey)) {
        dotNetPortalProperties.bingKey = removeCircularReferences(jsObject.bingKey);
    }
    
    if (hasValue(jsObject.canListApps)) {
        dotNetPortalProperties.canListApps = removeCircularReferences(jsObject.canListApps);
    }
    
    if (hasValue(jsObject.canListData)) {
        dotNetPortalProperties.canListData = removeCircularReferences(jsObject.canListData);
    }
    
    if (hasValue(jsObject.canListPreProvisionedItems)) {
        dotNetPortalProperties.canListPreProvisionedItems = removeCircularReferences(jsObject.canListPreProvisionedItems);
    }
    
    if (hasValue(jsObject.canProvisionDirectPurchase)) {
        dotNetPortalProperties.canProvisionDirectPurchase = removeCircularReferences(jsObject.canProvisionDirectPurchase);
    }
    
    if (hasValue(jsObject.canSearchPublic)) {
        dotNetPortalProperties.canSearchPublic = removeCircularReferences(jsObject.canSearchPublic);
    }
    
    if (hasValue(jsObject.canShareBingPublic)) {
        dotNetPortalProperties.canShareBingPublic = removeCircularReferences(jsObject.canShareBingPublic);
    }
    
    if (hasValue(jsObject.canSharePublic)) {
        dotNetPortalProperties.canSharePublic = removeCircularReferences(jsObject.canSharePublic);
    }
    
    if (hasValue(jsObject.canSignInArcGIS)) {
        dotNetPortalProperties.canSignInArcGIS = removeCircularReferences(jsObject.canSignInArcGIS);
    }
    
    if (hasValue(jsObject.canSignInIDP)) {
        dotNetPortalProperties.canSignInIDP = removeCircularReferences(jsObject.canSignInIDP);
    }
    
    if (hasValue(jsObject.colorSetsGroupQuery)) {
        dotNetPortalProperties.colorSetsGroupQuery = removeCircularReferences(jsObject.colorSetsGroupQuery);
    }
    
    if (hasValue(jsObject.commentsEnabled)) {
        dotNetPortalProperties.commentsEnabled = removeCircularReferences(jsObject.commentsEnabled);
    }
    
    if (hasValue(jsObject.created)) {
        dotNetPortalProperties.created = removeCircularReferences(jsObject.created);
    }
    
    if (hasValue(jsObject.culture)) {
        dotNetPortalProperties.culture = removeCircularReferences(jsObject.culture);
    }
    
    if (hasValue(jsObject.customBaseUrl)) {
        dotNetPortalProperties.customBaseUrl = removeCircularReferences(jsObject.customBaseUrl);
    }
    
    if (hasValue(jsObject.default3DBasemapQuery)) {
        dotNetPortalProperties.default3DBasemapQuery = removeCircularReferences(jsObject.default3DBasemapQuery);
    }
    
    if (hasValue(jsObject.defaultBasemap)) {
        dotNetPortalProperties.defaultBasemap = removeCircularReferences(jsObject.defaultBasemap);
    }
    
    if (hasValue(jsObject.defaultDevBasemap)) {
        dotNetPortalProperties.defaultDevBasemap = removeCircularReferences(jsObject.defaultDevBasemap);
    }
    
    if (hasValue(jsObject.defaultExtent)) {
        dotNetPortalProperties.defaultExtent = removeCircularReferences(jsObject.defaultExtent);
    }
    
    if (hasValue(jsObject.defaultVectorBasemap)) {
        dotNetPortalProperties.defaultVectorBasemap = removeCircularReferences(jsObject.defaultVectorBasemap);
    }
    
    if (hasValue(jsObject.description)) {
        dotNetPortalProperties.description = removeCircularReferences(jsObject.description);
    }
    
    if (hasValue(jsObject.devBasemapGalleryGroupQuery)) {
        dotNetPortalProperties.devBasemapGalleryGroupQuery = removeCircularReferences(jsObject.devBasemapGalleryGroupQuery);
    }
    
    if (hasValue(jsObject.eueiEnabled)) {
        dotNetPortalProperties.eueiEnabled = removeCircularReferences(jsObject.eueiEnabled);
    }
    
    if (hasValue(jsObject.featuredGroups)) {
        dotNetPortalProperties.featuredGroups = removeCircularReferences(jsObject.featuredGroups);
    }
    
    if (hasValue(jsObject.featuredItemsGroupQuery)) {
        dotNetPortalProperties.featuredItemsGroupQuery = removeCircularReferences(jsObject.featuredItemsGroupQuery);
    }
    
    if (hasValue(jsObject.galleryTemplatesGroupQuery)) {
        dotNetPortalProperties.galleryTemplatesGroupQuery = removeCircularReferences(jsObject.galleryTemplatesGroupQuery);
    }
    
    if (hasValue(jsObject.hasCategorySchema)) {
        dotNetPortalProperties.hasCategorySchema = removeCircularReferences(jsObject.hasCategorySchema);
    }
    
    if (hasValue(jsObject.hasClassificationSchema)) {
        dotNetPortalProperties.hasClassificationSchema = removeCircularReferences(jsObject.hasClassificationSchema);
    }
    
    if (hasValue(jsObject.helperServices)) {
        dotNetPortalProperties.helperServices = removeCircularReferences(jsObject.helperServices);
    }
    
    if (hasValue(jsObject.homePageFeaturedContent)) {
        dotNetPortalProperties.homePageFeaturedContent = removeCircularReferences(jsObject.homePageFeaturedContent);
    }
    
    if (hasValue(jsObject.homePageFeaturedContentCount)) {
        dotNetPortalProperties.homePageFeaturedContentCount = removeCircularReferences(jsObject.homePageFeaturedContentCount);
    }
    
    if (hasValue(jsObject.httpPort)) {
        dotNetPortalProperties.httpPort = removeCircularReferences(jsObject.httpPort);
    }
    
    if (hasValue(jsObject.httpsPort)) {
        dotNetPortalProperties.httpsPort = removeCircularReferences(jsObject.httpsPort);
    }
    
    if (hasValue(jsObject.ipCntryCode)) {
        dotNetPortalProperties.ipCntryCode = removeCircularReferences(jsObject.ipCntryCode);
    }
    
    if (hasValue(jsObject.isPortal)) {
        dotNetPortalProperties.isPortal = removeCircularReferences(jsObject.isPortal);
    }
    
    if (hasValue(jsObject.isReadOnly)) {
        dotNetPortalProperties.isReadOnly = removeCircularReferences(jsObject.isReadOnly);
    }
    
    if (hasValue(jsObject.layerTemplatesGroupQuery)) {
        dotNetPortalProperties.layerTemplatesGroupQuery = removeCircularReferences(jsObject.layerTemplatesGroupQuery);
    }
    
    if (hasValue(jsObject.maxTokenExpirationMinutes)) {
        dotNetPortalProperties.maxTokenExpirationMinutes = removeCircularReferences(jsObject.maxTokenExpirationMinutes);
    }
    
    if (hasValue(jsObject.modified)) {
        dotNetPortalProperties.modified = removeCircularReferences(jsObject.modified);
    }
    
    if (hasValue(jsObject.name)) {
        dotNetPortalProperties.name = removeCircularReferences(jsObject.name);
    }
    
    if (hasValue(jsObject.portalHostname)) {
        dotNetPortalProperties.portalHostname = removeCircularReferences(jsObject.portalHostname);
    }
    
    if (hasValue(jsObject.id)) {
        dotNetPortalProperties.portalId = removeCircularReferences(jsObject.id);
    }
    
    if (hasValue(jsObject.portalMode)) {
        dotNetPortalProperties.portalMode = removeCircularReferences(jsObject.portalMode);
    }
    
    if (hasValue(jsObject.portalProperties)) {
        dotNetPortalProperties.portalProperties = removeCircularReferences(jsObject.portalProperties);
    }
    
    if (hasValue(jsObject.recycleBinEnabled)) {
        dotNetPortalProperties.recycleBinEnabled = removeCircularReferences(jsObject.recycleBinEnabled);
    }
    
    if (hasValue(jsObject.region)) {
        dotNetPortalProperties.region = removeCircularReferences(jsObject.region);
    }
    
    if (hasValue(jsObject.rotatorPanels)) {
        dotNetPortalProperties.rotatorPanels = removeCircularReferences(jsObject.rotatorPanels);
    }
    
    if (hasValue(jsObject.showHomePageDescription)) {
        dotNetPortalProperties.showHomePageDescription = removeCircularReferences(jsObject.showHomePageDescription);
    }
    
    if (hasValue(jsObject.supportsHostedServices)) {
        dotNetPortalProperties.supportsHostedServices = removeCircularReferences(jsObject.supportsHostedServices);
    }
    
    if (hasValue(jsObject.symbolSetsGroupQuery)) {
        dotNetPortalProperties.symbolSetsGroupQuery = removeCircularReferences(jsObject.symbolSetsGroupQuery);
    }
    
    if (hasValue(jsObject.templatesGroupQuery)) {
        dotNetPortalProperties.templatesGroupQuery = removeCircularReferences(jsObject.templatesGroupQuery);
    }
    
    if (hasValue(jsObject.units)) {
        dotNetPortalProperties.units = removeCircularReferences(jsObject.units);
    }
    
    if (hasValue(jsObject.url)) {
        dotNetPortalProperties.url = removeCircularReferences(jsObject.url);
    }
    
    if (hasValue(jsObject.urlKey)) {
        dotNetPortalProperties.urlKey = removeCircularReferences(jsObject.urlKey);
    }
    
    if (hasValue(jsObject.use3dBasemaps)) {
        dotNetPortalProperties.use3dBasemaps = removeCircularReferences(jsObject.use3dBasemaps);
    }
    
    if (hasValue(jsObject.useDefault3dBasemap)) {
        dotNetPortalProperties.useDefault3dBasemap = removeCircularReferences(jsObject.useDefault3dBasemap);
    }
    
    if (hasValue(jsObject.user)) {
        dotNetPortalProperties.user = removeCircularReferences(jsObject.user);
    }
    
    if (hasValue(jsObject.useStandardizedQuery)) {
        dotNetPortalProperties.useStandardizedQuery = removeCircularReferences(jsObject.useStandardizedQuery);
    }
    
    if (hasValue(jsObject.useVectorBasemaps)) {
        dotNetPortalProperties.useVectorBasemaps = removeCircularReferences(jsObject.useVectorBasemaps);
    }
    
    if (hasValue(jsObject.vectorBasemapGalleryGroupQuery)) {
        dotNetPortalProperties.vectorBasemapGalleryGroupQuery = removeCircularReferences(jsObject.vectorBasemapGalleryGroupQuery);
    }
    

    return dotNetPortalProperties;
}

