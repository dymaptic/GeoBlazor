import PieChartGeneratorGenerated from './pieChartGenerator.gb';
import * as pieChart from "@arcgis/core/smartMapping/renderers/pieChart";
import {arcGisObjectRefs, copyValuesIfExists, hasValue} from './geoBlazorCore';


export default class PieChartGeneratorWrapper extends PieChartGeneratorGenerated {
    constructor(dotNetRef) {
        super(pieChart);
    }
    
    async createRenderer(options: any): Promise<any> {
        let jsResult = await pieChart.createRenderer({
            layer: arcGisObjectRefs[options.layer.id] as any,
            view: arcGisObjectRefs[options.viewId] as any,
            attributes: options.attributes,
            shape: options.shape,
            includeSizeVariable: options.includeSizeVariable,
            outlineOptimizationEnabled: options.outlineOptimizationEnabled,
            legendOptions: options.legendOptions,
            pieChartScheme: options.pieChartScheme,
            forBinning: options.forBinning
        });
        let dnResult: any = {};
        let { buildDotNetRenderer } = await import('./renderer');
        dnResult.renderer = await buildDotNetRenderer(jsResult.renderer);
        dnResult.size = await this.buildDotNetSizeVisualVariableResult(jsResult.size);
        dnResult.pieChartScheme = this.buildDotNetPieChartScheme(jsResult.pieChartScheme);
        copyValuesIfExists(jsResult, dnResult, 'basemapId', 'basemapTheme', 'statistics');
        return dnResult;
    }

    async createRendererForClustering(options: any): Promise<any> {
        let jsRenderer = await pieChart.createRendererForClustering({
            layer: arcGisObjectRefs[options.layer.id] as any,
            shape: options.shape,
            defaultSymbolEnabled: options.defaultSymbolEnabled,
            legendOptions: options.legendOptions
        });
        let { buildDotNetRenderer } = await import('./renderer');
        let dnResult: any = {
            renderer: await buildDotNetRenderer(jsRenderer.renderer)
        };
        if (hasValue(jsRenderer.fields)) {
            dnResult.fields = jsRenderer.fields;
        }
        
        return dnResult;
    }

    async buildDotNetSizeVisualVariableResult(jsResult: any): Promise<any> {
        let dnResult: any = {};
        if (hasValue(jsResult.visualVariables) && jsResult.visualVariables.length > 0) {
            dnResult.visualVariables = jsResult.visualVariables.map(this.buildDotNetSizeVariable);
        }
        if (hasValue(jsResult.sizeScheme)) {
            dnResult.sizeScheme = this.buildDotNetSizeScheme(jsResult.sizeScheme);
        }
        if (hasValue(jsResult.authoringInfo)) {
            let { buildDotNetAuthoringInfo } = await import('./authoringInfo');
            dnResult.authoringInfo = await buildDotNetAuthoringInfo(jsResult.authoringInfo);
        }
        copyValuesIfExists(jsResult, dnResult, 'defaultValuesUsed', 'basemapId', 'basemapTheme', 'statistics');
        return dnResult;
    }

    buildDotNetSizeVariable(jsSizeVariable: any): any {
        let dnSizeVariable: any = {};
        copyValuesIfExists(jsSizeVariable, dnSizeVariable, 'axis', 'field', 'legendOptions', 'maxDataValue',
            'maxSize', 'minDataValue', 'minSize', 'normalizationField', 'stops', 'target', 'type', 'useSymbolValue',
            'valueExpression', 'valueExpressionTitle', 'valueRepresentation', 'valueUnit');
        return dnSizeVariable;
    }

    buildDotNetSizeScheme(jsSizeScheme): any {
        let dnSizeScheme: any = {};
        copyValuesIfExists(jsSizeScheme, dnSizeScheme, 'size', 'noDataSize', 'minSize', 'maxSize', 'opacity',
            'width', 'noDataWidth', 'minWidth', 'maxWidth');
        this.copyColorIfExists(jsSizeScheme, dnSizeScheme, 'color', 'noDataColor');
        if (jsSizeScheme.hasOwnProperty('outline')) {
            dnSizeScheme.outline = {
                color: jsSizeScheme.outline.color.toHex(),
                width: jsSizeScheme.outline.width
            };
        }
        if (jsSizeScheme.hasOwnProperty('background')) {
            dnSizeScheme.background = {
                color: jsSizeScheme.background.color.toHex(),
                outline: {
                    color: jsSizeScheme.background.outline.color.toHex(),
                    width: jsSizeScheme.background.outline.width
                }
            }
        }

        return dnSizeScheme;
    }

    copyColorIfExists(jsObject: any, dnObject: any, ...params: Array<string>) {
        params.forEach(p => {
            if (hasValue(jsObject[p]) && jsObject[p] !== dnObject[p]) {
                dnObject[p] = jsObject[p].toHex();
            }
        });
    }

    buildDotNetPieChartScheme(jsPieChartScheme): any {
        let dnPieChartScheme: any = {};
        copyValuesIfExists(jsPieChartScheme, dnPieChartScheme, 'name', 'tags', 'size');
        if (hasValue(jsPieChartScheme.colorForOthersCategory)) {
            dnPieChartScheme.colorForOthersCategory = jsPieChartScheme.colorForOthersCategory.toHex();
        }
        if (hasValue(jsPieChartScheme.colors) && jsPieChartScheme.colors.length > 0) {
            dnPieChartScheme.colors = jsPieChartScheme.colors.map(c => c.toHex());
        }
        if (hasValue(jsPieChartScheme.outline)) {
            dnPieChartScheme.outline = {
                color: jsPieChartScheme.outline.color.toHex(),
                width: jsPieChartScheme.outline.width
            };
        }
        if (hasValue(jsPieChartScheme.sizeScheme)) {
            dnPieChartScheme.sizeScheme = this.buildDotNetSizeScheme(jsPieChartScheme.sizeScheme);
        }

        return dnPieChartScheme;
    }
}
export async function buildJsPieChartGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartGeneratorGenerated } = await import('./pieChartGenerator.gb');
    return await buildJsPieChartGeneratorGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPieChartGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPieChartGeneratorGenerated } = await import('./pieChartGenerator.gb');
    return await buildDotNetPieChartGeneratorGenerated(jsObject, layerId, viewId);
}
