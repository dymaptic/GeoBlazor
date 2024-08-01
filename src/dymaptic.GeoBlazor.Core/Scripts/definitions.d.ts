import Layer from "@arcgis/core/layers/Layer";

export interface MapObject {
    declaredClass: string;

    destroy();

    on(eventName: string, callback: (evt) => any): void;
}

export interface MapCollection extends __esri.Collection {
    items: any[];
}

export interface DotNetGraphic {
    id: string | null;
    uid: string;
    geometry: any;
    attributes: any;

    dotNetGraphicReference: any;
    symbol: DotNetSymbol;
}

export interface DotNetFeature {
    uid: string;
    geometry: any;
    attributes: any;
}

export interface DotNetFeatureSet {
    features: DotNetGraphic[];
    displayFieldName: string;
    exceededTransferLimit: boolean;
    fields: any[];
    geometryType: string;
    queryGeometry: DotNetGeometry | null;
    spatialReference: DotNetSpatialReference | null;
}

export interface DotNetFeatureTemplate {
    name: string;
    description: string;
    drawingTool: any;
    thumbnail: any;
    prototype: DotNetGraphic;
}

export interface DotNetGeometry {
    type: string;
    spatialReference: DotNetSpatialReference;
}

export interface DotNetPoint extends DotNetGeometry {
    latitude: number;
    longitude: number;
    hasM: boolean;
    hasZ: boolean;
    extent: DotNetExtent;
    x: number;
    y: number;
    z: number;
    m: number;
}

export interface DotNetExtent extends DotNetGeometry {
    xmin: number;
    ymin: number;
    xmax: number;
    ymax: number;
    zmin: number;
    zmax: number;
    mmin: number;
    mmax: number;
    hasM: boolean;
    hasZ: boolean;
}

export interface DotNetPolygon extends DotNetGeometry {
    rings: number[][][];
    hasM: boolean;
    hasZ: boolean;
    extent: DotNetExtent,
}

export interface DotNetPolyline extends DotNetGeometry {
    paths: number[][][];
    hasM: boolean;
    hasZ: boolean;
    extent: DotNetExtent;
}

export interface DotNetSymbol {
    type: string;
    color: any;
}

export interface DotNetSimpleMarkerSymbol extends DotNetSymbol {
    outline: DotNetSimpleLineSymbol;
    path: string;
    size: number;
    style: string;
    xOffset: number;
    yOffset: number;
}

export interface DotNetSimpleLineSymbol extends DotNetSymbol {
    cap: string;
    join: string;
    marker: any;
    miterLimit: number;
    style: string;
    width: number;
    lineStyle: string;
}

export interface DotNetPictureMarkerSymbol extends DotNetSymbol {
    angle: number;
    xOffset: number;
    yOffset: number;

    height: number;

    width: number;

    url: string;
}

export interface DotNetPictureFillSymbol extends DotNetSymbol {
    height: number;
    width: number;
    url: string;
    xOffset: number;
    yOffset: number;
    xScale: number;
    yScale: number;
    outline: DotNetSimpleLineSymbol;
}

export interface DotNetSimpleFillSymbol extends DotNetSymbol {
    outline: DotNetSimpleLineSymbol;
    style: string;
}

export interface DotNetTextSymbol extends DotNetSymbol {
    angle: number;
    backgroundColor: string;
    borderLineColor: string;
    borderLineSize: number;
    font: any;
    haloColor: string;
    haloSize: number;
    horizontalAlignment: string;
    kerning: boolean;
    lineHeight: number;
    lineWidth: number;
    rotated: boolean;
    text: string;
    verticalAlignment: string;
    xOffset: number;
    yOffset: number;
}

export interface DotNetSpatialReference {
    isGeographic: boolean;
    isWebMercator: boolean;
    isWgs84: boolean;
    isWrappable: boolean;
    wkid: number;
    wkt: string;
    imageCoordinateSystem: any;
}

