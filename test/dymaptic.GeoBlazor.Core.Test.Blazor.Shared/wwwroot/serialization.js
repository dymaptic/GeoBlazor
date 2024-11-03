import {Core, Portal, SimpleRenderer} from "./testRunner.js";

export async function convertPortalToArcGIS(methodName, portal) {
    let jsPortal = await Core.createArcGISObject(portal, new Portal());
    if (jsPortal.url !== portal.url) {
        throw new Error(`Portal URL does not match`);
    }
}

export async function convertSimpleRendererToArcGIS(methodName, renderer) {
    let jsRenderer = await Core.createArcGISObject(renderer, new SimpleRenderer());
    if (jsRenderer.symbol.type !== renderer.symbol.type) {
        throw new Error(`Renderer symbol type does not match: ${jsRenderer.symbol.type} !== ${renderer.symbol.type}`);
    }
    if (jsRenderer.symbol.color !== renderer.symbol.color) {
        throw new Error(`Renderer symbol color does not match ${jsRenderer.symbol.color} !== ${renderer.symbol.color}`);
    }
    if (jsRenderer.visualVariables[0].type !== renderer.visualVariables[0].type) {
        throw new Error(`Renderer visual variable type does not match ${jsRenderer.visualVariables[0].type} !== ${renderer.visualVariables[0].type}`);
    }
    
}