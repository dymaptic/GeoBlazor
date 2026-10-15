import {copyValuesIfExists, hasValue, sanitize} from './geoBlazorCore';
import { buildJsPopupTemplate } from "./popupTemplate";
import {buildJsSymbol} from "./symbol";
import FeatureReductionCluster from "@arcgis/core/layers/support/FeatureReductionCluster";
import FeatureReductionBinning from "@arcgis/core/layers/support/FeatureReductionBinning";

export async function buildJsFeatureReduction(dnFeatureReduction: any, layerId: string | null, viewId: string | null) : Promise<any> {
    if (!hasValue(dnFeatureReduction)) return null;
    switch (dnFeatureReduction.type) {
        case 'cluster':
            let { default: FeatureReductionCluster } = await import('@arcgis/core/layers/support/FeatureReductionCluster');
            let cluster = new FeatureReductionCluster();
            if (hasValue(dnFeatureReduction.fields) && dnFeatureReduction.fields.length > 0) {
                cluster.fields = dnFeatureReduction.fields.map(f => sanitize(f));
            }
            if (hasValue(dnFeatureReduction.labelingInfo) && dnFeatureReduction.labelingInfo.length > 0) {
                let { buildJsLabel } = await import('./label');
                cluster.labelingInfo = await Promise.all(dnFeatureReduction.labelingInfo.map(async l => await buildJsLabel(l, layerId, viewId)));
            }
            if (hasValue(dnFeatureReduction.popupTemplate)) {
                cluster.popupTemplate = await buildJsPopupTemplate(dnFeatureReduction.popupTemplate, layerId, viewId);
            }
            if (hasValue(dnFeatureReduction.renderer)) {
                let { buildJsRenderer } = await import('./renderer');
                cluster.renderer = await buildJsRenderer(dnFeatureReduction.renderer, layerId, viewId);
            }
            if (hasValue(dnFeatureReduction.symbol)) {
                cluster.symbol = await buildJsSymbol(dnFeatureReduction.symbol) as any;
            }
            copyValuesIfExists(dnFeatureReduction, cluster, 'clusterMaxSize', 'clusterMinSize', 'clusterRadius',
                'labelsVisible', 'maxScale', 'popupEnabled');
            return cluster;
        case 'binning':
            let { default: FeatureReductionBinning } = await import('@arcgis/core/layers/support/FeatureReductionBinning');
            let binning = new FeatureReductionBinning();
            if (hasValue(dnFeatureReduction.fields) && dnFeatureReduction.fields.length > 0) {
                binning.fields = dnFeatureReduction.fields.map(f => sanitize(f));
            }
            if (hasValue(dnFeatureReduction.labelingInfo) && dnFeatureReduction.labelingInfo.length > 0) {
                let { buildJsLabel } = await import('./label');
                binning.labelingInfo = await Promise.all(dnFeatureReduction.labelingInfo.map(async l => await buildJsLabel(l, layerId, viewId)));
            }
            if (hasValue(dnFeatureReduction.popupTemplate)) {
                binning.popupTemplate = await buildJsPopupTemplate(dnFeatureReduction.popupTemplate, layerId, viewId);
            }
            if (hasValue(dnFeatureReduction.renderer)) {
                let { buildJsRenderer } = await import('./renderer');
                binning.renderer = await buildJsRenderer(dnFeatureReduction.renderer, layerId, viewId);
            }
            copyValuesIfExists(dnFeatureReduction, binning, 'fixedBinLevel', 'labelsVisible', 'maxScale', 'popupEnabled');
            return binning;
        case 'selection':
            let { default: FeatureReductionSelection } = await import('@arcgis/core/layers/support/FeatureReductionSelection');
            return new FeatureReductionSelection();
    }
}

export async function buildDotNetFeatureReduction(jsObject: any, viewId: string | null) {
    if (jsObject instanceof FeatureReductionCluster) {
        let { buildDotNetFeatureReductionCluster } = await import('./featureReductionCluster');
        return await buildDotNetFeatureReductionCluster(jsObject, viewId);
    } else if (jsObject instanceof FeatureReductionBinning) {
        let { buildDotNetFeatureReductionBinning } = await import('./featureReductionBinning');
        return await buildDotNetFeatureReductionBinning(jsObject, viewId);
    }
    
    return null;
}