export interface DotNetGeographicTransformation {
    steps: Array<DotNetGeographicTransformationStep>
}

export interface DotNetGeographicTransformationStep {
    isInverse: boolean;
    wkid: number;
    wkt: string
}

export interface DotNetActionSection {
    title: string,
    className: string,
    id: string
}

export interface DotNetListItem {
    title: string;
    layerId: string;
    visible: boolean;
    children: DotNetListItem[];
    actionsSections: DotNetActionSection[][];
    panel: any;
}

export interface DotNetLayerView {
    spatialReferenceSupported: boolean;
    suspended: boolean;
    updating: boolean;
    visible: boolean;
}

export interface DotNetHitTestResult {
    results: DotNetViewHit[];
    screenPoint: { x: number, y: number };
}

export interface DotNetViewHit {
    type: string;
    mapPoint: DotNetPoint;
}

export interface DotNetGraphicHit extends DotNetViewHit {
    graphic: DotNetGraphic;
    layerId: string;
}

export interface DotNetLayer {
    fullExtent: DotNetExtent;
    id: string;
    title: string;
    type: string;
    visible: boolean;
    opacity: number;
    listMode: string;
}

export interface DotNetFeatureLayer extends DotNetLayer {
    url: string;
    definitionExpression: string;
    outFields: string[];
    minScale: number;
    maxScale: number;
    objectIdField: string;
    geometryType: string;
    orderBy: any[];
    popupTemplate: DotNetPopupTemplate;
    labelingInfo: any[];
    renderer: any;
    portalItem: any;
    spatialReference: DotNetSpatialReference;
    source: any[];
    fields: any[];
    relationships: any[];
    timeInfo: DotNetTimeInfo;
}

export interface DotNetTimeInfo {
    endField: string;
    startField: string;
    trackIdField: string;
    fullTimeExtent: any;
    interval: any;
}

export interface DotNetGraphicsLayer extends DotNetLayer {
    graphics: DotNetGraphic[];
}

export interface DotNetHitTestOptions {
    includeByGeoBlazorId: Array<string> | null,
    excludeByGeoBlazorId: Array<string> | null,
    includeLayersByArcGISId: Array<string> | null,
    excludeLayersByArcGISId: Array<string> | null,
    includeGraphicsByArcGISId: Array<string> | null,
    excludeGraphicsByArcGISId: Array<string> | null
}

export interface DotNetQuery {
    geometry: DotNetGeometry;
    where: string;
    outFields: string[];
    returnGeometry: boolean;
    spatialRelationship: string;
    useViewExtent: boolean;
    aggregateIds: number[];
    cacheHint: boolean;
    datumTransformation: number;
    distance: number;
    gdbVersion: string;
    geometryPrecision: number;
    groupByFieldsForStatistics: string[];
    having: string;
    historicMoment: Date;
    maxAllowableOffset: number;
    maxRecordCountFactor: number;
    num: number;
    objectIds: number[];
    orderByFields: string[];
    outSpatialReference: DotNetSpatialReference;
    outStatistics: any[];
    parameterValues: any[];
    quantizationParameters: any;
    rangeValues: any[];
    relationParameter: string;
    returnCentroid: boolean;
    returnDistinctValues: boolean;
    returnExceededLimitFeatures: boolean;
    returnM: boolean;
    returnQueryGeometry: boolean;
    returnZ: boolean;
    sqlFormat: string;
    start: number;
    text: string;
    timeExtent: any;
    units: string;
}

export interface DotNetRelationshipQuery {
    cacheHint: boolean;
    gdbVersion: string;
    geometryPrecision: number;
    historicMoment: Date;
    maxAllowableOffset: number;
    num: number;
    objectIds: number[];
    orderByFields: string[];
    outFields: string[];
    outSpatialReference: DotNetSpatialReference;
    relationshipId: number;
    returnGeometry: boolean;
    returnM: boolean;
    returnZ: boolean;
    start: number;
    where: string;
}

