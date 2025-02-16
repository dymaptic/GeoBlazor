// region imports

import Graphic from "@arcgis/core/Graphic";
import {
    arcGisObjectRefs,
    createLayer,
    copyValuesIfExists
} from "./arcGisJsInterop";
import Geometry from "@arcgis/core/geometry/Geometry";
import Point from "@arcgis/core/geometry/Point";
import Field from "@arcgis/core/layers/support/Field";
import Font from "@arcgis/core/symbols/Font";
import FeatureEffect from "@arcgis/core/layers/support/FeatureEffect";
import FeatureFilter from "@arcgis/core/layers/support/FeatureFilter";
import {
    DotNetBarChartMediaInfo,
    DotNetChartMediaInfoValue,
    DotNetColumnChartMediaInfo,
    DotNetElementExpressionInfo,
    DotNetFeatureEffect,
    DotNetFeatureFilter,
    DotNetImageMediaInfo,
    DotNetImageMediaInfoValue,
    DotNetLineChartMediaInfo,
    DotNetMediaInfo,
    DotNetPieChartMediaInfo,
    DotNetQuery,
    DotNetRelationshipQuery,
    DotNetTopFeaturesQuery,
    
     
} from "./definitions";
import Popup from "@arcgis/core/widgets/Popup";
import Query from "@arcgis/core/rest/support/Query";
import BarChartMediaInfo from "@arcgis/core/popup/content/BarChartMediaInfo";
import ColumnChartMediaInfo from "@arcgis/core/popup/content/ColumnChartMediaInfo";
import ChartMediaInfoValue from "@arcgis/core/popup/content/support/ChartMediaInfoValue";
import ImageMediaInfoValue from "@arcgis/core/popup/content/support/ImageMediaInfoValue";
import ImageMediaInfo from "@arcgis/core/popup/content/ImageMediaInfo";
import LineChartMediaInfo from "@arcgis/core/popup/content/LineChartMediaInfo";
import PieChartMediaInfo from "@arcgis/core/popup/content/PieChartMediaInfo";
import Layer from "@arcgis/core/layers/Layer";
import RelationshipQuery from "@arcgis/core/rest/support/RelationshipQuery";
import TopFeaturesQuery from "@arcgis/core/rest/support/TopFeaturesQuery";
import ElementExpressionInfo from "@arcgis/core/popup/ElementExpressionInfo";
import ChartMediaInfoValueSeries from "@arcgis/core/popup/content/support/ChartMediaInfoValueSeries";
import FormTemplate from "@arcgis/core/form/FormTemplate";
import Element from "@arcgis/core/form/elements/Element";
import GroupElement from "@arcgis/core/form/elements/GroupElement";
import CodedValueDomain from "@arcgis/core/layers/support/CodedValueDomain";
import RangeDomain from "@arcgis/core/layers/support/RangeDomain";
import TextBoxInput from "@arcgis/core/form/elements/inputs/TextBoxInput";
import TextAreaInput from "@arcgis/core/form/elements/inputs/TextAreaInput";
import DateTimePickerInput from "@arcgis/core/form/elements/inputs/DateTimePickerInput";
import BarcodeScannerInput from "@arcgis/core/form/elements/inputs/BarcodeScannerInput";
import ComboBoxInput from "@arcgis/core/form/elements/inputs/ComboBoxInput";
import RadioButtonsInput from "@arcgis/core/form/elements/inputs/RadioButtonsInput";
import SwitchInput from "@arcgis/core/form/elements/inputs/SwitchInput";
import SearchSource from "@arcgis/core/widgets/Search/SearchSource";
import ViewClickEvent = __esri.ViewClickEvent;
import PopupOpenOptions = __esri.PopupOpenOptions;
import PopupDockOptions = __esri.PopupDockOptions;




