// override generated code in this file
import ViewAnimationGenerated from './viewAnimation.gb';
import ViewAnimation from '@arcgis/core/views/ViewAnimation';

export default class ViewAnimationWrapper extends ViewAnimationGenerated {

    constructor(component: ViewAnimation) {
        super(component);
    }

}

export async function buildJsViewAnimation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsViewAnimationGenerated} = await import('./viewAnimation.gb');
    return await buildJsViewAnimationGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetViewAnimation(jsObject: any): Promise<any> {
    let {buildDotNetViewAnimationGenerated} = await import('./viewAnimation.gb');
    return await buildDotNetViewAnimationGenerated(jsObject);
}
