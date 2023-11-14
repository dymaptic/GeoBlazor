import {getView} from "./testRunner.js";

export function assertContentByClassName(methodName, className) {
    let view = getView(methodName);
    let expandWidget = view.ui._components.find(c => c.widget.declaredClass === 'esri.widgets.Expand');
    let innerWidget = expandWidget.widget.content.getElementsByClassName(className);
    if (!innerWidget || innerWidget.length === 0) {
        throw new Error(`Child class ${className} does not exist`);
    }
}

export function assertContentById(methodName, id) {
    let view = getView(methodName);
    let expandWidget = view.ui._components.find(c => c.widget.declaredClass === 'esri.widgets.Expand');
    let innerWidget = expandWidget.widget.content.querySelector(`#${id}`);
    if (!innerWidget) {
        throw new Error(`Child element with Id ${id} does not exist`);
    }
}

export function assertContentOrder(methodName, element1Id, element2Id) {
    let view = getView(methodName);
    let expandWidget = view.ui._components.find(c => c.widget.declaredClass === 'esri.widgets.Expand');
    let elements = expandWidget.widget.content.querySelectorAll(`#${element1Id}, #${element2Id}`);
    if (elements.length !== 2) {
        throw new Error(`Incorrect number of child elements`);
    }
    
    let firstFound = false;
    for (let i = 0; i < elements.length; i++) {
        let element = elements[i];
        if (element.id === element1Id) {
            firstFound = true;
        }
        if (element.id === element2Id && !firstFound) {
            throw new Error(`Elements are out of order`);
        }
    }
}