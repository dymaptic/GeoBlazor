import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import {buildJsGraphic} from "./jsBuilder";
import Graphic from "@arcgis/core/Graphic";
import {DotNetGraphic} from "./definitions";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import {buildDotNetGraphic} from "./dotNetBuilder";

export default class GraphicsLayerWrapper {
    private layer: GraphicsLayer;
    constructor(layer: GraphicsLayer) {
        this.layer = layer;
        // set all properties from layer
        for (let prop in layer) {
            if (layer.hasOwnProperty(prop)) {
                this[prop] = layer[prop];
            }
        }
    }
    
    async load(options: AbortSignal): Promise<void> {
        await this.layer.load(options);
    }
    
    async add(graphic: DotNetGraphic, viewId: string): Promise<void> {
        this.layer.add(await buildJsGraphic(graphic, true, viewId) as Graphic);
    }
    
    async addMany(graphics: DotNetGraphic[], viewId: string): Promise<void> {
        let jsGraphics: Graphic[] = [];
        for (const g of graphics) {
            jsGraphics.push(await buildJsGraphic(g, true, viewId) as Graphic);
        }
        this.layer.addMany(jsGraphics);
    }
    
    remove(graphic: DotNetGraphic): void {
        let jsGraphic = arcGisObjectRefs[graphic.id as string] as Graphic;
        this.layer.remove(jsGraphic);
        delete arcGisObjectRefs[graphic.id as string];
    }
    
    removeMany(graphics: DotNetGraphic[]): void {
        let jsGraphics: Graphic[] = [];
        graphics.forEach(g => jsGraphics.push(arcGisObjectRefs[g.id as string] as Graphic));
        this.layer.removeMany(jsGraphics);
        graphics.forEach(g => delete arcGisObjectRefs[g.id as string]);
    }
    
    getAllGraphics(): DotNetGraphic[] {
        let dnGraphics: DotNetGraphic[] = [];
        this.layer.graphics.forEach(g => {
            dnGraphics.push(buildDotNetGraphic(g));
        });
        
        return dnGraphics;
    }
}