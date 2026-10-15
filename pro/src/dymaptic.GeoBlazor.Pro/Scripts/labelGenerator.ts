import {arcGisObjectRefs, hasValue} from './geoBlazorCore';
import * as binLabelGenerator from "@arcgis/core/smartMapping/labels/bins.js";
import * as clusterLabelGenerator from "@arcgis/core/smartMapping/labels/clusters.js";
import MapView from "@arcgis/core/views/MapView";
import { buildDotNetLabel } from "./label";

export default class LabelGeneratorWrapper {
    private dotNetRef: any;
    
    constructor(dotNetRef: any) {
        this.dotNetRef = dotNetRef;
    }
    
    async getBinLabelSchemes(params: any) {
        let { buildJsRenderer } = await import('./renderer');
        let jsParams: any = {};
        if (hasValue(params.layer) && arcGisObjectRefs.hasOwnProperty(params.layer.id)) {
            jsParams.layer = arcGisObjectRefs[params.layer.id] as any;
        }
        if (hasValue(params.renderer)) {
            jsParams.renderer = await buildJsRenderer(params.renderer, params.layer.id, params.viewId) ?? undefined;
        }
        if (hasValue(params.field)) {
            jsParams.field = params.field;
        }
        
        let results = await binLabelGenerator.getLabelSchemes(jsParams);
        let dnResult: any = {};
        
        if (hasValue(results?.primaryScheme)) {
            dnResult.primaryScheme = {};
            if (hasValue(results!.primaryScheme.fieldName)) {
                dnResult.primaryScheme.fieldName = results!.primaryScheme.fieldName;
            }
            if (hasValue(results!.primaryScheme.name)) {
                dnResult.primaryScheme.name = results!.primaryScheme.name;
            }
            if (hasValue(results!.primaryScheme.labelingInfo)) {
                dnResult.primaryScheme.labelingInfo = await Promise.all(results!.primaryScheme.labelingInfo.map(async (li) => await buildDotNetLabel(li, params.layer.viewId)));
            }
        }
        
        if (hasValue(results?.secondarySchemes)) {
            dnResult.secondarySchemes = [];
            for (let i = 0; i < results!.secondarySchemes.length; i++) {
                let secondaryScheme = results!.secondarySchemes[i];
                dnResult.secondarySchemes[i] = {};
                if (hasValue(secondaryScheme.fieldName)) {
                    dnResult.secondarySchemes[i].fieldName = secondaryScheme.fieldName;
                }
                if (hasValue(secondaryScheme.name)) {
                    dnResult.secondarySchemes[i].name = secondaryScheme.name;
                }
                if (hasValue(secondaryScheme.labelingInfo)) {
                    dnResult.secondarySchemes[i].labelingInfo = await Promise.all(secondaryScheme.labelingInfo.map(async (li) => await buildDotNetLabel(li, params.layer.viewId)));
                }
            }
        }
        return dnResult;
    }
    
    async getClusterLabelSchemes(params: any) {
        let { buildJsRenderer } = await import('./renderer');
        let jsParams: any = {};
        if (hasValue(params.layer) && arcGisObjectRefs.hasOwnProperty(params.layer.id)) {
            jsParams.layer = arcGisObjectRefs[params.layer.id] as any;
        }
        if (hasValue(params.viewId) && arcGisObjectRefs.hasOwnProperty(params.viewId)) {
            jsParams.view = arcGisObjectRefs[params.viewId] as MapView;
        }
        if (hasValue(params.renderer)) {
            jsParams.renderer = await buildJsRenderer(params.renderer, params.layer.id, params.viewId) ?? undefined;
        }
        if (hasValue(params.field)) {
            jsParams.field = params.field;
        }
        let results = await clusterLabelGenerator.getLabelSchemes(jsParams);
        let dnResult: any = {};
        
        if (hasValue(results?.primaryScheme)) {
            dnResult.primaryScheme = {};
            if (hasValue(results!.primaryScheme.fieldName)) {
                dnResult.primaryScheme.fieldName = results!.primaryScheme.fieldName;
            }
            if (hasValue(results!.primaryScheme.name)) {
                dnResult.primaryScheme.name = results!.primaryScheme.name;
            }
            if (hasValue(results!.primaryScheme.labelingInfo)) {
                dnResult.primaryScheme.labelingInfo = await Promise.all(results!.primaryScheme.labelingInfo.map(async (li) => await buildDotNetLabel(li, params.layer.viewId)));
            }
            if (hasValue(results!.primaryScheme.clusterMinSize)) {
                dnResult.primaryScheme.clusterMinSize = results!.primaryScheme.clusterMinSize;
            }
        }
        if (hasValue(results?.secondarySchemes)) {
            dnResult.secondarySchemes = [];
            for (let i = 0; i < results!.secondarySchemes.length; i++) {
                let secondaryScheme = results!.secondarySchemes[i];
                dnResult.secondarySchemes[i] = {};
                if (hasValue(secondaryScheme.fieldName)) {
                    dnResult.secondarySchemes[i].fieldName = secondaryScheme.fieldName;
                }
                if (hasValue(secondaryScheme.name)) {
                    dnResult.secondarySchemes[i].name = secondaryScheme.name;
                }
                if (hasValue(secondaryScheme.labelingInfo)) {
                    dnResult.secondarySchemes[i].labelingInfo = await Promise.all(secondaryScheme.labelingInfo.map(async (li) => await buildDotNetLabel(li, params.layer.viewId)));
                }
                if (hasValue(secondaryScheme.clusterMinSize)) {
                    dnResult.secondarySchemes[i].clusterMinSize = secondaryScheme.clusterMinSize;
                }
            }
        }
        
        return dnResult;
    }
}