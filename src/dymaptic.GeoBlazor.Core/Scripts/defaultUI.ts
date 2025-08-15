// override generated code in this file
import DefaultUIGenerated from './defaultUI.gb';
import DefaultUI from '@arcgis/core/views/ui/DefaultUI';

export default class DefaultUIWrapper extends DefaultUIGenerated {

    constructor(component: DefaultUI) {
        super(component);
    }
    
}

export async function buildJsDefaultUI(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDefaultUIGenerated } = await import('./defaultUI.gb');
    return await buildJsDefaultUIGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDefaultUI(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDefaultUIGenerated } = await import('./defaultUI.gb');
    return await buildDotNetDefaultUIGenerated(jsObject, viewId);
}
