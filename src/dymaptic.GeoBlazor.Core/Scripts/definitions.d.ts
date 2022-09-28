declare module "ArcGisDefinitions" {
    interface MapObject {
        destroy();
        declaredClass: string;

        on(eventName: string, callback: (evt) => any): void;
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
    
    interface DotNetGeometry {
        type: string;
        spatialReference: __esri.SpatialReference;
    }

    interface DotNetPoint extends DotNetGeometry {
        latitude: number;
        longitude: number;
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent;
        x: number;
        y: number;
    }
    
    interface DotNetExtent extends DotNetGeometry {
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
    
    interface DotNetPolygon extends DotNetGeometry {
        rings: number[][][];
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent,
    }
    
    interface DotNetPolyline extends DotNetGeometry {
        paths: number[][][];
        hasM: boolean;
        hasZ: boolean;
        extent: DotNetExtent;
    }
}