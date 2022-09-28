import {addGraphic, arcGisObjectRefs, projection, geometryEngine} from "../../dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";

export function drawWithGeodesicBufferOnPointer(cursorSymbol, bufferSymbol, geodesicBufferDistance,
                                                geodesicBufferUnit, viewId) {
    let cursorGraphicId = cursorSymbol.id;
    let bufferGraphicId = bufferSymbol.id;
    let view = arcGisObjectRefs[viewId];
    view.on('pointer-move', (evt) => {
        let cursorPoint = view.toMap({
            x: evt.x,
            y: evt.y,
        });
        if (cursorPoint) {
            if (cursorPoint.spatialReference.wkid !== 3857 &&
                cursorPoint.spatialReference.wkid !== 4326) {
                cursorPoint = projection.project(cursorPoint, {
                    wkid: 4326
                });
            }
            if (!cursorPoint) return;

            const buffer = geometryEngine.geodesicBuffer(cursorPoint, geodesicBufferDistance, geodesicBufferUnit);

            if (buffer) {
                try {
                    let cursorSymbolGraphic = arcGisObjectRefs[cursorGraphicId];
                    if (cursorSymbolGraphic !== undefined && cursorSymbolGraphic !== null) {
                        view.graphics.remove(cursorSymbolGraphic);
                        cursorSymbolGraphic.destroy();
                        delete arcGisObjectRefs[cursorGraphicId];
                    }
                    let bufferSymbolGraphic = arcGisObjectRefs[bufferGraphicId];
                    if (bufferSymbolGraphic !== undefined && bufferSymbolGraphic !== null) {
                        view.graphics.remove(bufferSymbolGraphic);
                        bufferSymbolGraphic.destroy();
                        delete arcGisObjectRefs[bufferGraphicId];
                    }
                } catch {
                    // ignore if they weren't created yet
                }
                if (cursorGraphicId === undefined) {

                }
                addGraphic({
                    geometry: cursorPoint,
                    symbol: cursorSymbol,
                    id: cursorGraphicId
                }, viewId);
                addGraphic({
                    geometry: buffer,
                    symbol: bufferSymbol,
                    id: bufferGraphicId
                }, viewId);
            }
        }
    })
}
