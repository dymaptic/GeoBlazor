// override generated code in this file
import IntlGenerated from './intl.gb';
import intl = __esri.intl;

export default class IntlWrapper extends IntlGenerated {

    constructor(component: intl) {
        super(component);
    }

}

export async function buildJsIntl(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIntlGenerated} = await import('./intl.gb');
    return await buildJsIntlGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIntl(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetIntlGenerated} = await import('./intl.gb');
    return await buildDotNetIntlGenerated(jsObject, layerId, viewId);
}
