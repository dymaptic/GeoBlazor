import * as restDemographics from "@esri/arcgis-rest-demographics";
import * as arcgisRest from "@esri/arcgis-rest-request";
import esriRequest from "@arcgis/core/request";
import esriConfig from "@arcgis/core/config";
import BaseComponent from "./baseComponent";
import {hasValue} from "./arcGisJsInterop";

export default class ArcGisRestWrapper extends BaseComponent {
    async queryDemographicData(point) {
        try {
            const authentication = hasValue(esriConfig.apiKey)
                ? arcgisRest.ApiKeyManager.fromKey(esriConfig.apiKey!)
                : undefined;
            let response = await restDemographics.queryDemographicData({
                studyAreas: [{
                    "geometry": {
                        "x": point.longitude,
                        "y": point.latitude
                    }
                }],
                authentication: authentication
            });
            if (response?.results !== null &&
                response.results[0].value.FeatureSet.length > 0 &&
                response.results[0].value.FeatureSet[0].features.length > 0) {
                return response.results[0].value.FeatureSet[0].features;
            }
        } catch (error) {
            console.error(error);
            throw error;
        }
    }
    
    async request(url, options) {
        try {
            return await esriRequest(url, options);
        } catch (error) {
            console.error(error);
            throw error;
        }
    }
}
