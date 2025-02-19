import {copyValuesIfExists, hasValue} from "./arcGisJsInterop";

export function buildJsTickConfig(dnTickConfig: any) {
    let tickConfig: any = {
        mode: dnTickConfig.mode ?? undefined,
        values: dnTickConfig.values ?? undefined
    };
    copyValuesIfExists(dnTickConfig, tickConfig, 'labelsVisible');
    if (hasValue(dnTickConfig.tickCreatedFunction)) {
        tickConfig.tickCreatedFunction = (value, tickElement, labelElement) => {
            return new Function('value', 'tickElement', 'labelElement', dnTickConfig.tickCreatedFunction)(value, tickElement, labelElement);
        };
    }
    if (hasValue(dnTickConfig.labelFormatFunction)) {
        tickConfig.labelFormatFunction = (value, type, index) => {
            return new Function('value', 'type', 'index', dnTickConfig.labelFormatFunction)(value, type, index);
        };
    }

    return tickConfig;
}
export async function buildDotNetTickConfig(jsObject: any): Promise<any> {
    let { buildDotNetTickConfigGenerated } = await import('./tickConfig.gb');
    return await buildDotNetTickConfigGenerated(jsObject);
}
