// noinspection JSUnusedGlobalSymbols

// region imports
import "@arcgis/map-components/components/arcgis-feature-table";
import * as Core from './geoBlazorCore';
import ArcGisRestWrapper from "./arcGisRest";
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import LabelGeneratorWrapper from "./labelGenerator";
import NetworkServiceWrapper from "./networkService";
import PieChartGeneratorWrapper from "./pieChartGenerator";
import PopupTemplateGeneratorWrapper from "./popupTemplateGenerator";
import RouteWrapper from "./route";

// region functions

export async function getCore(): Promise<any> {
    // @ts-ignore We know this is a module
    await Core.setPro(this);
    return Core;
}


export async function getArcGisRestWrapper(dotNetRef: any): Promise<ArcGisRestWrapper> {
    if (Core.ProtoGraphicCollection === undefined) {
        await Core.loadProtobuf();
    }
    return new ArcGisRestWrapper(dotNetRef);
}

export function getPopupTemplateGeneratorWrapper(dotNetRef: any): any {
    return new PopupTemplateGeneratorWrapper(dotNetRef);
}

export function getLabelGeneratorWrapper(dotNetRef: any): any {
    return new LabelGeneratorWrapper(dotNetRef);
}

export function getPieChartGeneratorWrapper(dotNetRef: any): any {
    return new PieChartGeneratorWrapper(dotNetRef);
}

export async function getNetworkServiceWrapper(dotNetRef: any): Promise<NetworkServiceWrapper> {
    if (Core.ProtoGraphicCollection === undefined) {
        await Core.loadProtobuf();
    }
    return new NetworkServiceWrapper(dotNetRef);
}

export async function getRouteServiceWrapper(dotNetRef: any): Promise<RouteWrapper> {
    if (Core.ProtoGraphicCollection === undefined) {
        await Core.loadProtobuf();
    }
    return new RouteWrapper(dotNetRef);
}

export async function getWfsUtilsWrapper(dotNetRef: any): Promise<any> {
    let {default: WfsUtilsWrapper } = await import('./wfsUtils');
    return new WfsUtilsWrapper(dotNetRef);
}

export async function getQueryServiceWrapper(dotNetRef: any): Promise<any> {
    let {default: QueryServiceWrapper} = await import('./queryService');
    return new QueryServiceWrapper(dotNetRef);
}

export async function getMultiPartToSinglePartOperatorWrapper(dotNetRef: any): Promise<any> {
    let {default: MultiPartToSinglePartOperatorWrapper} = await import('./multiPartToSinglePartOperator');
    return new MultiPartToSinglePartOperatorWrapper(dotNetRef);
}

export async function setFeatureReduction(featureReduction: any, layerId: string, viewId: string) {
    let layer = Core.arcGisObjectRefs[layerId] as FeatureLayer;
    if (layer === undefined || layer === null) return;
    let { buildJsFeatureReduction } = await import('./featureReduction');
    layer.featureReduction = await buildJsFeatureReduction(featureReduction, layerId, viewId);
}

export async function fetchSymbolFromWebStyleSymbol(webStyleSymbolId: string, viewId: string | null, options: any): Promise<any> {
    if (!Core.hasValue(webStyleSymbolId) || !Core.arcGisObjectRefs.hasOwnProperty(webStyleSymbolId)) {
        return null;
    }
    
    let webStyleSymbol = Core.arcGisObjectRefs[webStyleSymbolId];

    let jsSymbol = await webStyleSymbol.fetchSymbol(options);
    if (!Core.hasValue(jsSymbol)) {
        return null;
    }
    
    let { buildDotNetSymbol } = await import('./symbol');
    return await buildDotNetSymbol(jsSymbol, viewId);
}
