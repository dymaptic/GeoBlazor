let Pro;
let Core;
let arcGisObjectRefs;

export async function initialize(pro) {
    Pro = pro;
    Core = await pro.getCore();
    arcGisObjectRefs = Core.arcGisObjectRefs;

    Core.esriConfig.request.interceptors.push({
        before: (params) => {
            let service = getCaseInsensitive(params.requestOptions.query, 'service');
            if (service === 'wfs' || service === 'wms') {
                let path = params.url.replace('https://', '');
                params.url = `https://${location.host}/proxy?url=${path}`;
            }
        }
    })
}

export function getView(methodName) {
    const testDiv = document.getElementById(methodName);
    const mapContainer = testDiv.getElementsByClassName('map-container')[0];
    const viewId = mapContainer.id.replace('map-container-', '');
    return arcGisObjectRefs[viewId];
}

function getCaseInsensitive(obj, key) {
    if (obj && typeof obj === "object") {
        const lowerKey = key.toLowerCase();
        for (const k in obj) {
            if (k.toLowerCase() === lowerKey) {
                return obj[k].toLowerCase();
            }
        }
    }
    return undefined;
}