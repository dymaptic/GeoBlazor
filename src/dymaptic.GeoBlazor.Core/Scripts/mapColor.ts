import {hasValue} from "./arcGisJsInterop";

export function buildJsColor(color: any): any {
    return buildJsMapColor(color);
}

export function buildJsMapColor(color: any): any {
    if (!hasValue(color)) return null;
        if (typeof color === "string" || color instanceof Array<number>) return color;
    if (hasValue(color?.hexOrNameValue)) {
        return color.hexOrNameValue;
    }
    return color.values;
}

export function buildDotNetMapColor(color: any): any {
    return color?.toHex();
}
