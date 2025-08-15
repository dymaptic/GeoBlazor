import {hasValue} from "./arcGisJsInterop";

export function buildJsColor(color: any, viewId: string | null): any {
    return buildJsMapColor(color, viewId);
}

export function buildJsMapColor(color: any, viewId: string | null): any {
    if (!hasValue(color)) return null;
        if (typeof color === "string" || color instanceof Array<number>) return color;
    if (hasValue(color?.hexOrNameValue)) {
        return color.hexOrNameValue;
    }
    return color.values;
}

export function buildDotNetMapColor(color: any, viewId: string | null): any {
    return color?.toHex();
}
