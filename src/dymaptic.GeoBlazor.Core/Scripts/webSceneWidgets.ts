import BaseComponent from "./baseComponent";
import {hasValue} from "./geoBlazorCore";

export default class WebSceneWidgetsWrapper extends BaseComponent {
    public component: any;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: any) {
        super(component);
        this.component = component;
    }


    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.timeSlider)) {
            let { buildJsWebDocTimeSlider } = await import('./webDocTimeSlider');
            this.component.timeSlider = await buildJsWebDocTimeSlider(dotNetObject.timeSlider, this.layerId, this.viewId) as any;
        }

    }

    // region properties

    async getTimeSlider(): Promise<any> {
        if (!hasValue(this.component.timeSlider)) {
            return null;
        }

        let { buildDotNetWebDocTimeSlider } = await import('./webDocTimeSlider');
        return await buildDotNetWebDocTimeSlider(this.component.timeSlider, this.viewId);
    }

    async setTimeSlider(value: any): Promise<void> {
        let { buildJsWebDocTimeSlider } = await import('./webDocTimeSlider');
        this.component.timeSlider = await  buildJsWebDocTimeSlider(value, this.layerId, this.viewId);
    }

}

export async function buildJsWebSceneWidgets(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebSceneWidgetsGenerated } = await import('./webSceneWidgets.gb');
    return await buildJsWebSceneWidgetsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebSceneWidgets(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebSceneWidgetsGenerated } = await import('./webSceneWidgets.gb');
    return await buildDotNetWebSceneWidgetsGenerated(jsObject, viewId);
}

