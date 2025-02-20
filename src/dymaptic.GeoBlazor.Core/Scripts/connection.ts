// override generated code in this file
import ConnectionGenerated from './connection.gb';
import Connection from '@arcgis/core/core/workers/Connection';

export default class ConnectionWrapper extends ConnectionGenerated {

    constructor(component: Connection) {
        super(component);
    }

}

export async function buildJsConnection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsConnectionGenerated} = await import('./connection.gb');
    return await buildJsConnectionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetConnection(jsObject: any): Promise<any> {
    let {buildDotNetConnectionGenerated} = await import('./connection.gb');
    return await buildDotNetConnectionGenerated(jsObject);
}
