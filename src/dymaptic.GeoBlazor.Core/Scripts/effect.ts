import {hasValue} from "./arcGisJsInterop";
import {Un} from "../wwwroot/js/chunk-XF3XD3L6";

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

export function buildJsEffect(dotNetEffect: any): any {
    if (!hasValue(dotNetEffect)) {
        return null;
    }

    if (hasValue(dotNetEffect.scale)) {
        return {
            value: dotNetEffect.value,
            scale: dotNetEffect.scale
        }
    }
    
    return dotNetEffect.value;
}