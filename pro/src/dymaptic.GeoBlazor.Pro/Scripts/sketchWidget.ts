import Sketch from '@arcgis/core/widgets/Sketch';
import SketchWidgetGenerated from './sketchWidget.gb';
import Graphic from "@arcgis/core/Graphic";
import {arcGisObjectRefs, buildJsStreamReference, hasValue} from './geoBlazorCore';

export default class SketchWidgetWrapper extends SketchWidgetGenerated {
    constructor(sketch: Sketch) {
        super(sketch);
    }

    getActiveTool() {
        return this.widget.activeTool;
    }

    async getCreateGraphic() {
        let jsGraphic = this.widget.createGraphic;
        if (jsGraphic === undefined || jsGraphic === null) {
            return null;
        }

        let { buildDotNetGraphic } = await import('./graphic');
        return buildDotNetGraphic(jsGraphic, null, null);
    }

    async getUpdateGraphics() {
        let jsGraphics = this.widget.updateGraphics;
        if (jsGraphics === undefined || jsGraphics === null) {
            return [];
        }

        let graphics: any[] = [];
        let { buildDotNetGraphic } = await import('./graphic');
        for (let jsGraphic of jsGraphics) {
            graphics.push(buildDotNetGraphic(jsGraphic, null, null));
        }
        
        return graphics;
    }

    cancel() {
        this.widget.cancel();
    }

    complete() {
        this.widget.complete();
    }

    async create(tool: any, options: any) {
        if (options !== null) {
            await this.widget.create(tool, options);
        } else {
            await this.widget.create(tool);
        }
    }

    delete() {
        this.widget.delete();
    }

    duplicate() {
        this.widget.duplicate();
    }

    redo() {
        this.widget.redo();
    }

    undo() {
        this.widget.undo();
    }

    async update(graphics, options) {
        let jsGraphics: Graphic[];
        let { buildJsGraphic } = await import('./graphic');
        if (Array.isArray(graphics)) {
            jsGraphics = graphics.map((graphic) => buildJsGraphic(graphic));
        } else {
            jsGraphics = [buildJsGraphic(graphics)];
        }
        if (options !== null) {
            await this.widget.update(jsGraphics, options);
        } else {
            await this.widget.update(jsGraphics);
        }
    }
}

export async function buildJsSketchWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSketchWidgetGenerated } = await import('./sketchWidget.gb');
    let jsSketch = await buildJsSketchWidgetGenerated(dotNetObject, layerId, viewId);
    if (hasValue(dotNetObject.graphicsLayerId) && arcGisObjectRefs.hasOwnProperty(dotNetObject.graphicsLayerId)) {
        jsSketch.layer = arcGisObjectRefs[dotNetObject.graphicsLayerId];
    } else if (hasValue(dotNetObject.layerId) && arcGisObjectRefs.hasOwnProperty(dotNetObject.layerId)) {
        jsSketch.layer = arcGisObjectRefs[dotNetObject.layerId];
    }
    let eventRateLimit = dotNetObject.eventRateLimitInMilliseconds;
    let lastCreateCall: number = 0;

    jsSketch.on('create', async (evt: any) => {
        if (evt.state === 'active') {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastCreateCall + eventRateLimit > now) {
                return;
            }
            lastCreateCall = now;
        }

        let { buildDotNetSketchCreateEvent } = await import('./sketchCreateEvent');
        let dnEvent = await buildDotNetSketchCreateEvent(evt, layerId, viewId);
        let streamRef = buildJsStreamReference(dnEvent ?? {});
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsCreate', streamRef);
    });
    
    let lastUpdateCall: number = 0;
    
    jsSketch.on('update', async (evt: any) => {
        if (evt.state === 'active') {
            let now = Date.now();
            if (eventRateLimit !== undefined && eventRateLimit !== null &&
                lastUpdateCall + eventRateLimit > now) {
                return;
            }
            lastUpdateCall = now;
        }
        
        let { buildDotNetSketchUpdateEvent } = await import('./sketchUpdateEvent');
        let dnEvent = await buildDotNetSketchUpdateEvent(evt, layerId, viewId);
        let streamRef = buildJsStreamReference(dnEvent ?? {});
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsUpdate', streamRef);
    });

    return jsSketch
}
export async function buildDotNetSketchWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSketchWidgetGenerated } = await import('./sketchWidget.gb');
    return await buildDotNetSketchWidgetGenerated(jsObject, layerId, viewId);
}
