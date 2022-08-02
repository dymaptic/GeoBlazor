window.scrollToNav = (page) => {
    let navItems = document.getElementsByTagName('a');
    let navItem = Array.from(navItems).find(i => i.href === page);
    navItem?.scrollIntoViewIfNeeded();
}

window.loadApiKeyFromLocalStorage = () => {
    return window.localStorage['ArcGISApiKey'];
}

window.saveApiKeyToLocalStorage = (apiKey) => {
    window.localStorage['ArcGISApiKey'] = apiKey;
}