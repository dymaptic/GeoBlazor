window.scrollToNav = (page) => {
    let navItems = document.getElementsByTagName('a');
    let navItem = Array.from(navItems).find(i => i.href.endsWith(page));
    if (navigator.userAgent.indexOf('Firefox') === -1) {
        // only do this when not in FireFox
        navItem?.scrollIntoViewIfNeeded();
    } else {
        if (!elementIsVisible(navItem)) {
            navItem.scrollIntoView();
        }
    }
}

window.loadApiKeyFromLocalStorage = () => {
    return window.localStorage['ArcGISApiKey'];
}

window.saveApiKeyToLocalStorage = (apiKey) => {
    window.localStorage['ArcGISApiKey'] = apiKey;
}


window.getWidth = () => {
    return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
}

window.getCalciteSelectValue = (calciteSelect) => {
    return calciteSelect.selectedOption.value;
}

window.setWaitCursor = (wait) => {
    if (wait) {
        document.body.style.cursor = 'wait';
    } else {
        document.body.style.cursor = 'default';
    }
}

window.isDarkMode = () => {
    return window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
}

function elementIsVisible(item) {

    let eleTop = item.offsetTop;
    let eleBottom = eleTop + item.clientHeight;

    return (eleTop >= 0 && eleBottom <= window.innerHeight);
}

let Core;
let arcGisObjectRefs = {};

window.initializeGeoBlazor = (core) => {
    Core = core;
    arcGisObjectRefs = Core.arcGisObjectRefs;
}

window.checkMapViewReady = (dotNetRef) => {
    const mapDivs = document.getElementsByClassName('map-container');
    for (let i = 0; i < mapDivs.length; i++) {
        const mapContainer = mapDivs[i];
        if (mapContainer.id && mapContainer.id.startsWith('map-container-')) {
            const viewId = mapContainer.id.replace('map-container-', '');
            if (arcGisObjectRefs.hasOwnProperty(viewId)) {
                const view = arcGisObjectRefs[viewId];
                if (view && view.ready) {
                    dotNetRef.invokeMethodAsync('OnViewReady', viewId);
                }
            }
        }
    }
}

window.disposeAllViews = async () => {
    setWaitCursor(true);
    
    const mapDivs = document.getElementsByClassName('map-container');
    
    for (let i = 0; i < mapDivs.length; i++) {
        const mapContainer = mapDivs[i];
        if (mapContainer.id && mapContainer.id.startsWith('map-container-')) {
            const viewId = mapContainer.id.replace('map-container-', '');
            if (arcGisObjectRefs.hasOwnProperty(viewId)) {
                for (const id in arcGisObjectRefs) {
                    if (id === viewId) {
                        continue;
                    }
                    await Core.disposeMapComponent(id);
                }
                await Core.disposeView(viewId);
            }
        }
    }
    
    setWaitCursor(false);
    return true;
}
