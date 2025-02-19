// override generated code in this file
import TileInfoCreateOptionsGenerated from './tileInfoCreateOptions.gb';
import TileInfoCreateOptions = __esri.TileInfoCreateOptions;

export default class TileInfoCreateOptionsWrapper extends TileInfoCreateOptionsGenerated {

    constructor(component: TileInfoCreateOptions) {
        super(component);
    }
    
}              
export async function buildJsTileInfoCreateOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTileInfoCreateOptionsGenerated } = await import('./tileInfoCreateOptions.gb');
    return await buildJsTileInfoCreateOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTileInfoCreateOptions(jsObject: any): Promise<any> {
    let { buildDotNetTileInfoCreateOptionsGenerated } = await import('./tileInfoCreateOptions.gb');
    return await buildDotNetTileInfoCreateOptionsGenerated(jsObject);
}
