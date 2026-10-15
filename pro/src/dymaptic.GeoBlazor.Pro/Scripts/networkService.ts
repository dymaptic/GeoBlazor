// override generated code in this file
import NetworkServiceGenerated from './networkService.gb';
import * as networkServiceModule from '@arcgis/core/rest/networkService';
import networkService = __esri.networkService;
import { removeCircularReferences } from './geoBlazorCore';
import { buildDotNetTravelMode } from './travelMode';
import { buildDotNetParameterValue } from './parameterValue';
import { remove } from 'ol/array';

export default class NetworkServiceWrapper extends NetworkServiceGenerated {

    constructor(component: networkService) {
        super(component);
    }

    // The generated wrapper expects this.component to expose fetchServiceDescription,
    // but networkService is a module (function exports), not a class. Call the module
    // function directly so the JS interop call from .NET resolves correctly.
    async fetchServiceDescription(url: any, apiKey: any, requestOptions: any): Promise<any> {
        let options: any = requestOptions ?? {};
        let result = await networkServiceModule.fetchServiceDescription(url, apiKey, options) as any;
        return {
            accumulateAttributeNames: result.accumulateAttributeNames,
            attributeParameterValues: await Promise.all(result.attributeParameterValues
                .map(async v => await buildDotNetParameterValue(v))),
            capabilities: removeCircularReferences(result.capabilities),
            currentVersion: result.currentVersion,
            defaultTravelMode: buildDotNetTravelMode(result.defaultTravelMode, this.layerId, this.viewId),
            directionsLanguage: result.directionsLanguage,
            directionsLengthUnits: result.directionsLengthUnits,
            directionsSupportedLanguages: result.directionsSupportedLanguages,
            directionsTimeAttribute: result.directionsTimeAttribute,
            distanceUnits: result.distanceUnits,
            hasZ: result.hasZ,
            impedance: result.impedance,
            supportsTimeWindows: result.supportsTimeWindows,
            supportedTravelModes: result.supportedTravelModes?.map((tm: any) => buildDotNetTravelMode(tm, this.layerId, this.viewId))
        }
    }
}

export async function buildJsNetworkService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsNetworkServiceGenerated} = await import('./networkService.gb');
    return await buildJsNetworkServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetNetworkService(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetNetworkServiceGenerated} = await import('./networkService.gb');
    return await buildDotNetNetworkServiceGenerated(jsObject, layerId, viewId);
}