import SearchSourceFilter = __esri.SearchSourceFilter;
import SearchResult = __esri.SearchResult;
import SuggestResult = __esri.SuggestResult;
import AggregateField from "@arcgis/core/layers/support/AggregateField";
import supportExpressionInfo from "@arcgis/core/layers/support/ExpressionInfo";
import MapView from "@arcgis/core/views/MapView";
import {buildJsExtent} from "./extent";
import { buildJsGraphic } from "./graphic";
import { buildDotNetPoint } from "./point";
import { buildDotNetSpatialReference } from "./spatialReference";




export function buildJsDockOptions(dotNetDockOptions: any): PopupDockOptions {
    let dockOptions: PopupDockOptions = {
        buttonEnabled: dotNetDockOptions.buttonEnabled ?? undefined,
        position: dotNetDockOptions.position ?? undefined,
        breakpoint: dotNetDockOptions.breakPoint ?? true
    };

    return dockOptions as PopupDockOptions;
}

export async function buildJsPopupOptions(dotNetPopupOptions: any): Promise<PopupOpenOptions> {
    let options: PopupOpenOptions = {};

    if (hasValue(dotNetPopupOptions.title)) {
        options.title = dotNetPopupOptions.title;
    }
    if (hasValue(dotNetPopupOptions.stringContent)) {
        options.content = dotNetPopupOptions.content;
    }
    if (hasValue(dotNetPopupOptions.fetchFeatures)) {
        options.fetchFeatures = dotNetPopupOptions.fetchFeatures;
    }

    if (hasValue(dotNetPopupOptions.featureMenuOpen)) {
        options.featureMenuOpen = dotNetPopupOptions.featureMenuOpen;
    }

    if (hasValue(dotNetPopupOptions.updateLocationEnabled)) {
        options.updateLocationEnabled = dotNetPopupOptions.updateLocationEnabled;
    }

    if (hasValue(dotNetPopupOptions.collapsed)) {
        options.collapsed = dotNetPopupOptions.collapsed;
    }

    if (hasValue(dotNetPopupOptions.shouldFocus)) {
        options.shouldFocus = dotNetPopupOptions.shouldFocus;
    }

    if (hasValue(dotNetPopupOptions.location)) {
        options.location = buildJsPoint(dotNetPopupOptions.location) as Point;
    }

    if (hasValue(dotNetPopupOptions.features)) {
        let features: Graphic[] = [];
        for (const f of dotNetPopupOptions.features) {
            let graphic = buildJsGraphic(f, f.layerId, null) as Graphic;
            graphic.layer = arcGisObjectRefs[f.layerId] as Layer;
            features.push(graphic);
        }
        options.features = features;
    }

    return options;
}

export function buildJsMapFont(dotNetFont: any): Font {
    let font = new Font();
    font.size = dotNetFont.size ?? 9;
    font.family = dotNetFont.family ?? "sans-serif";
    font.style = dotNetFont.style ?? "normal";
    font.weight = dotNetFont.weight ?? "normal";
    
    copyValuesIfExists(dotNetFont, font, 'decoration');

    return font;
}

