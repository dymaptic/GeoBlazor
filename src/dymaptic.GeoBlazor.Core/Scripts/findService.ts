// override generated code in this file
import FindServiceGenerated from './findService.gb';
import find = __esri.find;

export default class FindServiceWrapper extends FindServiceGenerated {

    constructor(component: find) {
        super(component);
    }

}

export async function buildJsFindService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFindServiceGenerated} = await import('./findService.gb');
    return await buildJsFindServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFindService(jsObject: any): Promise<any> {
    let {buildDotNetFindServiceGenerated} = await import('./findService.gb');
    return await buildDotNetFindServiceGenerated(jsObject);
}
