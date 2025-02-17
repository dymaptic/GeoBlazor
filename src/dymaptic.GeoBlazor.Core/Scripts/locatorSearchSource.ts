// override generated code in this file
import LocatorSearchSourceGenerated from './locatorSearchSource.gb';
import LocatorSearchSource from "@arcgis/core/widgets/Search/LocatorSearchSource";

export default class LocatorSearchSourceWrapper extends LocatorSearchSourceGenerated {

    constructor(component: LocatorSearchSource) {
        super(component);
    }

}

export async function buildJsLocatorSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocatorSearchSourceGenerated } = await import('./locatorSearchSource.gb');
    return await buildJsLocatorSearchSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocatorSearchSource(jsObject: any): Promise<any> {
    let { buildDotNetLocatorSearchSourceGenerated } = await import('./locatorSearchSource.gb');
    return await buildDotNetLocatorSearchSourceGenerated(jsObject);
}
