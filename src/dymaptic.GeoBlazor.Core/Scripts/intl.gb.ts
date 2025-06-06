// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import intl = __esri.intl;
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import {IPropertyWrapper} from './definitions';

export default class IntlGenerated implements IPropertyWrapper {
    public component: intl;
    public geoBlazorId: string | null = null;
    public viewId: string | null = null;
    public layerId: string | null = null;

    constructor(component: intl) {
        this.component = component;
    }
    
    // region methods
   
    unwrap() {
        return this.component;
    }
    

    async updateComponent(dotNetObject: any): Promise<void> {

    }
    
    async convertNumberFormatToIntlOptions(format: any): Promise<any> {
        return this.component.convertNumberFormatToIntlOptions(format);
    }

    async createJSONLoader(parameters: any): Promise<any> {
        return this.component.createJSONLoader(parameters);
    }

    async fetchMessageBundle(bundleId: any): Promise<any> {
        return await this.component.fetchMessageBundle(bundleId);
    }

    async formatDate(value: any,
        formatOptions: any): Promise<any> {
        return this.component.formatDate(value,
            formatOptions);
    }

    async formatDateOnly(value: any,
        options: any): Promise<any> {
        return this.component.formatDateOnly(value,
            options);
    }

    async formatNumber(value: any,
        formatOptions: any): Promise<any> {
        return this.component.formatNumber(value,
            formatOptions);
    }

    async formatTimeOnly(value: any,
        options: any): Promise<any> {
        return this.component.formatTimeOnly(value,
            options);
    }

    async formatTimestamp(value: any,
        options: any): Promise<any> {
        return this.component.formatTimestamp(value,
            options);
    }

    async getLocale(): Promise<any> {
        return this.component.getLocale();
    }

    async normalizeMessageBundleLocale(locale: any): Promise<any> {
        return this.component.normalizeMessageBundleLocale(locale);
    }

    async onLocaleChange(callback: any): Promise<any> {
        return this.component.onLocaleChange(callback);
    }

    async prefersRTL(locale: any): Promise<any> {
        return this.component.prefersRTL(locale);
    }

    async registerMessageBundleLoader(loader: any): Promise<any> {
        return this.component.registerMessageBundleLoader(loader);
    }

    async setLocale(locale: any): Promise<void> {
        this.component.setLocale(locale);
    }

    async substitute(template: any,
        data: any,
        options: any): Promise<any> {
        let { buildJsSubstituteOptions } = await import('./substituteOptions');
        let jsOptions = await buildJsSubstituteOptions(options, this.layerId, this.viewId) as any;
        return this.component.substitute(template,
            data,
            jsOptions);
    }

    // region properties
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
}


export async function buildJsIntlGenerated(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsintl: any = {};


    let { default: IntlWrapper } = await import('./intl');
    let intlWrapper = new IntlWrapper(jsintl);
    intlWrapper.geoBlazorId = dotNetObject.id;
    intlWrapper.viewId = viewId;
    intlWrapper.layerId = layerId;
    
    let jsObjectRef = DotNet.createJSObjectReference(intlWrapper);
    jsObjectRefs[dotNetObject.id] = intlWrapper;
    arcGisObjectRefs[dotNetObject.id] = jsintl;
    
    return jsintl;
}


export async function buildDotNetIntlGenerated(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetIntl: any = {};
    

    return dotNetIntl;
}