export function buildJsQuery(dotNetQuery: DotNetQuery): Query {
    let query: any = new Query({
        where: dotNetQuery.where ?? "1=1",
        spatialRelationship: dotNetQuery.spatialRelationship as any ?? "intersects",
        distance: dotNetQuery.distance ?? undefined,
        units: dotNetQuery.units as any ?? undefined,
        returnGeometry: dotNetQuery.returnGeometry ?? false,
        outFields: dotNetQuery.outFields ?? undefined,
        orderByFields: dotNetQuery.orderByFields ?? undefined,
        outStatistics: dotNetQuery.outStatistics ?? undefined,
        groupByFieldsForStatistics: dotNetQuery.groupByFieldsForStatistics ?? undefined,
        returnDistinctValues: dotNetQuery.returnDistinctValues ?? false,
        returnZ: dotNetQuery.returnZ ?? undefined,
        returnExceededLimitFeatures: dotNetQuery.returnExceededLimitFeatures ?? true,
        num: dotNetQuery.num ?? undefined,
        objectIds: dotNetQuery.objectIds ?? undefined,
        timeExtent: dotNetQuery.timeExtent ?? undefined,
        maxAllowableOffset: dotNetQuery.maxAllowableOffset ?? undefined,
        geometryPrecision: dotNetQuery.geometryPrecision ?? undefined,
        aggregateIds: dotNetQuery.aggregateIds ?? undefined,
        cacheHint: dotNetQuery.cacheHint ?? undefined,
        datumTransformation: dotNetQuery.datumTransformation ?? undefined,
        gdbVersion: dotNetQuery.gdbVersion ?? undefined,
        having: dotNetQuery.having ?? undefined,
        historicMoment: dotNetQuery.historicMoment ?? undefined,
        maxRecordCountFactor: dotNetQuery.maxRecordCountFactor ?? 1,
        text: dotNetQuery.text ?? undefined,
        parameterValues: dotNetQuery.parameterValues ?? undefined,
        quantizationParameters: dotNetQuery.quantizationParameters ?? undefined,
        rangeValues: dotNetQuery.rangeValues ?? undefined,
        relationParameter: dotNetQuery.relationParameter ?? undefined,
        returnCentroid: dotNetQuery.returnCentroid ?? false,
        returnM: dotNetQuery.returnM ?? undefined,
        returnQueryGeometry: dotNetQuery.returnQueryGeometry ?? false,
        sqlFormat: dotNetQuery.sqlFormat as any ?? "none",
        start: dotNetQuery.start ?? undefined
    });

    if (hasValue(dotNetQuery.geometry)) {
        query.geometry = buildJsGeometry(dotNetQuery.geometry) as Geometry;
    }

    if (hasValue(dotNetQuery.outSpatialReference)) {
        query.outSpatialReference = buildJsSpatialReference(dotNetQuery.outSpatialReference);
    }

    return query as Query;
}

export function buildJsRelationshipQuery(dotNetRelationshipQuery: DotNetRelationshipQuery): RelationshipQuery {
    // copy all values from the dotnet object to the js object
    let relationshipQuery = new RelationshipQuery({
        cacheHint: dotNetRelationshipQuery.cacheHint ?? undefined,
        gdbVersion: dotNetRelationshipQuery.gdbVersion ?? undefined,
        geometryPrecision: dotNetRelationshipQuery.geometryPrecision ?? undefined,
        historicMoment: dotNetRelationshipQuery.historicMoment ?? undefined,
        maxAllowableOffset: dotNetRelationshipQuery.maxAllowableOffset ?? undefined,
        num: dotNetRelationshipQuery.num ?? undefined,
        objectIds: dotNetRelationshipQuery.objectIds ?? undefined,
        orderByFields: dotNetRelationshipQuery.orderByFields ?? undefined,
        outFields: dotNetRelationshipQuery.outFields ?? undefined,
        returnGeometry: dotNetRelationshipQuery.returnGeometry ?? undefined,
        returnM: dotNetRelationshipQuery.returnM ?? undefined,
        returnZ: dotNetRelationshipQuery.returnZ ?? undefined,
        start: dotNetRelationshipQuery.start ?? undefined,
        where: dotNetRelationshipQuery.where ?? undefined
    });

    if (hasValue(dotNetRelationshipQuery.outSpatialReference)) {
        relationshipQuery.outSpatialReference = buildJsSpatialReference(dotNetRelationshipQuery.outSpatialReference);
    }

    return relationshipQuery as RelationshipQuery;
}

