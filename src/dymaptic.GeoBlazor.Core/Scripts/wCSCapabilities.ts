import { buildJsWCSCapabilitiesGenerated } from './wCSCapabilities.gb';
import { buildDotNetWCSCapabilitiesGenerated } from './wCSCapabilities.gb';

export function buildDotNetWCSCapabilities(jsObject: any): any {
    return buildDotNetWCSCapabilitiesGenerated(jsObject);
}

export function buildJsWCSCapabilities(dotNetObject: any): any {
    return buildJsWCSCapabilitiesGenerated(dotNetObject);
}
