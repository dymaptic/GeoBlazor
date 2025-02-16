import CodedValueDomain from "@arcgis/core/layers/support/CodedValueDomain";
import RangeDomain from "@arcgis/core/layers/support/RangeDomain";
import {buildJsCodedValue} from "./jsBuilder";

export function buildJsDomain(dotNetDomain) {
    switch (dotNetDomain?.type) {
        case 'coded-value':
            return new CodedValueDomain({
                name: dotNetDomain.name ?? undefined,
                codedValues: dotNetDomain.codedValues?.map(c => buildJsCodedValue(c)) ?? undefined
            });
        case 'range':
            return new RangeDomain({
                name: dotNetDomain.name ?? undefined,
                maxValue: dotNetDomain.maxValue ?? undefined,
                minValue: dotNetDomain.minValue ?? undefined
            });
        case 'inherited':
            return {
                type: dotNetDomain.type,
                name: dotNetDomain.name
            };
        default:
            throw new Error(`Unsupported domain type: ${dotNetDomain?.type}`);
    }
}

export function buildDotNetDomain(domain): any {
    if (domain === undefined || domain === null) return null;
    switch (domain.type) {
        case 'coded-value':
            return buildDotNetCodedValueDomain(domain);
        case 'inherited':
            return buildDotNetInheritedDomain(domain);
        case 'range':
            return buildDotNetRangeDomain(domain);
    }
}

function buildDotNetCodedValueDomain(domain) {
    return {
        type: domain.type,
        name: domain.name,
        codedValues: domain.codedValues.map(cv => {
            return {
                name: cv.name,
                code: cv.code
            } 
        })
    };
}

function buildDotNetInheritedDomain(domain) {
    return {
        type: domain.type,
        name: domain.name,
    };
}

function buildDotNetRangeDomain(domain) {
    return {
        type: domain.type,
        name: domain.name,
        maxValue: domain.maxValue,
        minValue: domain.minValue
    };
}