export interface DotNetTopFeaturesQuery {
    cacheHint: boolean;
    distance: number;
    geometry: DotNetGeometry;
    geometryPrecision: number;
    maxAllowableOffset: number;
    num: number;
    objectIds: number[];
    orderByFields: string[];
    outFields: string[];
    outSpatialReference: DotNetSpatialReference;
    returnGeometry: boolean;
    returnM: boolean;
    returnZ: boolean;
    spatialRelationship: string;
    start: number;
    timeExtent: any;
    topFilter: any;
    units: string;
    where: string;
}

export interface DotNetPopupTemplate {
    stringContent: string;
    content: DotNetPopupContent[];
    title: string;
    fieldInfos: DotNetFieldInfo[];
    expressionInfos: DotNetExpressionInfo[];
    outFields: string[];
    overwriteActions: boolean;
    returnGeometry: boolean;
    dotNetPopupTemplateReference: any;
    id: string;

    actions: any[];
}

export interface DotNetPopupContent {
    type: string;
}

export interface DotNetFieldsPopupContent extends DotNetPopupContent {
    fieldInfos: DotNetFieldInfo[];
    title: string;
    description: string;
}

export interface DotNetTextPopupContent extends DotNetPopupContent {
    text: string;
}

export interface DotNetMediaPopupContent extends DotNetPopupContent {
    activeMediaInfoIndex: string;
    description: string;
    mediaInfos: DotNetMediaInfo[];
    title: string;
}

export interface DotNetFieldInfo {
    fieldName: string;
    label: string;
    tooltip: string;
    stringFieldOption: string;
    format: DotNetFieldInfoFormat;
    visible: boolean;
    isEditable: boolean;
}

export interface DotNetMediaInfo {
    type: string;
}

export interface DotNetBarChartMediaInfo extends DotNetMediaInfo {
    altText: string;
    caption: string;
    title: string;
    value: DotNetChartMediaInfoValue;
}

export interface DotNetChartMediaInfoValue {
    fields: string[];
    normalizeField: string;
    tooltipField: string;
    series: DotNetChartMediaInfoValueSeries[];
}

export interface DotNetChartMediaInfoValueSeries {
    fieldName: string;
    tooltip: string;
    value: number;
}

export interface DotNetColumnChartMediaInfo extends DotNetMediaInfo {
    altText: string;
    caption: string;
    title: string;
    value: DotNetChartMediaInfoValue;
}

export interface DotNetImageMediaInfo extends DotNetMediaInfo {
    altText: string;
    caption: string;
    title: string;
    refreshInterval: number;
    value: DotNetImageMediaInfoValue;
}

export interface DotNetImageMediaInfoValue extends DotNetMediaInfo {
    linkURL: string;
    sourceURL: string;
}

export interface DotNetLineChartMediaInfo extends DotNetMediaInfo {
    altText: string;
    caption: string;
    title: string;
    value: DotNetChartMediaInfoValue;
}

export interface DotNetPieChartMediaInfo extends DotNetMediaInfo {
    altText: string;
    caption: string;
    title: string;
    value: DotNetChartMediaInfoValue;
}

export interface DotNetExpressionInfo {
    expression: string;
    name: string;
    title: string;
    returnType: string;
}

export interface DotNetFieldInfoFormat {
    places: number;
    digitSeparator: boolean;
    dateFormat: string;
}

export interface DotNetAttachmentsPopupContent extends DotNetPopupContent {
    description: string;
    displayType: string;
    title: string;
}

export interface DotNetExpressionPopupContent extends DotNetPopupContent {
    expressionInfo: DotNetElementExpressionInfo;
}

export interface DotNetElementExpressionInfo {
    expression: string;
    returnType: string;
    title: string;
}

export interface DotNetRelationshipPopupContent extends DotNetPopupContent {
    description: string;
    displayCount: number;
    displayType: string;
    orderByFields: DotNetRelatedRecordsInfoFieldOrder;
    relationshipId: number;
    title: string;
}