export function buildJsTopFeaturesQuery(dnQuery: DotNetTopFeaturesQuery): TopFeaturesQuery {
    let query = new TopFeaturesQuery({
        cacheHint: dnQuery.cacheHint ?? undefined,
        distance: dnQuery.distance ?? undefined,
        geometryPrecision: dnQuery.geometryPrecision ?? undefined,
        maxAllowableOffset: dnQuery.maxAllowableOffset ?? undefined,
        num: dnQuery.num ?? undefined,
        objectIds: dnQuery.objectIds ?? undefined,
        orderByFields: dnQuery.orderByFields ?? undefined,
        outFields: dnQuery.outFields ?? null,
        returnGeometry: dnQuery.returnGeometry ?? false,
        returnM: dnQuery.returnM ?? undefined,
        returnZ: dnQuery.returnZ ?? undefined,
        spatialRelationship: dnQuery.spatialRelationship as any ?? "intersects",
        start: dnQuery.start ?? undefined,
        timeExtent: dnQuery.timeExtent ?? undefined,
        topFilter: dnQuery.topFilter as any ?? undefined,
        units: dnQuery.units as any ?? null
    });

    if (hasValue(dnQuery.where)) {
        query.where = dnQuery.where;
    }

    if (hasValue(dnQuery.geometry)) {
        query.geometry = buildJsGeometry(dnQuery.geometry) as Geometry;
    }

    if (hasValue(dnQuery.outSpatialReference)) {
        query.outSpatialReference = buildJsSpatialReference(dnQuery.outSpatialReference);
    }

    return query as TopFeaturesQuery;
}

export function buildJsMediaInfo(dotNetMediaInfo: DotNetMediaInfo): any {
    switch (dotNetMediaInfo?.type) {
        case "bar-chart":
            let dotNetBarChartMediaInfo = dotNetMediaInfo as DotNetBarChartMediaInfo;
            return {
                type: "bar-chart",
                altText: dotNetBarChartMediaInfo.altText ?? undefined,
                caption: dotNetBarChartMediaInfo.caption ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetBarChartMediaInfo.value)
            } as BarChartMediaInfo;
        case "column-chart":
            let dotNetColumnChartMediaInfo = dotNetMediaInfo as DotNetColumnChartMediaInfo;
            return {
                type: "column-chart",
                altText: dotNetColumnChartMediaInfo.altText ?? undefined,
                caption: dotNetColumnChartMediaInfo.caption ?? undefined,
                title: dotNetColumnChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetColumnChartMediaInfo.value)
            } as ColumnChartMediaInfo;
        case "image":
            let dotNetImageMediaInfo = dotNetMediaInfo as DotNetImageMediaInfo;
            return {
                type: "image",
                altText: dotNetImageMediaInfo.altText ?? undefined,
                caption: dotNetImageMediaInfo.caption ?? undefined,
                title: dotNetImageMediaInfo.title ?? undefined,
                refreshInterval: dotNetImageMediaInfo.refreshInterval ?? undefined,
                value: buildJsImageMediaInfoValue(dotNetImageMediaInfo.value)
            } as ImageMediaInfo;
        case "line-chart":
            let dotNetLineChartMediaInfo = dotNetMediaInfo as DotNetLineChartMediaInfo;
            return {
                type: "line-chart",
                altText: dotNetLineChartMediaInfo.altText ?? undefined,
                caption: dotNetLineChartMediaInfo.caption ?? undefined,
                title: dotNetLineChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetLineChartMediaInfo.value)
            } as LineChartMediaInfo;
        case "pie-chart":
            let dotNetPieChartMediaInfo = dotNetMediaInfo as DotNetPieChartMediaInfo;
            return {
                type: "pie-chart",
                altText: dotNetPieChartMediaInfo.altText ?? undefined,
                caption: dotNetPieChartMediaInfo.caption ?? undefined,
                title: dotNetPieChartMediaInfo.title ?? undefined,
                value: buildJsChartMediaInfoValue(dotNetPieChartMediaInfo.value)
            } as PieChartMediaInfo;
    }
}

export function buildJsChartMediaInfoValue(dotNetChartMediaInfoValue: DotNetChartMediaInfoValue): ChartMediaInfoValue {
    let value = new ChartMediaInfoValue({
        fields: dotNetChartMediaInfoValue?.fields ?? undefined,
        normalizeField: dotNetChartMediaInfoValue?.normalizeField ?? undefined,
        tooltipField: dotNetChartMediaInfoValue?.tooltipField ?? undefined
    });

    if (hasValue(dotNetChartMediaInfoValue?.series)) {
        value.series = dotNetChartMediaInfoValue.series.map(s => {
            let series = new ChartMediaInfoValueSeries({
                tooltip: s.tooltip ?? undefined,
                value: s.value ?? undefined,
                fieldName: s.fieldName ?? undefined
            });
            return series;
        });
    }
    return value;
}

