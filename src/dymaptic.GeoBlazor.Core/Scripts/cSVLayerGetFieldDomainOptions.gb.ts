// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file


import CSVLayerGetFieldDomainOptions = __esri.CSVLayerGetFieldDomainOptions;
import {IPropertyWrapper} from './definitions';
import {createGeoBlazorObject} from './arcGisJsInterop';

export default class CSVLayerGetFieldDomainOptionsGenerated implements IPropertyWrapper {
    public component: CSVLayerGetFieldDomainOptions;

    constructor(component: CSVLayerGetFieldDomainOptions) {
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
    
    getProperty(prop: string): any {
        return this.component[prop];
    }
    
    setProperty(prop: string, value: any): void {
        this.component[prop] = value;
    }
    
    addToProperty(prop: string, value: any): void {
        if (Array.isArray(value)) {
            this.component[prop].addMany(value);
        } else {
            this.component[prop].add(value);
        }
    }
    
    removeFromProperty(prop: string, value: any): any {
        if (Array.isArray(value)) {
            this.component[prop].removeMany(value);
        } else {
            this.component[prop].remove(value);
        }
    }
}
