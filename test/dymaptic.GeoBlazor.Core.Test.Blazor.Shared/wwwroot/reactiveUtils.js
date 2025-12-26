import { getView } from "./testRunner.js";

export function clickOnAddBookmarkButton(methodName) {
    let view = getView(methodName);
    let widget = view.ui._components
        .find(c => c.widget?.declaredClass === "esri.widgets.Bookmarks")
        .widget.container;
    let addButton = widget.querySelector('.esri-bookmarks__add-bookmark-button');
    if (!addButton) {
        throw new Error(`Add bookmark button not found`);
    }
    addButton.click();
    setTimeout(() => addBookmarkName(widget), 100);
}

function addBookmarkName(widget) {
    let inputBox = widget.querySelector('.esri-bookmarks__add-bookmark-input');
    
    if (!inputBox) {
        throw new Error(`Input box for adding bookmark not found`);
    }
    
    inputBox.value = 'Test Bookmark';
    setTimeout(() => clickBookmarkAddButton(widget), 100);
}

function clickBookmarkAddButton(widget) {
    let submitButton = widget.querySelector('calcite-button[type="submit"]')
        .shadowRoot.querySelector('button');
    if (!submitButton) {
        throw new Error(`Submit button for adding bookmark not found`);
    }
    console.log(`Clicking submit button to add bookmark`);
    submitButton.click();
}