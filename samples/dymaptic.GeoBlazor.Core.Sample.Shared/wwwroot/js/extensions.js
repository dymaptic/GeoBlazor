// This is an example of how to extend GeoBlazor with your own custom JavaScript.

// In this case, this was chosen over handling the event in C# because in some scenarios (e.g., Blazor Server),
// the latency of the call is noticeable for a real-time event like pointer-move.
// Calling code is in DisplayProjection.razor
export function drawWithGeodesicBufferOnPointer(core, cursorSymbol, bufferSymbol, geodesicBufferDistance,
                                                geodesicBufferUnit, viewId) {
    let arcGisObjectRefs = core.arcGisObjectRefs;
    if (arcGisObjectRefs === undefined) {
        setTimeout(() => drawWithGeodesicBufferOnPointer(cursorSymbol, bufferSymbol,
            geodesicBufferDistance, geodesicBufferUnit, viewId), 500);
        return;
    }
    let view = arcGisObjectRefs[viewId];
    let cursorSymbolGraphic;
    let bufferSymbolGraphic;
    view.on('pointer-move', async (evt) => {
        let cursorPoint = view.toMap({
            x: evt.x,
            y: evt.y,
        });

        if (cursorPoint) {
            if (cursorPoint.spatialReference.wkid !== 3857 &&
                cursorPoint.spatialReference.wkid !== 4326) {
                cursorPoint = await core.projectionEngine.project(cursorPoint, {
                    wkid: 4326
                });
            }
            if (!cursorPoint) return;

            const buffer = await core.geometryEngine.geodesicBuffer(cursorPoint, geodesicBufferDistance, geodesicBufferUnit);

            if (buffer) {
                if (view.graphics.length > 0) {
                    try {
                        view.graphics.removeMany([
                            view.graphics.getItemAt(2),
                            view.graphics.getItemAt(3)
                        ]);
                    } catch {
                        // ignore if they weren't created yet
                    }
                }
                cursorSymbolGraphic = new core.Graphic({
                    geometry: cursorPoint,
                    symbol: cursorSymbol
                });
                bufferSymbolGraphic = new core.Graphic({
                    geometry: buffer,
                    symbol: bufferSymbol
                });
                view.graphics.add(cursorSymbolGraphic);
                view.graphics.add(bufferSymbolGraphic);
            }
        }
    })
}
