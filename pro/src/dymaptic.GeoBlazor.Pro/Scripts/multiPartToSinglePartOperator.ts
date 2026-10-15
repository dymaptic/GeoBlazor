import * as multiPartToSinglePartOperator from "@arcgis/core/geometry/operators/multiPartToSinglePartOperator";
import BaseComponent from './baseComponent';
import { hasValue } from './geoBlazorCore';
import { buildJsGeometry, buildDotNetGeometry } from './geometry';

export default class MultiPartToSinglePartOperatorWrapper extends BaseComponent {
    constructor(dotNetRef: any) {
        super(dotNetRef);
    }

    public async executeMany(geometries: any[], options: any): Promise<any[]> {
        if (!hasValue(geometries) || geometries.length === 0) {
            return [];
        }
        
        let jsGeometries = geometries.map(buildJsGeometry);
        let jsResult;
        if (hasValue(options.simplifyPolygons)) {
            jsResult = multiPartToSinglePartOperator.executeMany(jsGeometries, options);
        } else {
            jsResult = multiPartToSinglePartOperator.executeMany(jsGeometries);
        }

        let result = jsResult.map(buildDotNetGeometry);
        return result;
    }
}


export function buildDotNetMultiPartToSinglePartOperator(jsObject: any): any {
    // n/a
}

export function buildJsMultiPartToSinglePartOperator(dotNetObject: any): any {
    // n/a
}