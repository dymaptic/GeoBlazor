window.scrollToNav = (page) => {
    let navItems = document.getElementsByTagName('a');
    let navItem = Array.from(navItems).find(i => i.href === page);
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


function elementIsVisible(item) {
    
    let eleTop = item.offsetTop;
    let eleBottom = eleTop + item.clientHeight;

    return (eleTop >=0 && eleBottom <= window.innerHeight);
}