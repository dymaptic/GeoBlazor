let gisLocator = null;
let dotNetRef = null;

export function initialize(dotNetReference) {
    require(["esri/rest/locator"], (locator) => {
        gisLocator = locator;
    });
    dotNetRef = dotNetReference;
}


export async function locationToAddress(location, serviceUrl, outFields) {
    try {
        await waitForInitialization();
        const params = {
            location: location
        };
        if (outFields !== undefined && outFields !== null) {
            params.outFields = outFields;
        }
        return await gisLocator.locationToAddress(serviceUrl, params);
    } catch (error) {
        logError(error);
    }
}

function waitForInitialization() {
    const poll = resolve => {
        if (gisLocator !== null) resolve();
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