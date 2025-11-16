import {copyValuesIfExists, hasValue} from "./arcGisJsInterop";

export function buildJsTickConfig(dotNetObject: any): any {
    let tickConfig: any = {
        mode: dotNetObject.mode ?? undefined,
        values: dotNetObject.values ?? undefined
    };
    copyValuesIfExists(dotNetObject, tickConfig, 'labelsVisible');
    if (hasValue(dotNetObject.tickCreatedFunction)) {
        tickConfig.tickCreatedFunction = (value, tickElement, labelElement) => {
            return new Function('value', 'tickElement', 'labelElement', dotNetObject.tickCreatedFunction)(value, tickElement, labelElement);
        };
    }
    if (hasValue(dotNetObject.labelFormatFunction)) {
        tickConfig.labelFormatFunction = (value, type, index) => {
            return new Function('value', 'type', 'index', dotNetObject.labelFormatFunction)(value, type, index);
        };
    }

    return tickConfig;
}

export async function buildDotNetTickConfig(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetTickConfigGenerated} = await import('./tickConfig.gb');
    return await buildDotNetTickConfigGenerated(jsObject, viewId);
}
