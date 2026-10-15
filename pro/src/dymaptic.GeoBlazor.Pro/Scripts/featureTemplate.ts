import {hasValue, lookupGeoBlazorId} from './geoBlazorCore';

export async function buildJsFeatureTemplate(dotNetObject: any): Promise<any> {
    let { buildJsFeatureTemplateGenerated } = await import('./featureTemplate.gb');
    return await buildJsFeatureTemplateGenerated(dotNetObject);
}     

export async function buildDotNetFeatureTemplate(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }

    let dotNetFeatureTemplate: any = {};

    if (hasValue(jsObject.prototype)) {
        // the prototype isn't part of the layer or view, so we can pass nulls for the Ids
        let { buildDotNetGraphic } = await import('./graphic');
        dotNetFeatureTemplate.prototype = buildDotNetGraphic(jsObject.prototype, null, null);
    }

    if (hasValue(jsObject.description)) {
        dotNetFeatureTemplate.description = jsObject.description;
    }

    if (hasValue(jsObject.drawingTool)) {
        dotNetFeatureTemplate.drawingTool = jsObject.drawingTool;
    }

    if (hasValue(jsObject.name)) {
        dotNetFeatureTemplate.name = jsObject.name;
    }

    if (hasValue(jsObject.thumbnail)) {
        dotNetFeatureTemplate.thumbnail = jsObject.thumbnail;
    }


    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetFeatureTemplate.id = geoBlazorId;
    }

    return dotNetFeatureTemplate;
}
