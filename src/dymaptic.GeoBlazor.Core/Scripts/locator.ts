import * as locator from "@arcgis/core/rest/locator";
import SpatialReference from "@arcgis/core/geometry/SpatialReference";
import Point from "@arcgis/core/geometry/Point";
import { buildJsPoint, buildJsSpatialReference, buildJsExtent } from "./jsBuilder";
import { DotNetPoint, DotNetSpatialReference, DotNetAddressCandidate, DotNetExtent } from "./definitions";
import {
    buildDotNetPoint, buildDotNetAddressCandidate
} from "./dotNetBuilder";
import { arcGisObjectRefs, copyValuesIfExists, hasValue } from "./arcGisJsInterop";
import locatorSuggestLocationsParams = __esri.locatorSuggestLocationsParams;
import locatorLocationToAddressParams = __esri.locatorLocationToAddressParams
import locatorAddressToLocationsParams = __esri.locatorAddressToLocationsParams
import locatorAddressesToLocationsParams = __esri.locatorAddressesToLocationsParams
import SuggestionResult = __esri.SuggestionResult;
import AddressCandidate = __esri.AddressCandidate;
export default class LocatorWrapper {
    private dotNetRef: any;

    constructor(dotNetReference) {
        this.dotNetRef = dotNetReference;
    }

    //TODO
    url = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer";

    async addressToLocations(address: any, categories: string[], countryCode: string, forStorage: boolean, location: Point, locationType: string, magicKey: string, maxLocations: number, outFields: string[], outSpatialReference: DotNetSpatialReference, searchExtent: DotNetExtent): Promise<DotNetAddressCandidate[] | null> {
        try {
            var params = { address: address } as locatorAddressToLocationsParams;
            if (hasValue(categories)) {
                params.categories = categories;
            }
            if (hasValue(countryCode)) {
                params.countryCode = countryCode;
            }
            if (hasValue(forStorage)) {
                params.forStorage = forStorage;
            }
            if (hasValue(location)) {
                params.location = buildJsPoint(location);
            }
            if (hasValue(locationType)) {
                params.locationType = locationType;
            }
            if (hasValue(magicKey)) {
                params.magicKey = magicKey;
            }
            if (hasValue(maxLocations)) {
                params.maxLocations = maxLocations;
            }
            if (hasValue(outFields)) {
                params.outFields = outFields;
            }
            if (hasValue(outSpatialReference)) {
                params.outSpatialReference = buildJsSpatialReference(outSpatialReference);
            }
            if (hasValue(searchExtent)) {
                params.searchExtent = buildJsExtent(searchExtent, null);
            }

            var result = await locator.addressToLocations(this.url, params);


            var asd = result.map(r => buildDotNetAddressCandidate(r));

            return null;

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async locationToAddress(location: DotNetPoint, locationType: string, outSpatialReference: DotNetSpatialReference): Promise<DotNetAddressCandidate | null> {
        try {
            var params = { location: buildJsPoint(location) } as locatorLocationToAddressParams;
            if (hasValue(locationType)) {
                params.locationType = locationType;
            }
            if (hasValue(outSpatialReference)) {
                params.outSpatialReference = buildJsSpatialReference(outSpatialReference);
            }
            var result = await locator.locationToAddress(this.url, params);

            return buildDotNetAddressCandidate(result);

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async suggestLocations(location: DotNetPoint, text: string, categories: string[]): Promise<SuggestionResult[] | null> {
        try {
            var params = { location: buildJsPoint(location), text: text } as locatorSuggestLocationsParams;
            if (hasValue(categories)) {
                params.categories = categories;
            }

            return await locator.suggestLocations(this.url, params);

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }


    logError(error) {
        error.message ??= error.toString();
        console.debug(error);
        try {
            this.dotNetRef.invokeMethodAsync('OnJavascriptError', {
                message: error.message, name: error.name, stack: error.stack
            });
        } catch {
        }
    }
}