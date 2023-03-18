import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import {buildJsGraphic} from "./jsBuilder";
import Graphic from "@arcgis/core/Graphic";
import {DotNetGraphic} from "./definitions";
import {arcGisObjectRefs} from "./arcGisJsInterop";
import {buildDotNetGraphic} from "./dotNetBuilder";
import GraphicWrapper from "./graphic";

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
        try {
            let jsGraphics: Graphic[] = [];
            let wrappers: GraphicWrapper[] = [];
            for (const g of graphics) {
                let jsGraphic = await buildJsGraphic(g, false, viewId) as Graphic;
                jsGraphics.push(jsGraphic);
                wrappers.push(new GraphicWrapper(jsGraphic));
            }
            this.layer.addMany(jsGraphics);
            console.log(new Date() + " - added to map");
            for (let i = 0; i < wrappers.length; i++){
               const w = wrappers[i];
               // @ts-ignore
               let objectRef = DotNet.createJSObjectReference(w);
               await graphics[i].dotNetGraphicReference.invokeMethodAsync("OnGraphicCreated", objectRef);
            }  
        } catch (error) { 
            console.log(error);
        }
        
    }

    remove(graphicWrapper: GraphicWrapper): void {
        this.layer.remove(graphicWrapper.graphic);
    }

    removeMany(graphicsWrappers: GraphicWrapper[]): void {
        this.layer.removeMany(graphicsWrappers.map(g => g.graphic));
    }
    
    clear(): void {
        this.layer.removeAll();
    }

    getAllGraphics(): DotNetGraphic[] {
        let dnGraphics: DotNetGraphic[] = [];
        this.layer.graphics.forEach(g => {
            dnGraphics.push(buildDotNetGraphic(g));
        });

        return dnGraphics;
    }
}