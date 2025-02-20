// override generated code in this file
import VoxelVolumeGenerated from './voxelVolume.gb';
import VoxelVolume from '@arcgis/core/layers/voxel/VoxelVolume';

export default class VoxelVolumeWrapper extends VoxelVolumeGenerated {

    constructor(component: VoxelVolume) {
        super(component);
    }

}

export async function buildJsVoxelVolume(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVoxelVolumeGenerated} = await import('./voxelVolume.gb');
    return await buildJsVoxelVolumeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVoxelVolume(jsObject: any): Promise<any> {
    let {buildDotNetVoxelVolumeGenerated} = await import('./voxelVolume.gb');
    return await buildDotNetVoxelVolumeGenerated(jsObject);
}
