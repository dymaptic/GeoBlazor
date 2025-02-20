// override generated code in this file
import ITablesMixinGenerated from './iTablesMixin.gb';
import TablesMixin = __esri.TablesMixin;

export default class ITablesMixinWrapper extends ITablesMixinGenerated {

    constructor(component: TablesMixin) {
        super(component);
    }

}

export async function buildJsITablesMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsITablesMixinGenerated} = await import('./iTablesMixin.gb');
    return await buildJsITablesMixinGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetITablesMixin(jsObject: any): Promise<any> {
    let {buildDotNetITablesMixinGenerated} = await import('./iTablesMixin.gb');
    return await buildDotNetITablesMixinGenerated(jsObject);
}
