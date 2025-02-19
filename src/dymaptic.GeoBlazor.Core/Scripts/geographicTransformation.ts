import GeographicTransformation from '@arcgis/core/geometry/support/GeographicTransformation';
import GeographicTransformationGenerated from './geographicTransformation.gb';
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

export default class GeographicTransformationWrapper extends GeographicTransformationGenerated {

    constructor(component: GeographicTransformation) {
        super(component);
    }
    
}

export async function buildJsGeographicTransformation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeographicTransformationGenerated } = await import('./geographicTransformation.gb');
    return await buildJsGeographicTransformationGenerated(dotNetObject, layerId, viewId);
}
