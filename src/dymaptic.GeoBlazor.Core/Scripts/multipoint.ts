import {arcGisObjectRefs, hasValue, jsObjectRefs} from './geoBlazorCore';
import Multipoint from "@arcgis/core/geometry/Multipoint";
import {buildDotNetSpatialReference, buildJsSpatialReference} from "./spatialReference";
import {buildDotNetExtent} from "./extent";
import * as simplifyOperator from '@arcgis/core/geometry/operators/simplifyOperator';
import {buildDotNetPoint, buildJsPoint} from "./point";
import BaseComponent from "./baseComponent";
import {DotNetPoint} from "./definitions";


export default class MultipointWrapper extends BaseComponent {
    component: Multipoint;
    
    constructor(multipoint: Multipoint) {
        super(multipoint);
        this.component = multipoint;
    }
    
    addPoint(dotNetPoint: DotNetPoint): any {
        let jsPoint = buildJsPoint(dotNetPoint);
        let jsResult = this.component.addPoint(jsPoint);
        return buildDotNetMultipoint(jsPoint);
    }
    
    getPoint(index: number): DotNetPoint {
        let jsPoint = this.component.getPoint(index);
        return buildDotNetPoint(jsPoint);
    }
    
    removePoint(index: number): any {
        let jsPoint = this.component.removePoint(index);
        return buildDotNetPoint(jsPoint);
    }
    
    setPoint(index: number, dotNetPoint: DotNetPoint): any {
        let jsPoint = buildJsPoint(dotNetPoint);
        let jsResult = this.component.setPoint(index, jsPoint);
        return buildDotNetMultipoint(jsResult);
    }
    
    
}

export function buildJsMultipoint(dotNetObject: any): any {
    let properties: any = {};

    if (hasValue(dotNetObject.hasM)) {
        properties.hasM = dotNetObject.hasM;
    }
    if (hasValue(dotNetObject.hasZ)) {
        properties.hasZ = dotNetObject.hasZ;
    }
    if (hasValue(dotNetObject.points) && dotNetObject.points.length > 0) {
        if (hasValue(dotNetObject.points[0].coordinates)) {
            properties.points = dotNetObject.points
                .map(point => point.coordinates);
        } else {
            properties.points = dotNetObject.points
                .map(p => [p.x ?? p.longitude, p.y ?? p.latitude]);   
        }
    }
    if (hasValue(dotNetObject.spatialReference)) {
        properties.spatialReference = buildJsSpatialReference(dotNetObject.spatialReference);
    }
    
    let jsMultipoint = new Multipoint(properties);
    jsObjectRefs[dotNetObject.id] = new MultipointWrapper(jsMultipoint);
    arcGisObjectRefs[dotNetObject.id] = jsMultipoint;
    
    return jsMultipoint;
}     

export function buildDotNetMultipoint(jsObject: any): any {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetMultipoint: any = {
        type: 'multipoint'
    };

    if (hasValue(jsObject.extent)) {
        dotNetMultipoint.extent = buildDotNetExtent(jsObject.extent);
    }

    if (hasValue(jsObject.cache)) {
        dotNetMultipoint.cache = jsObject.cache;
    }

    if (hasValue(jsObject.hasM)) {
        dotNetMultipoint.hasM = jsObject.hasM;
    }

    if (hasValue(jsObject.hasZ)) {
        dotNetMultipoint.hasZ = jsObject.hasZ;
    }

    if (hasValue(jsObject.points)) {
        dotNetMultipoint.points = jsObject.points;
    }

    if (hasValue(jsObject.spatialReference)) {
        dotNetMultipoint.spatialReference = buildDotNetSpatialReference(jsObject.spatialReference);
    }

    dotNetMultipoint.isSimple = simplifyOperator.isSimple(jsObject);

    return dotNetMultipoint;
}
