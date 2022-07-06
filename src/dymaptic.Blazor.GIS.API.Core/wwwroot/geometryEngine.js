let engine = null;
let dotNetRef = null;
let engineGraphic = null;

export function initialize(dotNetReference) {
    require(["esri/geometry/geometryEngine", "esri/Graphic"],
        function (geometryEngine, Graphic) {
            engine = geometryEngine;
            engineGraphic = Graphic;
        });
    dotNetRef = dotNetReference;
}

export async function contains() {
    try {
        await waitForInitialization();
        return engine.contains(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function intersects() {
    try {
        await waitForInitialization();
        return engine.intersects(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function disjoint() {
    try {
        await waitForInitialization();
        return engine.disjoint(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function touches() {
    try {
        await waitForInitialization();
        return engine.touches(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function within() {
    try {
        await waitForInitialization();
        return engine.within(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function overlaps() {
    try {
        await waitForInitialization();
        return engine.overlaps(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function crosses() {
    try {
        await waitForInitialization();
        return engine.crosses(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function equals() {
    try {
        await waitForInitialization();
        return engine.equals(...arguments);
    } catch (error) {
        logError(error);
    }
}

export async function geodesicBuffer(geometry, distance, unit, unionResults) {
    try {
        await waitForInitialization();
        const tempGraphic = new engineGraphic({
            geometry: geometry
        });
        const buffer = engine.geodesicBuffer(tempGraphic.geometry, distance, unit, unionResults);
        tempGraphic.destroy();
        return buffer;
    } catch (error) {
        logError(error);
    }
}

export async function geodesicArea(geometry, unit) {
    try {
        await waitForInitialization();
        const tempGraphic = new engineGraphic({
            geometry: geometry
        });
        const buffer = engine.geodesicArea(tempGraphic.geometry, unit);
        tempGraphic.destroy();
        return buffer;
    } catch (error) {
        logError(error);
    }
}

export async function planarArea(geometry, unit) {
    try {
        await waitForInitialization();
        const tempGraphic = new engineGraphic({
            geometry: geometry
        });
        const buffer = engine.planarArea(tempGraphic.geometry, unit);
        tempGraphic.destroy();
        return buffer;
    } catch (error) {
        logError(error);
    }
}

export async function geodesicLength(geometry, unit) {
    try {
        await waitForInitialization();
        const tempGraphic = new engineGraphic({
            geometry: geometry
        });
        const buffer = engine.geodesicLength(tempGraphic.geometry, unit);
        tempGraphic.destroy();
        return buffer;
    } catch (error) {
        logError(error);
    }
}

export async function planarLength(geometry, unit) {
    try {
        await waitForInitialization();
        const tempGraphic = new engineGraphic({
            geometry: geometry
        });
        const buffer = engine.planarLength(tempGraphic.geometry, unit);
        tempGraphic.destroy();
        return buffer;
    } catch (error) {
        logError(error);
    }
}

export async function intersect(geometry1, geometry2) {
    try {
        await waitForInitialization();
        const tempGraphic1 = new engineGraphic({
            geometry: geometry1
        });
        const tempGraphic2 = new engineGraphic({
            geometry: geometry2
        });
        const intersection = engine.intersect(tempGraphic1.geometry, tempGraphic2.geometry);
        tempGraphic1.destroy();
        tempGraphic2.destroy();
        return intersection;
    } catch (error) {
        logError(error);
    }
}

export async function union(geometry1, geometry2) {
    try {
        await waitForInitialization();
        const tempGraphic1 = new engineGraphic({
            geometry: geometry1
        });
        const tempGraphic2 = new engineGraphic({
            geometry: geometry2
        });
        const newUnion = engine.union(tempGraphic1.geometry, tempGraphic2.geometry);
        tempGraphic1.destroy();
        tempGraphic2.destroy();
        return newUnion;
    } catch (error) {
        logError(error);
    }
}

function waitForInitialization() {
    const poll = resolve => {
        if (engine !== null && engineGraphic !== null) resolve();
        else setTimeout(_ => poll(resolve), 400);
    }

    return new Promise(poll);
}

function logError(error) {
    if (error.stack !== undefined && error.stack !== null) {
        console.log(error.stack);
        dotNetRef.invokeMethodAsync('OnJavascriptError', error.stack);
    } else {
        console.log(error.message);
        dotNetRef.invokeMethodAsync('OnJavascriptError', error.message);
    }
}