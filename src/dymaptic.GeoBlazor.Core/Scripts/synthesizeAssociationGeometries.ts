import synthesizeAssociationGeometries = __esri.synthesizeAssociationGeometries;
import SynthesizeAssociationGeometriesGenerated from './synthesizeAssociationGeometries.gb';

export default class SynthesizeAssociationGeometriesWrapper extends SynthesizeAssociationGeometriesGenerated {

    constructor(component: synthesizeAssociationGeometries) {
        super(component);
    }

}

export async function buildJsSynthesizeAssociationGeometries(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSynthesizeAssociationGeometriesGenerated} = await import('./synthesizeAssociationGeometries.gb');
    return await buildJsSynthesizeAssociationGeometriesGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSynthesizeAssociationGeometries(jsObject: any): Promise<any> {
    let {buildDotNetSynthesizeAssociationGeometriesGenerated} = await import('./synthesizeAssociationGeometries.gb');
    return await buildDotNetSynthesizeAssociationGeometriesGenerated(jsObject);
}
