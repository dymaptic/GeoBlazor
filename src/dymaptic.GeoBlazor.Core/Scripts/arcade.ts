// override generated code in this file
import ArcadeGenerated from './arcade.gb';
import arcade = __esri.arcade;

export default class ArcadeWrapper extends ArcadeGenerated {

    constructor(component: arcade) {
        super(component);
    }

}

export async function buildJsArcade(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsArcadeGenerated} = await import('./arcade.gb');
    return await buildJsArcadeGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetArcade(jsObject: any): Promise<any> {
    let {buildDotNetArcadeGenerated} = await import('./arcade.gb');
    return await buildDotNetArcadeGenerated(jsObject);
}
