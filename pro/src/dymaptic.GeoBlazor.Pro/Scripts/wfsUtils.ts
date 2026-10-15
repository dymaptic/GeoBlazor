import * as wfsUtils from "@arcgis/core/layers/ogc/wfsUtils";
import { buildJsStreamReference, hasValue } from './geoBlazorCore';
import WFSLayer from "@arcgis/core/layers/WFSLayer";

export default class WfsUtilsWrapper {
    private dotNetRef: any;
    private serverCapabilities: Record<string, __esri.WFSCapabilities> = {};
    private layerInfos: Record<string, __esri.WFSLayerInfo> = {};
    constructor(dotNetRef) {
        this.dotNetRef = dotNetRef;
    }
    
    // region methods
    async getCapabilities(url: any,
                          options: any): Promise<any> {
        let jsCapabilities = await wfsUtils.getCapabilities(url,
            options);
        this.serverCapabilities[url] = jsCapabilities;
        let dnFeatureTypes: any[] = [];
        let {buildDotNetWFSFeatureType} = await import('./wFSFeatureType');
        for (let i = 0; i < jsCapabilities.featureTypes.length; i++) {
            let featureType = jsCapabilities.featureTypes[i];
            let dnFeatureType: any = await buildDotNetWFSFeatureType(featureType);
            dnFeatureTypes.push(dnFeatureType);
        }
        let { buildDotNetWFSOperations } = await import('./wFSOperations');
        let dnOperations = await buildDotNetWFSOperations(jsCapabilities.operations);
        let dnCapabilities = {
            featureTypes: dnFeatureTypes,
            operations: dnOperations,
            url: url
        };
        let dnStream = buildJsStreamReference(dnCapabilities);
        await this.dotNetRef.invokeMethodAsync('OnGetCapabilities',
            dnStream);
    }

    async getWFSLayerInfo(url: any,
                          name: any,
                          namespaceUri: any,
                          options: any): Promise<any> {
        let jsCapabilities: __esri.WFSCapabilities;
        
        if (this.serverCapabilities.hasOwnProperty(url)) {
           jsCapabilities = this.serverCapabilities[url];
        } else {
            return null;
        }
        
        let layerInfo = await wfsUtils.getWFSLayerInfo(jsCapabilities,
            name,
            namespaceUri ?? undefined,
            options ?? undefined);
        
        this.layerInfos[layerInfo.name] = layerInfo;
        
        let { buildDotNetWFSLayerInfo } = await import('./wFSLayerInfo');
        return await buildDotNetWFSLayerInfo(layerInfo);
    }
    
    async getLayerFromLayerInfo(layerInfo: any) {
        let jsLayerInfo: __esri.WFSLayerInfo;
        if (this.layerInfos.hasOwnProperty(layerInfo.name)) {
            jsLayerInfo = this.layerInfos[layerInfo.name];
        } else {
            return null;
        }
        if (!hasValue(jsLayerInfo)) {
            let { buildJsWFSLayerInfo } = await import('./wFSLayerInfo');
            jsLayerInfo = await buildJsWFSLayerInfo(layerInfo) as any;
        }
        
        let jsLayer = WFSLayer.fromWFSLayerInfo(jsLayerInfo);
        let { buildDotNetWFSLayer } = await import('./wFSLayer');
        return await buildDotNetWFSLayer(jsLayer);
    }
}

export async function buildJsWfsUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // NOT USED
}     

export async function buildDotNetWfsUtils(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // NOT USED
}
