// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import ColorVariable from '@arcgis/core/renderers/visualVariables/ColorVariable';
import {arcGisObjectRefs, hasValue, jsObjectRefs} from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class ColorVariableGenerated implements IPropertyWrapper {
    public component: ColorVariable;
    public readonly geoBlazorId: string = '';

    constructor(component: ColorVariable) {
        this.component = component;
        // set all properties from component
        for (let prop in component) {
            if (component.hasOwnProperty(prop)) {
                this[prop] = component[prop];
            }
        }
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    
    // region properties
    
    async getLegendOptions(): Promise<any> {
        let { buildDotNetVisualVariableLegendOptions } = await import('./visualVariableLegendOptions');
        return await buildDotNetVisualVariableLegendOptions(this.component.legendOptions);
    }
    async setLegendOptions(value: any): Promise<void> {
        let { buildJsVisualVariableLegendOptions } = await import('./visualVariableLegendOptions');
        this.component.legendOptions = await buildJsVisualVariableLegendOptions(value);
    }
    async getStops(): Promise<any> {
        let { buildDotNetColorStop } = await import('./colorStop');
        return this.component.stops.map(async i => await buildDotNetColorStop(i));
    }
    
    async setStops(value: any): Promise<void> {
        let { buildJsColorStop } = await import('./colorStop');
        this.component.stops = value.map(async i => await buildJsColorStop(i));
    }
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}
export async function buildJsColorVariableGenerated(dotNetObject: any): Promise<any> {
    let { default: ColorVariable } = await import('@arcgis/core/renderers/visualVariables/ColorVariable');
    let jsColorVariable = new ColorVariable();
    if (hasValue(dotNetObject.legendOptions)) {
        let { buildJsVisualVariableLegendOptions } = await import('visualVariableLegendOptions');
        jsColorVariable.legendOptions = await buildJsVisualVariableLegendOptions(dotNetObject.legendOptions) as any;

    }
    if (hasValue(dotNetObject.stops)) {
        let { buildJsColorStop } = await import('colorStop');
        jsColorVariable.stops = dotNetObject.stops.map(async i => await buildJsColorStop(i)) as any;

    }
    if (hasValue(dotNetObject.field)) {
        jsColorVariable.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.normalizationField)) {
        jsColorVariable.normalizationField = dotNetObject.normalizationField;
    }
    if (hasValue(dotNetObject.valueExpression)) {
        jsColorVariable.valueExpression = dotNetObject.valueExpression;
    }
    if (hasValue(dotNetObject.valueExpressionTitle)) {
        jsColorVariable.valueExpressionTitle = dotNetObject.valueExpressionTitle;
    }
    let { default: ColorVariableWrapper } = await import('./colorVariable');
    let colorVariableWrapper = new ColorVariableWrapper(jsColorVariable);
    jsColorVariable.id = dotNetObject.id;
    
    // @ts-ignore
    let jsObjectRef = DotNet.createJSObjectReference(colorVariableWrapper);
    await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsComponentCreated', jsObjectRef);
    jsObjectRefs[dotNetObject.id] = colorVariableWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsColorVariable;
    
    return jsColorVariable;
}

export async function buildDotNetColorVariableGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetColorVariable: any = {
        // @ts-ignore
        jsComponentReference: DotNet.createJSObjectReference(jsObject)
    };
        if (hasValue(jsObject.legendOptions)) {
            let { buildDotNetVisualVariableLegendOptions } = await import('./visualVariableLegendOptions');
            dotNetColorVariable.legendOptions = await buildDotNetVisualVariableLegendOptions(jsObject.legendOptions);
        }
        if (hasValue(jsObject.stops)) {
            let { buildDotNetColorStop } = await import('./colorStop');
            dotNetColorVariable.stops = jsObject.stops.map(async i => await buildDotNetColorStop(i));
        }
        dotNetColorVariable.field = jsObject.field;
        dotNetColorVariable.normalizationField = jsObject.normalizationField;
        dotNetColorVariable.type = jsObject.type;
        dotNetColorVariable.valueExpression = jsObject.valueExpression;
        dotNetColorVariable.valueExpressionTitle = jsObject.valueExpressionTitle;
    return dotNetColorVariable;
}

