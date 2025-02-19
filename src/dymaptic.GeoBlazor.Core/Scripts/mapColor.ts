import {hasValue} from "./arcGisJsInterop";

export function buildJsColor(color: any) {
    return buildJsMapColor(color);
}

export function buildJsMapColor(color: any) {
    if (!hasValue(color)) return null;
    // @ts-ignore
    if (typeof color === "string" || color instanceof Array<number>) return color;
    if (hasValue(color?.hexOrNameValue)) {
        return color.hexOrNameValue;
    }
    return color.values;
}

export function buildDotNetColor(color: any) {
    return buildDotNetMapColor(color);
}

export function buildDotNetMapColor(color: any) {
    return color?.toHex();
}
