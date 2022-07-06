let gisProjection = null;
let dotNetRef = null;

export function initialize(dotNetReference) {
    require(["esri/geometry/projection"], function (projection) {
        gisProjection = projection;
    });
    dotNetRef = dotNetReference;
}

export async function project(point, spatialReference) {
    try {
        await waitForInitialization();
        await gisProjection.load();
        return gisProjection.project(point, spatialReference);
    } catch (error) {
        logError(error);
    }
}

function waitForInitialization() {
    const poll = resolve => {
        if (gisProjection !== null) resolve();
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