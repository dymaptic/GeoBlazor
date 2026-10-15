// override generated code in this file
import SynthesizeAssociationGeometriesGenerated from './synthesizeAssociationGeometries.gb';
import synthesizeAssociationGeometries = __esri.synthesizeAssociationGeometries;

export default class SynthesizeAssociationGeometriesWrapper extends SynthesizeAssociationGeometriesGenerated {

    constructor(component: synthesizeAssociationGeometries) {
        super(component);
    }
    
}

export async function buildJsSynthesizeAssociationGeometries(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSynthesizeAssociationGeometriesGenerated } = await import('./synthesizeAssociationGeometries.gb');
    return await buildJsSynthesizeAssociationGeometriesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSynthesizeAssociationGeometries(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSynthesizeAssociationGeometriesGenerated } = await import('./synthesizeAssociationGeometries.gb');
    return await buildDotNetSynthesizeAssociationGeometriesGenerated(jsObject, layerId, viewId);
}
