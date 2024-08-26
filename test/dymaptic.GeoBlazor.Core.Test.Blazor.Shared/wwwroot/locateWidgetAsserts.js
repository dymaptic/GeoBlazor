import {getView} from "./testRunner.js";

export async function clickOnLocateWidget(methodName) {
    let div = document.querySelector('[class="esri-component esri-locate esri-widget"]');
    // find button inside div
    let button = div.querySelector('[class="esri-widget--button"]');
    button.click();
}