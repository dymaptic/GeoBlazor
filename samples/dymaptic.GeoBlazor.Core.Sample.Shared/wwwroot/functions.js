let navbarRef;
let navbar;

window.trackScrollPosition = (navbarElem, dotNetRef) => {
    navbar = navbarElem;
    navbarRef = dotNetRef;
    navbar.addEventListener('scroll', onScroll);
    // Initial call to set the position
    _ = onScroll();
}

window.removeScrollTracking = () => {
    if (navbar) {
        navbar.removeEventListener('scroll', onScroll);
        navbar = null;
    }
    navbarRef = null;
}

window.scrollToPosition = (position) => {
    if (navbar) {
        navbar.scrollTop = position;
    }
}

async function  onScroll() {
    await navbarRef.invokeMethodAsync('OnScroll', navbar.scrollTop);
}

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