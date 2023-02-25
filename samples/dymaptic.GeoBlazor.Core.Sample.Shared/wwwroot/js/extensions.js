// This is an example of how to extend GeoBlazor with your own custom JavaScript.
// The import method exposes a dictionary of map components, "arcGisObjectRefs", that can be looked up via the C# component
// "Id" value. A method (addGraphic) and two tools (projection, geometryEngine) are also imported.
import {
    addGraphic,
    arcGisObjectRefs,
    geometryEngine,
    projection
} from "../../dymaptic.GeoBlazor.Core/js/arcGisJsInterop.js";


// In this case, this was chosen over handling the event in C# because in some scenarios (e.g., Blazor Server),
// the latency of the call is noticeable for a real-time event like pointer-move.
// Calling code is in DisplayProjection.razor
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
