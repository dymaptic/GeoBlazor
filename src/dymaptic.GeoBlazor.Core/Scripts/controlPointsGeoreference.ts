// override generated code in this file
import ControlPointsGeoreferenceGenerated from './controlPointsGeoreference.gb';
import ControlPointsGeoreference from '@arcgis/core/layers/support/ControlPointsGeoreference';

export default class ControlPointsGeoreferenceWrapper extends ControlPointsGeoreferenceGenerated {

    constructor(component: ControlPointsGeoreference) {
        super(component);
    }
    
}

export async function buildJsControlPointsGeoreference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsControlPointsGeoreferenceGenerated } = await import('./controlPointsGeoreference.gb');
    return await buildJsControlPointsGeoreferenceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetControlPointsGeoreference(jsObject: any): Promise<any> {
    let { buildDotNetControlPointsGeoreferenceGenerated } = await import('./controlPointsGeoreference.gb');
    return await buildDotNetControlPointsGeoreferenceGenerated(jsObject);
}