export function buildJsImageMediaInfoValue(dotNetImageMediaInfoValue: DotNetImageMediaInfoValue): ImageMediaInfoValue {
    return {
        sourceURL: dotNetImageMediaInfoValue.sourceURL ?? undefined,
        linkURL: dotNetImageMediaInfoValue.linkURL ?? undefined
    } as ImageMediaInfoValue;
}

export function buildJsElementExpressionInfo(dotNetExpressionInfo: DotNetElementExpressionInfo): ElementExpressionInfo {
    let info = new ElementExpressionInfo({
        expression: dotNetExpressionInfo.expression ?? undefined,
        title: dotNetExpressionInfo.title ?? undefined
    });

    return info;
}

export function buildJsFormTemplate(dotNetFormTemplate: any): FormTemplate {
    let formTemplate = new FormTemplate({
        title: dotNetFormTemplate.title ?? undefined,
        description: dotNetFormTemplate.description ?? undefined,
        preserveFieldValuesWhenHidden: dotNetFormTemplate.preserveFieldValuesWhenHidden ?? undefined
    });
    if (hasValue(dotNetFormTemplate?.elements)) {
        formTemplate.elements = dotNetFormTemplate.elements.map(buildJsFormTemplateElement);
    }
    if (hasValue(dotNetFormTemplate.expressionInfos)) {
        formTemplate.expressionInfos = dotNetFormTemplate.expressionInfos.map(buildJsExpressionInfo);
    }
    return formTemplate;
}

export function buildJsTimeSliderStops(dotNetStop: any): any | null {
    if (dotNetStop === null) return null;
    switch (dotNetStop.type) {
        case "stops-by-dates":
            return {
                dates: dotNetStop.dates,
            }
        case "stops-by-count":
            return {
                count: dotNetStop.count,
                timeExtent: dotNetStop.timeExtent ?? undefined,
            }
        case "stops-by-interval":
            return {
                interval: dotNetStop.interval,
                timeExtent: dotNetStop.timeExtent ?? undefined,
            }
    }
    return null;
}

export function buildJsFormTemplateElement(dotNetFormTemplateElement: any): Element {
    switch (dotNetFormTemplateElement.type) {
        case 'group':
            return new GroupElement({
                label: dotNetFormTemplateElement.label ?? undefined,
                description: dotNetFormTemplateElement.description ?? undefined,
                elements: dotNetFormTemplateElement.elements?.map(e => buildJsFormTemplateElement(e)) ?? []
            });
    }
    let fieldElement: any = {
        type: 'field'
    };
    if (hasValue(dotNetFormTemplateElement.description)) {
        fieldElement.description = dotNetFormTemplateElement.description;
    }
    if (hasValue(dotNetFormTemplateElement.label)) {
        fieldElement.label = dotNetFormTemplateElement.label;
    }
    if (hasValue(dotNetFormTemplateElement.visibilityExpression)) {
        fieldElement.visibilityExpression = dotNetFormTemplateElement.visibilityExpression;
    }
    if (hasValue(dotNetFormTemplateElement.editableExpression)) {
        fieldElement.editableExpression = dotNetFormTemplateElement.editableExpression;
    }
    if (hasValue(dotNetFormTemplateElement.requiredExpression)) {
        fieldElement.requiredExpression = dotNetFormTemplateElement.requiredExpression;
    }
    if (hasValue(dotNetFormTemplateElement.fieldName)) {
        fieldElement.fieldName = dotNetFormTemplateElement.fieldName;
    }
    if (hasValue(dotNetFormTemplateElement.hint)) {
        fieldElement.hint = dotNetFormTemplateElement.hint;
    }
    if (hasValue(dotNetFormTemplateElement.valueExpression)) {
        fieldElement.valueExpression = dotNetFormTemplateElement.valueExpression;
    }
    if (hasValue(dotNetFormTemplateElement?.domain)) {
        fieldElement.domain = buildJsDomain(dotNetFormTemplateElement.domain);
    }
    if (hasValue(dotNetFormTemplateElement?.input)) {
        fieldElement.input = buildJsFormInput(dotNetFormTemplateElement.input);
    }
    return fieldElement;
}

