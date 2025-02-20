// region imports


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