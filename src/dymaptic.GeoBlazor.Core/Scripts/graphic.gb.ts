export function buildJsGraphicGenerated(dotNetObject: any): any {
    let jsGraphic = new Graphic();
    if (hasValue(dotNetObject.geometry)) {
        let { buildJsGeometry } = await import('./geometry');
        jsGraphic.geometry = buildJsGeometry(dotNetObject.geometry) as any;
    }
    if (hasValue(dotNetObject.popupTemplate)) {
        let { buildJsPopupTemplate } = await import('./popupTemplate');
        jsGraphic.popupTemplate = buildJsPopupTemplate(dotNetObject.popupTemplate, layerId, viewId) as any;
    }
    if (hasValue(dotNetObject.symbol)) {
        let { buildJsSymbol } = await import('./symbol');
        jsGraphic.symbol = buildJsSymbol(dotNetObject.symbol) as any;
    }

    if (hasValue(dotNetObject.aggregateGeometries)) {
        jsGraphic.aggregateGeometries = dotNetObject.aggregateGeometries;
    }
    if (hasValue(dotNetObject.attributes)) {
        jsGraphic.attributes = dotNetObject.attributes;
    }
    if (hasValue(dotNetObject.origin)) {
        jsGraphic.origin = dotNetObject.origin;
    }
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(jsGraphic);
    jsObjectRefs[dotNetObject.id] = jsObjectRef;

    arcGisObjectRefs[dotNetObject.id] = jsGraphic;
    let { buildDotNetGraphic } = await import('./graphic');
    let dnInstantiatedObject = buildDotNetGraphic(jsGraphic, layerId, viewId);
    
    try {
        await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef, JSON.stringify(dnInstantiatedObject));
    } catch (e) {
        console.error('Error invoking OnJsComponentCreated for Graphic', e);
    }
    
    return jsGraphic;
}