export function buildJsFormInput(dotNetFormInput: any): any {
    switch (dotNetFormInput?.type) {
        case 'text-box':
            return new TextBoxInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'text-area':
            return new TextAreaInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'datetime-picker':
            return new DateTimePickerInput({
                includeTime: dotNetFormInput.includeTime ?? undefined,
                max: dotNetFormInput.max ?? undefined,
                min: dotNetFormInput.min ?? undefined
            });
        case 'barcode-scanner':
            return new BarcodeScannerInput({
                maxLength: dotNetFormInput.maxLength ?? undefined,
                minLength: dotNetFormInput.minLength ?? undefined
            });
        case 'combo-box':
            return new ComboBoxInput({
                noValueOptionLabel: dotNetFormInput.noValueOptionLabel ?? undefined,
                showNoValueOption: dotNetFormInput.showNoValueOption ?? undefined
            });
        case 'radio-buttons':
            return new RadioButtonsInput({
                noValueOptionLabel: dotNetFormInput.noValueOptionLabel ?? undefined,
                showNoValueOption: dotNetFormInput.showNoValueOption ?? undefined
            });
        case 'switch':
            return new SwitchInput({
                offValue: dotNetFormInput.offValue ?? undefined,
                onValue: dotNetFormInput.onValue ?? undefined
            });
    }

    return undefined;
}

export function hasValue(prop: any): boolean {
    return prop !== undefined && prop !== null;
}

export function buildJsFeatureEffect(dnFeatureEffect: DotNetFeatureEffect): FeatureEffect | null {
    if (dnFeatureEffect === undefined || dnFeatureEffect === null) return null;
    let featureEffect = new FeatureEffect();

    //if there is a single effect, its a string, if there are effects based on scale its an array and has scale and value.
    if (dnFeatureEffect.excludedEffect != null) {
        if (dnFeatureEffect.excludedEffect.length === 1) {
            featureEffect.excludedEffect = buildJsEffect(dnFeatureEffect.excludedEffect[0]);
        } else {
            featureEffect.excludedEffect = dnFeatureEffect.excludedEffect.map(buildJsEffect);
        }
    }
    featureEffect.excludedLabelsVisible = dnFeatureEffect.excludedLabelsVisible ?? undefined;
    if (hasValue(dnFeatureEffect?.filter)) {
        featureEffect.filter = buildJsFeatureFilter(dnFeatureEffect.filter) as FeatureFilter;
    }

    if (dnFeatureEffect.includedEffect != null) {
        if (dnFeatureEffect.includedEffect.length === 1) {
            featureEffect.includedEffect = buildJsEffect(dnFeatureEffect.includedEffect[0]);
        } else {
            featureEffect.includedEffect = dnFeatureEffect.includedEffect.map(buildJsEffect);
        }
    }

    return featureEffect;
}

export function buildJsFeatureFilter(dnFeatureFilter: DotNetFeatureFilter): FeatureFilter | null {
    if (dnFeatureFilter === undefined || dnFeatureFilter === null) return null;

    let featureFilter = new FeatureFilter();
    featureFilter.distance = dnFeatureFilter.distance ?? undefined;
    if (hasValue(dnFeatureFilter.geometry)) {
        featureFilter.geometry = buildJsGeometry(dnFeatureFilter.geometry) as Geometry;
    }
    featureFilter.objectIds = dnFeatureFilter.objectIds ?? undefined;
    featureFilter.spatialRelationship = dnFeatureFilter.spatialRelationship ?? undefined;
    featureFilter.timeExtent = dnFeatureFilter.timeExtent ?? undefined;
    if (hasValue(dnFeatureFilter.where)) {
        featureFilter.units = dnFeatureFilter.units as any;
    }
    featureFilter.where = dnFeatureFilter.where ?? undefined;
    return featureFilter;
}

