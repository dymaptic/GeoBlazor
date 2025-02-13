import {hasValue} from "./arcGisJsInterop";

export function buildDotNetEffect(jsEffect: any): any {
    if (!hasValue(jsEffect)) {
        return null;
    }

    if (jsEffect instanceof String) {
        return {
            value: jsEffect
        };
    }

    return {
        value: jsEffect.value,
        scale: jsEffect.scale
    }
}