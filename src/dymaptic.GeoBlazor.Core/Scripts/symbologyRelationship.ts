import symbologyRelationship = __esri.symbologyRelationship;
import SymbologyRelationshipGenerated from './symbologyRelationship.gb';

export default class SymbologyRelationshipWrapper extends SymbologyRelationshipGenerated {

    constructor(component: symbologyRelationship) {
        super(component);
    }
    
}

export async function buildJsSymbologyRelationship(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbologyRelationshipGenerated } = await import('./symbologyRelationship.gb');
    return await buildJsSymbologyRelationshipGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSymbologyRelationship(jsObject: any): Promise<any> {
    let { buildDotNetSymbologyRelationshipGenerated } = await import('./symbologyRelationship.gb');
    return await buildDotNetSymbologyRelationshipGenerated(jsObject);
}
