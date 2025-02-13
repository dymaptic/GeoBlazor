import * as locator from "@arcgis/core/rest/locator";
import {buildJsPoint, buildJsSpatialReference} from "./jsBuilder";
import {DotNetAddressCandidate, DotNetExtent, DotNetPoint, DotNetSpatialReference} from "./definitions";
import {hasValue} from "./arcGisJsInterop";
import locatorSuggestLocationsParams = __esri.locatorSuggestLocationsParams;
import locatorLocationToAddressParams = __esri.locatorLocationToAddressParams;
import locatorAddressToLocationsParams = __esri.locatorAddressToLocationsParams;
import locatorAddressesToLocationsParams = __esri.locatorAddressesToLocationsParams;
import SuggestionResult = __esri.SuggestionResult;
import AddressCandidate from "@arcgis/core/rest/support/AddressCandidate";
import Point from "@arcgis/core/geometry/Point";
import { buildJsExtent } from "./extent";

export default class LocatorWrapper {
    
    async addressesToLocations(url: string, addresses: object[], countryCode: string | null, 
                               categories: string[] | null, locationType: string | null, 
                               outSpatialReference: DotNetSpatialReference | null, 
                               requestOptions: any | null)
        : Promise<any | null> {
        const params = {addresses: addresses} as locatorAddressesToLocationsParams;
        if (hasValue(categories)) {
            params.categories = categories as string[];
        }
        if (hasValue(countryCode)) {
            params.countryCode = countryCode as string;
        }

        if (hasValue(locationType)) {
            params.locationType = locationType as string;
        }
        if (hasValue(outSpatialReference)) {
            params.outSpatialReference = buildJsSpatialReference(outSpatialReference as DotNetSpatialReference);
        }

        let result: AddressCandidate[];
        if (hasValue(requestOptions)) {
            result = await locator.addressesToLocations(url, params, requestOptions);
        } else {
            result = await locator.addressesToLocations(url, params);
        }

        let { buildDotNetAddressCandidate } = await import('./addressCandidate');
        let dotNetResult = result.map(r => buildDotNetAddressCandidate(r));

        let json = JSON.stringify(dotNetResult);
        let encoded = new TextEncoder().encode(json);
        return encoded;
    }

    async addressToLocations(url: string, address: any, categories: string[] | null, countryCode: string | null, 
                             forStorage: boolean | null, location: DotNetPoint | null, locationType: string | null, 
                             magicKey: string | null, maxLocations: number | null, outFields: string[] | null, 
                             outSpatialReference: DotNetSpatialReference | null, searchExtent: DotNetExtent | null, 
                             requestOptions: any | null)
        : Promise<any | null> {
        let params = {address: address} as locatorAddressToLocationsParams;
        if (hasValue(categories)) {
            params.categories = categories as string[];
        }
        if (hasValue(countryCode)) {
            params.countryCode = countryCode as string;
        }
        if (hasValue(forStorage)) {
            params.forStorage = forStorage as boolean;
        }
        if (hasValue(location)) {
            params.location = buildJsPoint(location as DotNetPoint) as Point;
        }
        if (hasValue(locationType)) {
            params.locationType = locationType as string;
        }
        if (hasValue(magicKey)) {
            params.magicKey = magicKey as string;
        }
        if (hasValue(maxLocations)) {
            params.maxLocations = maxLocations as number;
        }
        if (hasValue(outFields)) {
            params.outFields = outFields as string[];
        }
        if (hasValue(outSpatialReference)) {
            params.outSpatialReference = buildJsSpatialReference(outSpatialReference as DotNetSpatialReference);
        }
        if (hasValue(searchExtent)) {
            params.searchExtent = buildJsExtent(searchExtent as DotNetExtent, null);
        }

        let result: AddressCandidate[];

        if (hasValue(requestOptions)) {
            result = await locator.addressToLocations(url, params, requestOptions);
        } else {
            result = await locator.addressToLocations(url, params);
        }

        let { buildDotNetAddressCandidate } = await import('./addressCandidate');
        let dotNetResult = result.map(r => buildDotNetAddressCandidate(r));

        let json = JSON.stringify(dotNetResult);
        let encoded = new TextEncoder().encode(json);
        return encoded;
    }

    async locationToAddress(url: string, location: DotNetPoint, locationType: string | null, 
                            outSpatialReference: DotNetSpatialReference | null, requestOptions: any | null)
        : Promise<DotNetAddressCandidate | null> {
        let params = {
            location: buildJsPoint(location)
        } as locatorLocationToAddressParams;

        if (hasValue(locationType)) {
            params.locationType = locationType as string;
        }
        if (hasValue(outSpatialReference)) {
            params.outSpatialReference = buildJsSpatialReference(outSpatialReference as DotNetSpatialReference);
        }

        let result: AddressCandidate;

        if (hasValue(requestOptions)) {
            result = await locator.locationToAddress(url, params, requestOptions);
        } else {
            result = await locator.locationToAddress(url, params);
        }

        let { buildDotNetAddressCandidate } = await import('./addressCandidate');
        return buildDotNetAddressCandidate(result);
    }

    async suggestLocations(url: string, location: DotNetPoint, text: string, categories: string[] | null, 
                           requestOptions: any | null)
        : Promise<SuggestionResult[] | null> {
        let params = {
            location: buildJsPoint(location), text: text
        } as locatorSuggestLocationsParams;

        if (hasValue(categories)) {
            params.categories = categories as string[];
        }

        if (hasValue(requestOptions)) {
            return await locator.suggestLocations(url, params, requestOptions);
        }

        return await locator.suggestLocations(url, params);
    }
}