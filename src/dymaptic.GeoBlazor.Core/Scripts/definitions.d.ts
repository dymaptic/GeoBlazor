import Layer from "@arcgis/core/layers/Layer";


declare module "ArcGisDefinitions" {
    interface MapObject {
        destroy();
        declaredClass: string;
    }
    
    interface MapCollection extends __esri.Collection {
        items: any[];
    }

    interface DotNetGraphic {
        uid: string;
        geometry: any;
    }

    interface DotNetFeature {
        uid: string;
        geometry: any;
        attributes: any;
    }

    interface DotNetPoint {
        type: string;
        latitude: number;
        longitude: number;
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent;
        x: number;
        y: number;
        spatialReference: __esri.SpatialReference;
    }
    
    interface DotNetExtent {
        type: string;
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
        spatialReference: __esri.SpatialReference;
    }
    
    interface DotNetPolygon {
        type: string;
        rings: number[][][];
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent,
        spatialReference: __esri.SpatialReference;
    }
    
    interface DotNetPolyline {
        type: string;
        paths: number[][][];
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent;
        spatialReference: __esri.SpatialReference
    }
    /// <summary>
    ///     The Action Sections property and corresponding functionality will be fully implemented
    ///     in a future iteration.  Currently, a user can view available layers in the layer list widget
    ///     and toggle the selected layer's visiblity. More capabilities will be available after full
    ///     implementation of ActionSection.
    /// </summary>
    interface DotNetActionSection {
        title: string,
        className: string,
        id: string
    }

    interface DotNetListItem {
        title: string;
        layer: Layer;
        visible: boolean;
        children: DotNetListItem[],
        actionSections: DotNetActionSection[][]
    }
}