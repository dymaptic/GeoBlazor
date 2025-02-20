// override generated code in this file
import ClassBreaksGenerated from './classBreaks.gb';
import classBreaks = __esri.classBreaks;

export default class ClassBreaksWrapper extends ClassBreaksGenerated {

    constructor(component: classBreaks) {
        super(component);
    }

}

export async function buildJsClassBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassBreaksGenerated} = await import('./classBreaks.gb');
    return await buildJsClassBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassBreaks(jsObject: any): Promise<any> {
    let {buildDotNetClassBreaksGenerated} = await import('./classBreaks.gb');
    return await buildDotNetClassBreaksGenerated(jsObject);
}