export interface DotNetRelatedRecordsInfoFieldOrder {
    field: string;
    order: string;
}

export interface DotNetApplyEdits {
    addFeatures: DotNetGraphic[];
    updateFeatures: DotNetGraphic[];
    deleteFeatures: DotNetGraphic[];
    addAttachments: DotNetAttachmentsEdit[];
    updateAttachments: DotNetAttachmentsEdit[];
    deleteAttachments: string[];
}

export interface DotNetAttachmentsEdit {
    feature: DotNetGraphic | number | string;
    attachment: DotNetAttachment;
}

export interface DotNetAttachment {
    globalId: string;
    name: string;
    contentType: string;
    uploadId: string;
    data: string;
}

export interface DotNetBookmark {
    name: string;
    thumbnail: string;
    viewpoint: DotNetViewpoint;
    timeExtent: any;
}

export interface DotNetViewpoint {
    rotation: number;
    scale: number;
    targetGeometry: DotNetGeometry;
}

export interface DotNetFeatureEffect {
    excludedEffect: DotNetEffect[];
    excludedLabelsVisible: boolean;
    filter: DotNetFeatureFilter;
    includedEffect: DotNetEffect[];
}

export interface DotNetEffect {
    scale: number;
    value: string;
}

export interface DotNetFeatureFilter {
    distance: number;
    geometry: DotNetGeometry;
    objectIds: number[];
    spatialRelationship: string;
    timeExtent: any;
    units: string;
    where: string;
}

export interface DotNetField {
    alias: string;
    defaultValue: any;
    description: string;
    domain: DotNetDomain;
    editable: boolean;
    length: number;
    name: string;
    type: "small-integer" | "integer" | "single" | "double" | "long" | "string" | "date" | "oid" | "geometry" | "blob" | "raster" | "guid" | "global-id" | "xml";
    valueType: string;
}

export interface DotNetDomain {
    type: string;
}

export interface DotNetCodedValueDomain extends DotNetDomain {
    codedValues: DotNetCodedValue[];
    name: string;
}

export interface DotNetCodedValue {
    name: string;
    code: any;
}

export interface DotNetRangeDomain extends DotNetDomain {
    maxValue: number;
    minValue: number;
    name: string;
}

export interface DotNetInheritedDomain extends DotNetDomain {
    name: string;
}
export interface DotNetDimensionalDefinition {
    dimensionName: string;
    isSlice: boolean;
    values: number[];
    variableName: string;
}

export interface DotNetRasterStretchRenderer {
    id: string;
    type: string;
    colorRamp: DotNetColorRamp;
    computeGamma: boolean;
    dynamicRangeAdjustment: boolean;
    statistics: [number[]];
    gamma: number[];
    useGamma: boolean;
    outputMax: number;
    outputMin: number;
    stretchType: string;
    numberOfStandardDeviations: number;
}

export interface DotNetColorRamp {
    type: string;
    multipartColorRamps: DotNetMultiPartColorRamp[];
}

export interface DotNetAlgorithmicColorRamp {
    type: string;
    algorithm: string;
    fromColor: string;
    toColor: string;
}

export interface DotNetMultiPartColorRamp {
    type: string;
    algorithmicColorRamps: DotNetAlgorithmicColorRamp[];
}

export interface DotNetRasterColormapRenderer {
    type: string;
    colormapInfos: DotNetColormapInfo[];
}

export interface DotNetColormapInfo {
    value: number;
    type: string;
    color: string;
    label: string;
}

export interface DotNetFlowRenderer {
    authoringInfo: DotNetAuthoringInfo;
    color: string;
    type: string;
    flowRepresentation: string;
    density: number;
    flowSpeed: number;
    maxPathLength: number;
    legendOptions: string;
    trailCap: string;
    trailLength: number;
    trailWidth: number;
    visualVariables: DotNetVisualVariable[];
}

