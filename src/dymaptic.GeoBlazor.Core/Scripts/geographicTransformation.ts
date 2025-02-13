export function buildDotNetGeographicTransformation(geographicTransformation: any): any {
    if (geographicTransformation === undefined || geographicTransformation === null) return null;
    let steps: any[] = [];
    geographicTransformation.steps.forEach(s => {
        steps.push({
            isInverse: s.isInverse,
            wkid: s.wkid,
            wkt: s.wkt
        })
    });
    return {
        steps: steps
    };
}