// override generated code in this file
import VersioningStateGenerated from './versioningState.gb';
import VersioningState from '@arcgis/core/versionManagement/VersioningState';

export default class VersioningStateWrapper extends VersioningStateGenerated {

    constructor(component: VersioningState) {
        super(component);
    }

}

export async function buildJsVersioningState(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVersioningStateGenerated} = await import('./versioningState.gb');
    return await buildJsVersioningStateGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVersioningState(jsObject: any): Promise<any> {
    let {buildDotNetVersioningStateGenerated} = await import('./versioningState.gb');
    return await buildDotNetVersioningStateGenerated(jsObject);
}