export interface DotNetVectorFieldRenderer {
    type: string;
    attributeField: string;
    flowRepresentation: string;
    style: string;
    symbolTileSize: number;
    visualVariables: DotNetVisualVariable[];
}

export interface DotNetRasterShadedReliefRenderer {
    altitude: number;
    azimuth: number;
    colorRamp: DotNetColorRamp;
    hillshadeType: string;
    pixelSizeFactor: number;
    pixelSizePower: number;
    scalingType: string;
    type: string;
    zFactor: number;
}

export interface DotNetClassBreaksInfo {
    label: string;
    maxValue: number;
    minValue: number;
    symbol: DotNetSymbol;
}

export interface DotNetClassBreaksRenderer {
    type: string;
    backgroundFillSymbol: DotNetSimpleFillSymbol;
    classBreaksInfos: DotNetClassBreaksInfo[];
    defaultLabel: string;
    defaultSymbol: DotNetSymbol;
    field: string;
    legendOptions: object;
    normalizationField: string;
    normalizationTotal: number;
    normalizationType: string;
    valueExpression: string;
    valueExpressionTitle: string;
    visualVariables: DotNetVisualVariable[]
}

export interface DotNetVisualVariable {
    field: string;
    legendOptions: object;
    type: string;
    valueExpression: string;
    valueExpressionTitle: string;
}

export interface DotNetMultidimensionalSubset {
    areaOfInterest: DotNetExtent;
    dimensions: DotNetSubsetDimension[];
    subsetDefinitions: DotNetDimensionalDefinition[];
    variables: string[];
}

export interface DotNetSubsetDimension {
    name: string;
    extent: DotNetExtent;
    subsetDefinitions: DotNetDimensionalDefinition[];
    variables: string[];
}

export interface DotNetRasterFunction {
    functionName: string;
    functionArguments: object;
}

export interface DotNetRasterFunctionInfo {
    name: string;
    description: string;
    help: string;
    functionType: number;
    thumbnail: string;
}

export interface DotNetAuthoringInfo {
    classificationMethod: string;
    colorRamp: DotNetColorRamp;
    fadeRatio: number;
    field1: object;
    field2: object;
    fields: string[];
    flowTheme: string;
    focus: string;
    isAutoGenerated: boolean;
    lengthUnit: string;
    maxSliderValue: number;
    minSliderValue: number;
    numClasses: number;
    standardDeviationInterval: number;
    statistics: object;
    type: string;
    univariateSymbolStyle: string;
    univariateTheme: string;
    visualVariables: DotNetVisualVariable[]
}

export interface DotNetFieldsIndex {
    dateFields: object[];
}

export interface DotNetUniqueValueClass {
    label: string;
    symbol: DotNetSymbol;
    values: object[];
}
export interface DotNetUniqueValueInfo {
    label: string;
    symbol: DotNetSymbol;
    values: object[];
}

export interface DotNetUniqueValueGroup {
    classes: DotNetUniqueValueClass[];
    heading: string;
}

export interface DotNetUniqueValueRenderer {
    backgroundFillSymbol: DotNetSimpleFillSymbol;
    defaultLabel: string;
    defaultSymbol: any;
    field: string;
    field2: string;
    field3: string;
    fieldDelimiter: string;
    legendOptions: object;
    orderByClassesEnabled: boolean;
    type: string;
    uniqueValueGroups: DotNetUniqueValueGroup[];
    uniqueValueInfos: DotNetUniqueValueInfo[];
    valueExpression: string;
    valueExpressionTitle: string;
    visualVariables: DotNetVisualVariable[];
}

export interface DotNetAddressCandidate {
    address: string;
    attributes?: any;
    extent?: DotNetExtent;
    location?: DotNetPoint;
    score: number;
}

export interface IPropertyWrapper {
    setProperty(prop: string, value: any): void;
    unwrap(): any;
}