export let protoTypeDefinitions: string = `
syntax = "proto3";
package dymaptic.GeoBlazor.Core.Serialization;
import "google/protobuf/empty.proto";

message ActionBase {
   string type = 1;
   string title = 2;
   string className = 3;
   bool active = 4;
   bool disabled = 5;
   bool visible = 6;
   string id = 7;
   string image = 8;
   bool value = 9;
   string actionId = 10;
   string test = 11;
}
message ActionBaseCollection {
   repeated ActionBase items = 1;
}
message Attribute {
   string key = 1;
   string value = 2;
   string valueType = 3;
}
message AttributeCollection {
   repeated Attribute items = 1;
}
message ChartMediaInfoValue {
   repeated string fields = 1;
   string normalizeField = 2;
   string tooltipField = 3;
   repeated ChartMediaInfoValueSeries series = 4;
   string linkURL = 5;
   string sourceURL = 6;
   string id = 7;
}
message ChartMediaInfoValueCollection {
   repeated ChartMediaInfoValue items = 1;
}
message ChartMediaInfoValueSeries {
   string fieldName = 1;
   string tooltip = 2;
   double value = 3;
   string id = 4;
}
message ChartMediaInfoValueSeriesCollection {
   repeated ChartMediaInfoValueSeries items = 1;
}
message ElementExpressionInfo {
   string expression = 1;
   string title = 2;
}
message ElementExpressionInfoCollection {
   repeated ElementExpressionInfo items = 1;
}
message FieldInfo {
   string fieldName = 1;
   string label = 2;
   string tooltip = 3;
   string stringFieldOption = 4;
   FieldInfoFormat format = 5;
   bool isEditable = 6;
   bool visible = 7;
   string id = 8;
}
message FieldInfoCollection {
   repeated FieldInfo items = 1;
}
message FieldInfoFormat {
   int32 places = 1;
   bool digitSeparator = 2;
   string dateFormat = 3;
   string id = 4;
}
message FieldInfoFormatCollection {
   repeated FieldInfoFormat items = 1;
}
message Geometry {
   string type = 1;
   Geometry extent = 2;
   SpatialReference spatialReference = 3;
   double longitude = 4;
   double latitude = 5;
   double x = 6;
   double y = 7;
   double z = 8;
   repeated MapPath paths = 9;
   repeated MapPath rings = 10;
   double xmax = 11;
   double xmin = 12;
   double ymax = 13;
   double ymin = 14;
   double zmax = 15;
   double zmin = 16;
   double mmax = 17;
   double mmin = 18;
   bool hasM = 19;
   bool hasZ = 20;
   double m = 21;
   Geometry centroid = 22;
   bool isSelfIntersecting = 23;
   Geometry center = 24;
   bool geodesic = 25;
   int32 numberOfPoints = 26;
   double radius = 27;
   string radiusUnit = 28;
   string id = 29;
   repeated MapPoint points = 30;
   bool isSimple = 31;
   repeated MeshComponent components = 32;
   MeshTransform transform = 33;
   MeshVertexAttributes vertexAttributes = 34;
   MeshVertexSpace vertexSpace = 35;
}
message GeometryCollection {
   repeated Geometry items = 1;
}
message Graphic {
   string id = 1;
   Geometry geometry = 2;
   Symbol symbol = 3;
   PopupTemplate popupTemplate = 4;
   repeated Attribute attributes = 5;
   bool visible = 6;
   string aggregateGeometries = 7;
   GraphicOrigin origin = 8;
   string layerId = 9;
   string viewId = 10;
   repeated Attribute stackedAttributes = 11;
}
message GraphicCollection {
   repeated Graphic items = 1;
}
message GraphicOrigin {
   string layerId = 1;
   string arcGISLayerId = 2;
   int32 layerIndex = 3;
}
message GraphicOriginCollection {
   repeated GraphicOrigin items = 1;
}
message ImageData {
}
message MapColor {
   repeated double rgbaValues = 1 [ packed = false];
   string hexOrNameValue = 2;
}
message MapFont {
   double size = 1;
   string family = 2;
   string fontStyle = 3;
   string weight = 4;
   string decoration = 5;
   string id = 6;
}
message MapFontCollection {
   repeated MapFont items = 1;
}
message MapPath {
   repeated MapPoint points = 1;
}
message MapPathCollection {
   repeated MapPath items = 1;
}
message MapPoint {
   repeated double coordinates = 1 [ packed = false];
}
message MapPointCollection {
   repeated MapPoint items = 1;
}
message MediaInfo {
   string type = 1;
   string altText = 2;
   string caption = 3;
   string title = 4;
   ChartMediaInfoValue value = 5;
   double refreshInterval = 6;
   string id = 7;
}
message MediaInfoCollection {
   repeated MediaInfo items = 1;
}
message MeshComponent {
   bytes faces = 1;
   MeshComponentMaterial material = 2;
   string name = 3;
   string shading = 4;
}
message MeshComponentCollection {
   repeated MeshComponent items = 1;
}
message MeshComponentMaterial {
   double alphaCutoff = 1;
   string alphaMode = 2;
   MapColor color = 3;
   MeshTexture colorTexture = 4;
   MeshTextureTransform colorTextureTransform = 5;
   bool doubleSided = 6;
   MeshTexture normalTexture = 7;
   MeshTextureTransform normalTextureTransform = 8;
   MapColor emissiveColor = 9;
   MeshTexture emissiveTexture = 10;
   MeshTextureTransform emissiveTextureTransform = 11;
   double metallic = 12;
   MeshTexture metallicRoughnessTexture = 13;
   MeshTexture occlusionTexture = 14;
   MeshTextureTransform occlusionTextureTransform = 15;
   double roughness = 16;
}
message MeshComponentMaterialCollection {
   repeated MeshComponentMaterial items = 1;
}
message MeshTexture {
   ImageData imageData = 1;
   repeated string wrap = 2;
   bool transparent = 3;
   string url = 4;
}
message MeshTextureCollection {
   repeated MeshTexture items = 1;
}
message MeshTextureTransform {
   repeated double offset = 1 [ packed = false];
   double rotation = 2;
   repeated double scale = 3 [ packed = false];
}
message MeshTextureTransformCollection {
   repeated MeshTextureTransform items = 1;
}
message MeshTransform {
   double rotationAngle = 1;
   repeated double rotationAxis = 2 [ packed = false];
   repeated double scale = 3 [ packed = false];
   repeated double translation = 4 [ packed = false];
}
message MeshTransformCollection {
   repeated MeshTransform items = 1;
}
message MeshVertexAttributes {
   bytes color = 1;
   repeated double normal = 2 [ packed = false];
   repeated double position = 3 [ packed = false];
   repeated double tangent = 4 [ packed = false];
   repeated double uv = 5 [ packed = false];
}
message MeshVertexAttributesCollection {
   repeated MeshVertexAttributes items = 1;
}
message MeshVertexSpace {
   string type = 1;
   repeated double origin = 2 [ packed = false];
}
message MeshVertexSpaceCollection {
   repeated MeshVertexSpace items = 1;
}
message PopupContent {
   string type = 1;
   string description = 2;
   string displayType = 3;
   string title = 4;
   ElementExpressionInfo expressionInfo = 5;
   repeated FieldInfo fieldInfos = 6;
   int32 activeMediaInfoIndex = 7;
   repeated MediaInfo mediaInfos = 8;
   int32 displayCount = 9;
   repeated RelatedRecordsInfoFieldOrder orderByFields = 10;
   int64 relationshipId = 11;
   string text = 12;
   string id = 13;
   repeated string outFields = 14;
}
message PopupContentCollection {
   repeated PopupContent items = 1;
}
message PopupExpressionInfo {
   string expression = 1;
   string name = 2;
   string title = 3;
   string returnType = 4;
   string id = 5;
}
message PopupExpressionInfoCollection {
   repeated PopupExpressionInfo items = 1;
}
message PopupTemplate {
   string title = 1;
   string stringContent = 2;
   repeated string outFields = 3;
   repeated FieldInfo fieldInfos = 4;
   repeated PopupContent content = 5;
   repeated PopupExpressionInfo expressionInfos = 6;
   bool overwriteActions = 7;
   bool returnGeometry = 8;
   repeated ActionBase actions = 9;
   string id = 10;
}
message PopupTemplateCollection {
   repeated PopupTemplate items = 1;
}
message RelatedRecordsInfoFieldOrder {
}
message RelatedRecordsInfoFieldOrderCollection {
   repeated RelatedRecordsInfoFieldOrder items = 1;
}
message SpatialReference {
   int32 wkid = 1;
   string wkt = 2;
   string wkt2 = 3;
}
message SpatialReferenceCollection {
   repeated SpatialReference items = 1;
}
message Symbol {
   string type = 1;
   MapColor color = 2;
   Symbol outline = 3;
   double size = 4;
   string style = 5;
   double angle = 6;
   double xoffset = 7;
   double yoffset = 8;
   double width = 9;
   string lineStyle = 10;
   string text = 11;
   MapColor haloColor = 12;
   double haloSize = 13;
   MapFont font = 14;
   double height = 15;
   string url = 16;
   MapColor backgroundColor = 17;
   double borderLineSize = 18;
   MapColor borderLineColor = 19;
   string horizontalAlignment = 20;
   bool kerning = 21;
   double lineHeight = 22;
   double lineWidth = 23;
   bool rotated = 24;
   string verticalAlignment = 25;
   double xScale = 26;
   double yScale = 27;
   string id = 28;
   string name = 29;
   string portalUrl = 30;
   string styleName = 31;
   string styleUrl = 32;
}
message SymbolCollection {
   repeated Symbol items = 1;
}
message ViewHit {
   string type = 1;
   Geometry mapPoint = 2;
   Graphic graphic = 3;
   string layerId = 4;
}
message ViewHitCollection {
   repeated ViewHit items = 1;
}

`;
