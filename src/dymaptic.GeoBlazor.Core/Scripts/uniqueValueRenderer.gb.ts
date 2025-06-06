// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import UniqueValueRenderer from '@arcgis/core/renderers/UniqueValueRenderer';
import { arcGisObjectRefs, jsObjectRefs, hasValue, lookupGeoBlazorId, removeCircularReferences, Pro, generateSerializableJson } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class UniqueValueRendererGenerated implements IPropertyWrapper {
    public component: UniqueValueRenderer;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: UniqueValueRenderer) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {
        if (hasValue(dotNetObject.authoringInfo)) {
            let { buildJsAuthoringInfo } = await import('./authoringInfo');
            this.component.authoringInfo = await buildJsAuthoringInfo(dotNetObject.authoringInfo) as any;
        }
        if (hasValue(dotNetObject.backgroundFillSymbol)) {
            let { buildJsFillSymbol } = await import('./fillSymbol');
            this.component.backgroundFillSymbol = await buildJsFillSymbol(dotNetObject.backgroundFillSymbol) as any;
        }
        if (hasValue(dotNetObject.defaultSymbol)) {
            let { buildJsSymbol } = await import('./symbol');
            this.component.defaultSymbol = buildJsSymbol(dotNetObject.defaultSymbol) as any;
        }
        if (hasValue(dotNetObject.legendOptions)) {
            let { buildJsUniqueValueRendererLegendOptions } = await import('./uniqueValueRendererLegendOptions');
            this.component.legendOptions = await buildJsUniqueValueRendererLegendOptions(dotNetObject.legendOptions) as any;
        }
        if (hasValue(dotNetObject.uniqueValueGroups) && dotNetObject.uniqueValueGroups.length > 0) {
            let { buildJsUniqueValueGroup } = await import('./uniqueValueGroup');
            this.component.uniqueValueGroups = await Promise.all(dotNetObject.uniqueValueGroups.map(async i => await buildJsUniqueValueGroup(i))) as any;
        }
        if (hasValue(dotNetObject.uniqueValueInfos) && dotNetObject.uniqueValueInfos.length > 0) {
            let { buildJsUniqueValueInfo } = await import('./uniqueValueInfo');
            this.component.uniqueValueInfos = await Promise.all(dotNetObject.uniqueValueInfos.map(async i => await buildJsUniqueValueInfo(i))) as any;
        }
        if (hasValue(dotNetObject.visualVariables) && dotNetObject.visualVariables.length > 0) {
            let { buildJsVisualVariable } = await import('./visualVariable');
            this.component.visualVariables = await Promise.all(dotNetObject.visualVariables.map(async i => await buildJsVisualVariable(i, this.layerId, this.viewId))) as any;
        }

        if (hasValue(dotNetObject.defaultLabel)) {
            this.component.defaultLabel = dotNetObject.defaultLabel;
        }
        if (hasValue(dotNetObject.field)) {
            this.component.field = dotNetObject.field;
        }
        if (hasValue(dotNetObject.field2)) {
            this.component.field2 = dotNetObject.field2;
        }
        if (hasValue(dotNetObject.field3)) {
            this.component.field3 = dotNetObject.field3;
        }
        if (hasValue(dotNetObject.fieldDelimiter)) {
            this.component.fieldDelimiter = dotNetObject.fieldDelimiter;
        }
        if (hasValue(dotNetObject.orderByClassesEnabled)) {
            this.component.orderByClassesEnabled = dotNetObject.orderByClassesEnabled;
        }
        if (hasValue(dotNetObject.valueExpression)) {
            this.component.valueExpression = dotNetObject.valueExpression;
        }
        if (hasValue(dotNetObject.valueExpressionTitle)) {
            this.component.valueExpressionTitle = dotNetObject.valueExpressionTitle;
        }
    }
    
    async getUniqueValueInfo(graphic: any): Promise<any> {
        let jsGraphic: any;
        if (!Pro) {
            jsGraphic = null;
        } else {
            try {
                // @ts-ignore GeoBlazor Pro only
                let { buildJsGraphic } = await import('./graphic');
                jsGraphic = buildJsGraphic(graphic) as any;
            } catch (e) {
                console.error(`Pro functionality not available in GeoBlazor Core. ${e}`);
                jsGraphic = null;
            }
        }
        return await this.component.getUniqueValueInfo(jsGraphic);
    }

    async removeUniqueValueInfo(value: any): Promise<void> {
        this.component.removeUniqueValueInfo(value);
    }

    // region properties
    
    async getAuthoringInfo(): Promise<any> {
        if (!hasValue(this.component.authoringInfo)) {
            return null;
        }
        
        let { buildDotNetAuthoringInfo } = await import('./authoringInfo');
        return await buildDotNetAuthoringInfo(this.component.authoringInfo);
    }
    
    async setAuthoringInfo(value: any): Promise<void> {
        let { buildJsAuthoringInfo } = await import('./authoringInfo');
        this.component.authoringInfo = await  buildJsAuthoringInfo(value);
    }
    
    async getBackgroundFillSymbol(): Promise<any> {
        if (!hasValue(this.component.backgroundFillSymbol)) {
            return null;
        }
        
        let { buildDotNetFillSymbol } = await import('./fillSymbol');
        return await buildDotNetFillSymbol(this.component.backgroundFillSymbol);
    }
    
    async setBackgroundFillSymbol(value: any): Promise<void> {
        let { buildJsFillSymbol } = await import('./fillSymbol');
        this.component.backgroundFillSymbol = await  buildJsFillSymbol(value);
    }
    
    getDefaultLabel(): any {
        if (!hasValue(this.component.defaultLabel)) {
            return null;
        }
        
        return generateSerializableJson(this.component.defaultLabel);
    }
    
    setDefaultLabel(value: any): void {
        this.component.defaultLabel = JSON.parse(value);
    }
    
    async getDefaultSymbol(): Promise<any> {
        if (!hasValue(this.component.defaultSymbol)) {
            return null;
        }
        
        let { buildDotNetSymbol } = await import('./symbol');
        return buildDotNetSymbol(this.component.defaultSymbol);
    }
    
    async setDefaultSymbol(value: any): Promise<void> {
        let { buildJsSymbol } = await import('./symbol');
        this.component.defaultSymbol =  buildJsSymbol(value);
    }
    
    getField(): any {
        if (!hasValue(this.component.field)) {
            return null;
        }
        
        return generateSerializableJson(this.component.field);
    }
    
    setField(value: any): void {
        this.component.field = JSON.parse(value);
    }
    
    getField2(): any {
        if (!hasValue(this.component.field2)) {
            return null;
        }
        
        return generateSerializableJson(this.component.field2);
    }
    
    setField2(value: any): void {
        this.component.field2 = JSON.parse(value);
    }
    
    getField3(): any {
        if (!hasValue(this.component.field3)) {
            return null;
        }
        
        return generateSerializableJson(this.component.field3);
    }
    
    setField3(value: any): void {
        this.component.field3 = JSON.parse(value);
    }
    
    getFieldDelimiter(): any {
        if (!hasValue(this.component.fieldDelimiter)) {
            return null;
        }
        
        return generateSerializableJson(this.component.fieldDelimiter);
    }
    
    setFieldDelimiter(value: any): void {
        this.component.fieldDelimiter = JSON.parse(value);
    }
    
    async getLegendOptions(): Promise<any> {
        if (!hasValue(this.component.legendOptions)) {
            return null;
        }
        
        let { buildDotNetUniqueValueRendererLegendOptions } = await import('./uniqueValueRendererLegendOptions');
        return await buildDotNetUniqueValueRendererLegendOptions(this.component.legendOptions);
    }
    
    async setLegendOptions(value: any): Promise<void> {
        let { buildJsUniqueValueRendererLegendOptions } = await import('./uniqueValueRendererLegendOptions');
        this.component.legendOptions = await  buildJsUniqueValueRendererLegendOptions(value);
    }
    
    async getUniqueValueGroups(): Promise<any> {
        if (!hasValue(this.component.uniqueValueGroups)) {
            return null;
        }
        
        let { buildDotNetUniqueValueGroup } = await import('./uniqueValueGroup');
        return await Promise.all(this.component.uniqueValueGroups!.map(async i => await buildDotNetUniqueValueGroup(i)));
    }
    
    async setUniqueValueGroups(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.component.uniqueValueGroups = [];
        }
        let { buildJsUniqueValueGroup } = await import('./uniqueValueGroup');
        this.component.uniqueValueGroups = await Promise.all(value.map(async i => await buildJsUniqueValueGroup(i))) as any;
    }
    
    async getUniqueValueInfos(): Promise<any> {
        if (!hasValue(this.component.uniqueValueInfos)) {
            return null;
        }
        
        let { buildDotNetUniqueValueInfo } = await import('./uniqueValueInfo');
        return await Promise.all(this.component.uniqueValueInfos!.map(async i => await buildDotNetUniqueValueInfo(i)));
    }
    
    async setUniqueValueInfos(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.component.uniqueValueInfos = [];
        }
        let { buildJsUniqueValueInfo } = await import('./uniqueValueInfo');
        this.component.uniqueValueInfos = await Promise.all(value.map(async i => await buildJsUniqueValueInfo(i))) as any;
    }
    
    getValueExpression(): any {
        if (!hasValue(this.component.valueExpression)) {
            return null;
        }
        
        return generateSerializableJson(this.component.valueExpression);
    }
    
    setValueExpression(value: any): void {
        this.component.valueExpression = JSON.parse(value);
    }
    
    getValueExpressionTitle(): any {
        if (!hasValue(this.component.valueExpressionTitle)) {
            return null;
        }
        
        return generateSerializableJson(this.component.valueExpressionTitle);
    }
    
    setValueExpressionTitle(value: any): void {
        this.component.valueExpressionTitle = JSON.parse(value);
    }
    
    async getVisualVariables(): Promise<any> {
        if (!hasValue(this.component.visualVariables)) {
            return null;
        }
        
        let { buildDotNetVisualVariable } = await import('./visualVariable');
        return await Promise.all(this.component.visualVariables!.map(async i => await buildDotNetVisualVariable(i)));
    }
    
    async setVisualVariables(value: any): Promise<void> {
        if (!hasValue(value)) {
            this.component.visualVariables = [];
        }
        let { buildJsVisualVariable } = await import('./visualVariable');
        this.component.visualVariables = await Promise.all(value.map(async i => await buildJsVisualVariable(i, this.layerId, this.viewId))) as any;
    }
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsUniqueValueRendererGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let properties: any = {};
    if (hasValue(dotNetObject.authoringInfo)) {
        let { buildJsAuthoringInfo } = await import('./authoringInfo');
        properties.authoringInfo = await buildJsAuthoringInfo(dotNetObject.authoringInfo) as any;
    }
    if (hasValue(dotNetObject.backgroundFillSymbol)) {
        let { buildJsFillSymbol } = await import('./fillSymbol');
        properties.backgroundFillSymbol = await buildJsFillSymbol(dotNetObject.backgroundFillSymbol) as any;
    }
    if (hasValue(dotNetObject.defaultSymbol)) {
        let { buildJsSymbol } = await import('./symbol');
        properties.defaultSymbol = buildJsSymbol(dotNetObject.defaultSymbol) as any;
    }
    if (hasValue(dotNetObject.legendOptions)) {
        let { buildJsUniqueValueRendererLegendOptions } = await import('./uniqueValueRendererLegendOptions');
        properties.legendOptions = await buildJsUniqueValueRendererLegendOptions(dotNetObject.legendOptions) as any;
    }
    if (hasValue(dotNetObject.uniqueValueGroups) && dotNetObject.uniqueValueGroups.length > 0) {
        let { buildJsUniqueValueGroup } = await import('./uniqueValueGroup');
        properties.uniqueValueGroups = await Promise.all(dotNetObject.uniqueValueGroups.map(async i => await buildJsUniqueValueGroup(i))) as any;
    }
    if (hasValue(dotNetObject.uniqueValueInfos) && dotNetObject.uniqueValueInfos.length > 0) {
        let { buildJsUniqueValueInfo } = await import('./uniqueValueInfo');
        properties.uniqueValueInfos = await Promise.all(dotNetObject.uniqueValueInfos.map(async i => await buildJsUniqueValueInfo(i))) as any;
    }
    if (hasValue(dotNetObject.visualVariables) && dotNetObject.visualVariables.length > 0) {
        let { buildJsVisualVariable } = await import('./visualVariable');
        properties.visualVariables = await Promise.all(dotNetObject.visualVariables.map(async i => await buildJsVisualVariable(i, layerId, viewId))) as any;
    }

    if (hasValue(dotNetObject.defaultLabel)) {
        properties.defaultLabel = dotNetObject.defaultLabel;
    }
    if (hasValue(dotNetObject.field)) {
        properties.field = dotNetObject.field;
    }
    if (hasValue(dotNetObject.field2)) {
        properties.field2 = dotNetObject.field2;
    }
    if (hasValue(dotNetObject.field3)) {
        properties.field3 = dotNetObject.field3;
    }
    if (hasValue(dotNetObject.fieldDelimiter)) {
        properties.fieldDelimiter = dotNetObject.fieldDelimiter;
    }
    if (hasValue(dotNetObject.orderByClassesEnabled)) {
        properties.orderByClassesEnabled = dotNetObject.orderByClassesEnabled;
    }
    if (hasValue(dotNetObject.valueExpression)) {
        properties.valueExpression = dotNetObject.valueExpression;
    }
    if (hasValue(dotNetObject.valueExpressionTitle)) {
        properties.valueExpressionTitle = dotNetObject.valueExpressionTitle;
    }
    let jsUniqueValueRenderer = new UniqueValueRenderer(properties);

    let { default: UniqueValueRendererWrapper } = await import('./uniqueValueRenderer');
    let uniqueValueRendererWrapper = new UniqueValueRendererWrapper(jsUniqueValueRenderer);
    uniqueValueRendererWrapper.geoBlazorId = dotNetObject.id;
    uniqueValueRendererWrapper.viewId = viewId;
    uniqueValueRendererWrapper.layerId = layerId;
    
    jsObjectRefs[dotNetObject.id] = uniqueValueRendererWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsUniqueValueRenderer;
    
    return jsUniqueValueRenderer;
}


export async function buildDotNetUniqueValueRendererGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetUniqueValueRenderer: any = {};
    
    if (hasValue(jsObject.authoringInfo)) {
        let { buildDotNetAuthoringInfo } = await import('./authoringInfo');
        dotNetUniqueValueRenderer.authoringInfo = await buildDotNetAuthoringInfo(jsObject.authoringInfo);
    }
    
    if (hasValue(jsObject.backgroundFillSymbol)) {
        let { buildDotNetFillSymbol } = await import('./fillSymbol');
        dotNetUniqueValueRenderer.backgroundFillSymbol = await buildDotNetFillSymbol(jsObject.backgroundFillSymbol);
    }
    
    if (hasValue(jsObject.defaultSymbol)) {
        let { buildDotNetSymbol } = await import('./symbol');
        dotNetUniqueValueRenderer.defaultSymbol = buildDotNetSymbol(jsObject.defaultSymbol);
    }
    
    if (hasValue(jsObject.legendOptions)) {
        let { buildDotNetUniqueValueRendererLegendOptions } = await import('./uniqueValueRendererLegendOptions');
        dotNetUniqueValueRenderer.legendOptions = await buildDotNetUniqueValueRendererLegendOptions(jsObject.legendOptions);
    }
    
    if (hasValue(jsObject.uniqueValueGroups)) {
        let { buildDotNetUniqueValueGroup } = await import('./uniqueValueGroup');
        dotNetUniqueValueRenderer.uniqueValueGroups = await Promise.all(jsObject.uniqueValueGroups.map(async i => await buildDotNetUniqueValueGroup(i)));
    }
    
    if (hasValue(jsObject.uniqueValueInfos)) {
        let { buildDotNetUniqueValueInfo } = await import('./uniqueValueInfo');
        dotNetUniqueValueRenderer.uniqueValueInfos = await Promise.all(jsObject.uniqueValueInfos.map(async i => await buildDotNetUniqueValueInfo(i)));
    }
    
    if (hasValue(jsObject.visualVariables)) {
        let { buildDotNetVisualVariable } = await import('./visualVariable');
        dotNetUniqueValueRenderer.visualVariables = await Promise.all(jsObject.visualVariables.map(async i => await buildDotNetVisualVariable(i)));
    }
    
    if (hasValue(jsObject.defaultLabel)) {
        dotNetUniqueValueRenderer.defaultLabel = jsObject.defaultLabel;
    }
    
    if (hasValue(jsObject.field)) {
        dotNetUniqueValueRenderer.field = jsObject.field;
    }
    
    if (hasValue(jsObject.field2)) {
        dotNetUniqueValueRenderer.field2 = jsObject.field2;
    }
    
    if (hasValue(jsObject.field3)) {
        dotNetUniqueValueRenderer.field3 = jsObject.field3;
    }
    
    if (hasValue(jsObject.fieldDelimiter)) {
        dotNetUniqueValueRenderer.fieldDelimiter = jsObject.fieldDelimiter;
    }
    
    if (hasValue(jsObject.orderByClassesEnabled)) {
        dotNetUniqueValueRenderer.orderByClassesEnabled = jsObject.orderByClassesEnabled;
    }
    
    if (hasValue(jsObject.type)) {
        dotNetUniqueValueRenderer.type = removeCircularReferences(jsObject.type);
    }
    
    if (hasValue(jsObject.valueExpression)) {
        dotNetUniqueValueRenderer.valueExpression = jsObject.valueExpression;
    }
    
    if (hasValue(jsObject.valueExpressionTitle)) {
        dotNetUniqueValueRenderer.valueExpressionTitle = jsObject.valueExpressionTitle;
    }
    

    let geoBlazorId = lookupGeoBlazorId(jsObject);
    if (hasValue(geoBlazorId)) {
        dotNetUniqueValueRenderer.id = geoBlazorId;
    }

    return dotNetUniqueValueRenderer;
}