export function buildJsEffect(dnEffect: any): any {

    if (dnEffect.scale != null) {
        return {
            value: dnEffect.value,
            scale: dnEffect.scale
        };
    } else {
        return dnEffect.value;
    }
}

export function buildJsTickConfigs(dotNetTickConfig: any): any {
    if (dotNetTickConfig === undefined || dotNetTickConfig === null) return null;

    let tickCreatedFunction: Function | null = null;
    if (dotNetTickConfig.tickCreatedFunction != null) {
        tickCreatedFunction = new Function(dotNetTickConfig.tickCreatedFunction);
    }

    let labelFormatFunction: Function | null = null;
    if (dotNetTickConfig.labelFormatFunction != null) {
        labelFormatFunction = new Function(dotNetTickConfig.labelFormatFunction);
    }

    let tickConfig = {
        mode: dotNetTickConfig.mode ?? undefined,
        count: dotNetTickConfig.count ?? undefined,
        values: dotNetTickConfig.values ?? undefined,
        labelsVisible: dotNetTickConfig.labelsVisible ?? undefined,
        tickCreatedFunction: tickCreatedFunction ?? undefined,
        labelFormatFunction: labelFormatFunction ?? undefined
    }
    return tickConfig;
}

export async function buildJsSearchSource(dotNetSource: any, viewId: string): Promise<SearchSource> {
    let source: any = {
        autoNavigate: dotNetSource.autoNavigate ?? undefined,
        filter: buildJsSearchSourceFilter(dotNetSource.filter) ?? undefined,
        maxResults: dotNetSource.maxResults ?? undefined,
        minSuggestCharacters: dotNetSource.minSuggestCharacters ?? undefined,
        name: dotNetSource.name ?? undefined,
        outFields: dotNetSource.outFields ?? undefined,
        placeholder: dotNetSource.placeholder ?? undefined,
        popupEnabled: dotNetSource.popupEnabled ?? undefined,
        prefix: dotNetSource.prefix ?? undefined,
        resultGraphicEnabled: dotNetSource.resultGraphicEnabled ?? undefined,
        searchTemplate: dotNetSource.searchTemplate ?? undefined,
        suffix: dotNetSource.suffix ?? undefined,
        suggestionsEnabled: dotNetSource.suggestionsEnabled ?? undefined,
        zoomScale: dotNetSource.zoomScale ?? undefined
    };

    if (hasValue(dotNetSource.popupTemplate)) {
        source.popupTemplate = buildJsPopupTemplate(dotNetSource.popupTemplate, null, viewId);
    }

    if (hasValue(dotNetSource.resultSymbol)) {
        source.resultSymbol = buildJsSymbol(dotNetSource.resultSymbol);
    }

    if (dotNetSource.hasGetResultsHandler) {
        source.getResults = async (params: any) => {
            let viewId: string | null = null;

            for (let key in arcGisObjectRefs) {
                if (arcGisObjectRefs[key] === params.view) {
                    viewId = key;
                    break;
                }
            }

            let dnParams = {
                exactMatch: params.exactMatch,
                location: buildDotNetPoint(params.location),
                maxResults: params.maxResults,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestResult: {
                    key: params.suggestResult.key,
                    text: params.suggestResult.text,
                    sourceIndex: params.suggestResult.sourceIndex
                },
                viewId: viewId
            }
            let dnResults = await dotNetSource.dotNetComponentReference.invokeMethodAsync('OnJavaScriptGetResults', dnParams);

            let results: SearchResult[] = [];

            for (let dnResult of dnResults) {
                let result: any = {
                    extent: buildJsExtent(dnResult.extent, null) ?? undefined,
                    name: dnResult.name ?? undefined,
                };
                if (hasValue(dnResult.feature)) {
                    result.feature = buildJsGraphic(dnResult.feature, dnResult.feature?.layerId, viewId) as Graphic;
                }
                results.push(result);
            }

            return results;
        }
    }

    if (dotNetSource.hasGetSuggestionsHandler) {
        source.getSuggestions = async (params: any) => {
            let viewId: string | null = null;

            for (let key in arcGisObjectRefs) {
                if (arcGisObjectRefs[key] === params.view) {
                    viewId = key;
                    break;
                }
            }

            let dnParams = {
                maxSuggestions: params.maxSuggestions,
                sourceIndex: params.sourceIndex,
                spatialReference: buildDotNetSpatialReference(params.spatialReference),
                suggestTerm: params.suggestTerm,
                viewId: viewId
            }
            let dnResults = await dotNetSource.dotNetComponentReference.invokeMethodAsync('OnJavaScriptGetSuggestions', dnParams);

            let results: SuggestResult[] = [];

            for (let dnResult of dnResults) {
                results.push({
                    key: dnResult.key,
                    text: dnResult.text,
                    sourceIndex: dnResult.sourceIndex
                })
            }

            return results;
        }
    }

    switch (dotNetSource.type) {
        case "layer":
            let layer: Layer | null = null;
            if (hasValue(dotNetSource.layerId)) {
                layer = arcGisObjectRefs[dotNetSource.layerId] as Layer;
            }
            if (!hasValue(layer) && hasValue(dotNetSource.layer)) {
                layer = await createLayer(dotNetSource.layer, false, viewId);
            }
            source.layer = layer;
            source.displayField = dotNetSource.displayField ?? undefined;
            source.exactMatch = dotNetSource.exactMatch ?? undefined;
            source.orderByFields = dotNetSource.orderByFields ?? undefined;
            source.searchFields = dotNetSource.searchFields ?? undefined;
            source.suggestionTemplate = dotNetSource.suggestionTemplate ?? undefined;

            break;
        case "locator":
            source.apiKey = dotNetSource.apiKey ?? undefined;
            source.categories = dotNetSource.categories ?? undefined;
            source.countryCode = dotNetSource.countryCode ?? undefined;
            source.defaultZoomScale = dotNetSource.defaultZoomScale ?? undefined;
            source.localSearchDisabled = dotNetSource.localSearchDisabled ?? undefined;
            source.locationType = dotNetSource.locationType ?? undefined;
            source.singleLineFieldName = dotNetSource.singleLineFieldName ?? undefined;
            source.url = dotNetSource.url ?? undefined;

            break;
    }

    return source as SearchSource;
}

export function buildJsSearchSourceFilter(dotNetFilter: any): SearchSourceFilter | null {
    if (!hasValue(dotNetFilter)) return null;

    let filter: SearchSourceFilter = {
        where: dotNetFilter.where ?? undefined,
        geometry: buildJsGeometry(dotNetFilter.geometry) ?? undefined
    };

    return filter;
}

export function buildJsAggregateField(dnAggregateField: any): AggregateField {
    return new AggregateField({
        alias: dnAggregateField.alias ?? undefined,
        isAutoGenerated: dnAggregateField.isAutoGenerated ?? undefined,
        name: dnAggregateField.name ?? undefined,
        onStatisticExpression: buildJsSupportExpressionInfo(dnAggregateField.onStatisticExpression) ?? undefined,
        onStatisticField: dnAggregateField.onStatisticField ?? undefined,
        statisticType: dnAggregateField.statisticType ?? undefined
    });
}

export function buildJsSupportExpressionInfo(dnEI: any): supportExpressionInfo | null {
    if (!hasValue(dnEI)) return null;
    return {
        expression: dnEI.expression ?? undefined,
        returnType: dnEI.returnType ?? undefined,
        title: dnEI.title ?? undefined
    } as supportExpressionInfo;
}