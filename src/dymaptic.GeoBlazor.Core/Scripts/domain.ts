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