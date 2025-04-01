// override generated code in this file
import TileInfoGenerated from './tileInfo.gb';
import TileInfo from '@arcgis/core/layers/support/TileInfo';

export default class TileInfoWrapper extends TileInfoGenerated {

    constructor(component: TileInfo) {
        super(component);
    }

}

export async function buildJsTileInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTileInfoGenerated} = await import('./tileInfo.gb');
    return await buildJsTileInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTileInfo(jsObject: any): Promise<any> {
    let {buildDotNetTileInfoGenerated} = await import('./tileInfo.gb');
    return await buildDotNetTileInfoGenerated(jsObject);
}
