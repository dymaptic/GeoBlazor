// override generated code in this file
import * as queryService from '@arcgis/core/rest/query';
import {buildJsStreamReference, hasValue, sanitize} from './geoBlazorCore';

export default class QueryServiceWrapper {
    private dotNetRef: any;
    
    constructor(dotNetRef: any) {
        this.dotNetRef = dotNetRef;
    }

    async executeAttachmentQuery(url: any,
                                 attachmentQuery: any,
                                 requestOptions: any): Promise<any> {
        
        let jsAttachmentQuery = sanitize(attachmentQuery);
        
        if (hasValue(requestOptions)) {
            return await queryService.executeAttachmentQuery(url,
                jsAttachmentQuery,
                requestOptions);
        }
        
        return await queryService.executeAttachmentQuery(url,
            jsAttachmentQuery);
    }

    async executeForCount(url: any,
                          query: any,
                          requestOptions: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query) as any;
        if (hasValue(requestOptions)) {
            return await queryService.executeForCount(url,
                jsQuery,
                requestOptions);
        }
        return await queryService.executeForCount(url,
            jsQuery);
    }

    async executeForExtent(url: any,
                           query: any,
                           requestOptions: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query) as any;
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeForExtent(url,
                jsQuery,
                requestOptions);
        } else {
            result = await queryService.executeForExtent(url,
                jsQuery);
        }

        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteForExtent',
            dnStream);
    }

    async executeForIds(url: any,
                        query: any,
                        requestOptions: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query) as any;
        if (hasValue(requestOptions)) {
            return await queryService.executeForIds(url,
                jsQuery,
                requestOptions);
        }
        
        return await queryService.executeForIds(url,
            jsQuery);
    }

    async executeForTopCount(url: any,
                             topFeaturesQuery: any,
                             requestOptions: any): Promise<any> {
        let { buildJsTopFeaturesQuery } = await import('./topFeaturesQuery');
        let jsTopFeaturesQuery = await buildJsTopFeaturesQuery(topFeaturesQuery, this.layerId, this.viewId) as any;
        
        if (hasValue(requestOptions)) {
            return await queryService.executeForTopCount(url,
                jsTopFeaturesQuery,
                requestOptions);
        }
        return await queryService.executeForTopCount(url,
            jsTopFeaturesQuery);
    }

    async executeForTopExtents(url: any,
                               topFeaturesQuery: any,
                               requestOptions: any): Promise<any> {
        let { buildJsTopFeaturesQuery } = await import('./topFeaturesQuery');
        let jsTopFeaturesQuery = await buildJsTopFeaturesQuery(topFeaturesQuery, this.layerId, this.viewId) as any;
        
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeForTopExtents(url,
                jsTopFeaturesQuery,
                requestOptions);
        } else {
            result = await queryService.executeForTopExtents(url,
                jsTopFeaturesQuery);
        }
        
        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteForTopExtents',
            dnStream);
    }

    async executeForTopIds(url: any,
                           topFeaturesQuery: any,
                           requestOptions: any): Promise<any> {
        let { buildJsTopFeaturesQuery } = await import('./topFeaturesQuery');
        let jsTopFeaturesQuery = await buildJsTopFeaturesQuery(topFeaturesQuery, this.layerId, this.viewId) as any;
        
        if (hasValue(requestOptions)) {
            return await queryService.executeForTopIds(url,
                jsTopFeaturesQuery,
                requestOptions);
        }
        return await queryService.executeForTopIds(url,
            jsTopFeaturesQuery);
    }

    async executeQueryJSON(url: any,
                           query: any,
                           requestOptions: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query) as any;
        
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeQueryJSON(url,
                jsQuery,
                requestOptions);
        } else {
            result = await queryService.executeQueryJSON(url,
                jsQuery);
        }

        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteQueryJSON',
            dnStream);
    }

    async executeQueryPBF(url: any,
                          query: any,
                          requestOptions: any): Promise<any> {
        let { buildJsQuery } = await import('./query');
        let jsQuery = await buildJsQuery(query) as any;
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeQueryPBF(url,
                jsQuery,
                requestOptions);
        } else {
            result = await queryService.executeQueryPBF(url,
                jsQuery);
        }
        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteQueryPBF',
            dnStream);
    }

    async executeRelationshipQuery(url: any,
                                   relationshipQuery: any,
                                   requestOptions: any): Promise<any> {
        let { buildJsRelationshipQuery } = await import('./relationshipQuery');
        let jsRelationshipQuery = await buildJsRelationshipQuery(relationshipQuery) as any;
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeRelationshipQuery(url,
                jsRelationshipQuery,
                requestOptions);
        } else {
            result = await queryService.executeRelationshipQuery(url,
                jsRelationshipQuery);
        }
        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteRelationshipQuery',
            dnStream);
    }

    async executeTopFeaturesQuery(url: any,
                                  topFeaturesQuery: any,
                                  outSpatialReference: any,
                                  requestOptions: any): Promise<any> {
        let { buildJsTopFeaturesQuery } = await import('./topFeaturesQuery');
        let jsTopFeaturesQuery = await buildJsTopFeaturesQuery(topFeaturesQuery, this.layerId, this.viewId) as any;
        let { buildJsSpatialReference } = await import('./spatialReference');
        let jsOutSpatialReference = buildJsSpatialReference(outSpatialReference) as any;
        let result: any;
        if (hasValue(requestOptions)) {
            result = await queryService.executeTopFeaturesQuery(url,
                jsTopFeaturesQuery,
                jsOutSpatialReference,
                requestOptions);
        } else {
            result = await queryService.executeTopFeaturesQuery(url,
                jsTopFeaturesQuery,
                jsOutSpatialReference);
        }
        let dnStream = buildJsStreamReference(result);
        await this.dotNetRef.invokeMethodAsync('OnExecuteTopFeaturesQuery',
            dnStream);
    }
}

export async function buildJsQueryService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // NOT USED
}

export async function buildDotNetQueryService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // NOT USED
}