import * as locator from "@arcgis/core/rest/locator";
import {buildJsExtent, buildJsPoint, buildJsSpatialReference} from "./jsBuilder";
import {DotNetAddressCandidate, DotNetExtent, DotNetPoint, DotNetSpatialReference} from "./definitions";
import {buildDotNetAddressCandidate} from "./dotNetBuilder";
import {hasValue} from "./arcGisJsInterop";
import locatorSuggestLocationsParams = __esri.locatorSuggestLocationsParams;
import locatorLocationToAddressParams = __esri.locatorLocationToAddressParams;
import locatorAddressToLocationsParams = __esri.locatorAddressToLocationsParams;
import locatorAddressesToLocationsParams = __esri.locatorAddressesToLocationsParams;
import SuggestionResult = __esri.SuggestionResult;
import AddressCandidate from "@arcgis/core/rest/support/AddressCandidate";
import Point from "@arcgis/core/geometry/Point";

export default class LocatorWrapper {
    private dotNetRef: any;

    constructor(dotNetReference) {
        this.dotNetRef = dotNetReference;
    }

    async addressesToLocations(url: string, addresses: object[], categories: string[], countryCode: string, 
                               locationType: string, outSpatialReference: DotNetSpatialReference, requestOptions: any)
        : Promise<(DotNetAddressCandidate | null)[]> {
        try {

            const params = {addresses: addresses} as locatorAddressesToLocationsParams;
            if (hasValue(categories)) {
                params.categories = categories;
            }
            if (hasValue(countryCode)) {
                params.countryCode = countryCode;
            }

            if (hasValue(locationType)) {
                params.locationType = locationType;
            }
            if (hasValue(outSpatialReference)) {
                params.outSpatialReference = buildJsSpatialReference(outSpatialReference);
            }
            
            let result: AddressCandidate[];
            if (hasValue(requestOptions)) {
                result = await locator.addressesToLocations(url, params, requestOptions);
            } else {
                result = await locator.addressesToLocations(url, params);
            }

            return result.map(r => buildDotNetAddressCandidate(r));

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async addressToLocations(url: string, address: any, categories: string[], countryCode: string, forStorage: boolean, 
                             location: DotNetPoint, locationType: string, magicKey: string, maxLocations: number, 
                             outFields: string[], outSpatialReference: DotNetSpatialReference, 
                             searchExtent: DotNetExtent, requestOptions: any)
        : Promise<(DotNetAddressCandidate | null)[]> {
        try {
            let params = {address: address} as locatorAddressToLocationsParams;
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
                params.location = buildJsPoint(location) as Point;
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

            let result: AddressCandidate[];
            
            if (hasValue(requestOptions)) {
                result = await locator.addressToLocations(url, params, requestOptions);
            } else {
                result = await locator.addressToLocations(url, params);
            }

            return result.map(r => buildDotNetAddressCandidate(r));

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async locationToAddress(url: string, location: DotNetPoint, locationType: string, 
                            outSpatialReference: DotNetSpatialReference, requestOptions: any)
        : Promise<DotNetAddressCandidate | null> {
        try {
            let params = {
                location: buildJsPoint(location)
            } as locatorLocationToAddressParams;
            
            if (hasValue(locationType)) {
                params.locationType = locationType;
            }
            if (hasValue(outSpatialReference)) {
                params.outSpatialReference = buildJsSpatialReference(outSpatialReference);
            }
            
            let result: AddressCandidate;
            
            if (hasValue(requestOptions)) {
                result = await locator.locationToAddress(url, params, requestOptions);
            } else {
                result = await locator.locationToAddress(url, params);
            }

            return buildDotNetAddressCandidate(result);

        } catch (error) {
            this.logError(error);
            throw error;
        }
    }

    async suggestLocations(url: string, location: DotNetPoint, text: string, categories: string[], requestOptions: any)
        : Promise<SuggestionResult[] | null> {
        try {

            let params = {
                location: buildJsPoint(location), text: text
            } as locatorSuggestLocationsParams;
            
            if (hasValue(categories)) {
                params.categories = categories;
            }
            
            if (hasValue(requestOptions)) {
                return await locator.suggestLocations(url, params, requestOptions);
            }
            
            return await locator.suggestLocations(url, params);

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