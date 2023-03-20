import GraphicsLayer from "@arcgis/core/layers/GraphicsLayer";
import {buildJsGraphic} from "./jsBuilder";
import Graphic from "@arcgis/core/Graphic";
import {DotNetGraphic} from "./definitions";
import {getGraphicsFromProtobufStream} from "./arcGisJsInterop";
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

    async add(graphicRef: any, viewId: string): Promise<GraphicWrapper | null> {
        try {
            let graphics = await getGraphicsFromProtobufStream(graphicRef) as any[];
            let jsGraphic = buildJsGraphic(graphics[0], viewId) as Graphic;
            this.layer.add(jsGraphic);
            return new GraphicWrapper(jsGraphic);
        } catch (error) {
            console.log(error);
            return null;
        }
    }
    
    async addMany(streamRef: any, viewId: string, layerRef: any): Promise<void> {
        try {
            let graphics = await getGraphicsFromProtobufStream(streamRef) as any[];
            let jsGraphics: Graphic[] = [];
            for (const g of graphics) {
                let jsGraphic = buildJsGraphic(g, viewId) as Graphic;
                jsGraphics.push(jsGraphic);
            }
            this.layer.addMany(jsGraphics);
            for (let i = 0; i < jsGraphics.length; i++) {
                let graphic = jsGraphics[i];
                let graphicObject = graphics[i];
                // @ts-ignore
                let wrapperRef = DotNet.createJSObjectReference(new GraphicWrapper(graphic));
                await layerRef.invokeMethodAsync("RegisterGraphicReference", graphicObject.id, wrapperRef);
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