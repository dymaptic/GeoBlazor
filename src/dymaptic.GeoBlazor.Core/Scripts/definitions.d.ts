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
}