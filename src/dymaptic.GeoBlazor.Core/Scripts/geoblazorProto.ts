export let protoTypeDefinitions: string = `
syntax = "proto3";
package dymaptic.GeoBlazor.Core.Serialization;
import "google/protobuf/empty.proto";

message Action {
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
}
message Attribute {
   string key = 1;
   string value = 2;
   string valueType = 3;
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
message ChartMediaInfoValueSeries {
   string fieldName = 1;
   string tooltip = 2;
   double value = 3;
   string id = 4;
}
message ElementExpressionInfo {
   string expression = 1;
   string title = 2;
}
message ExpressionInfo {
   string expression = 1;
   string name = 2;
   string title = 3;
   string returnType = 4;
   string id = 5;
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
message FieldInfoFormat {
   int32 places = 1;
   bool digitSeparator = 2;
   string dateFormat = 3;
   string id = 4;
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
}
message GraphicOrigin {
   string layerId = 1;
   string arcGISLayerId = 2;
   int32 layerIndex = 3;
}
message MapColor {
   repeated double rgbaValues = 1;
   string hexOrNameValue = 2;
}
message MapFontSerializationRecord {
   double size = 1;
   string family = 2;
   string fontStyle = 3;
   string weight = 4;
   string decoration = 5;
   string id = 6;
}
message MapPath {
   repeated MapPoint points = 1;
}
message MapPoint {
   repeated double coordinates = 1;
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
message ProtoGraphicCollection {
   repeated Graphic graphics = 1;
}
message ProtoViewHit {
   string type = 1;
   Geometry mapPoint = 2;
   Graphic graphic = 3;
   string layerId = 4;
}
message ProtoViewHitCollection {
   repeated ProtoViewHit viewHits = 1;
}
message RelatedRecordsInfoFieldOrder {
}
message SpatialReference {
   int32 wkid = 1;
   string wkt = 2;
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

`;