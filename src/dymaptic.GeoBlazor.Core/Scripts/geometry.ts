import { arcGisObjectRefs } from "./arcGisJsInterop";
let dotNetRef: any = null;

export function initialize(dotNetReference: any, viewId: string, geometryId: string, geometryType: string): void {
    dotNetRef = dotNetReference;
    console.log(viewId);
    console.log(arcGisObjectRefs);
    let view = arcGisObjectRefs[viewId];
    console.log(view);
    if (view) {

        //view.on("click", (event) => {
        //    let atts = null;
        //    let thisWasSelected: boolean = false;
        //    view.hitTest(event).then((response) => {
        //        if (response.results.length) {
        //            const point = response.results.find(i => findMapGeometry(i, geometryType, geometryId));
        //            if (point) {
        //                thisWasSelected = true;
        //            //    atts = point.layer..mapPoint..graphic.attributes;
        //            }
        //        }
        //    });
        //    dotNetRef.invokeMethodAsync('OnGeometrySelectedInJS', thisWasSelected, atts);
        //});
        console.log("Click event registered");
    }
}

function findMapGeometry(graphic: any, type: string, geometryId: string) {
    if (type && graphic && geometryId) {
        try {
            if (graphic.graphic.geometry.type === type && graphic.graphic.symbol.id === geometryId)
                return true;
            else
                return false;
        } catch (e) {
            return false;
        }
    }
}

export function disposeContext() {
    if (dotNetRef != null) {
        dotNetRef.dispose;
    }
}