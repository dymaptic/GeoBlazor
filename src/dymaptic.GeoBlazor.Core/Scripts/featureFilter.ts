// override generated code in this file
import FeatureFilterGenerated from './featureFilter.gb';
import FeatureFilter from '@arcgis/core/layers/support/FeatureFilter';
import {DotNetQuery} from "./definitions";
import {buildDotNetQuery} from "./query";

export default class FeatureFilterWrapper extends FeatureFilterGenerated {

    constructor(component: FeatureFilter) {
        super(component);
    }

    async createQuery(): Promise<DotNetQuery> {
        let jsQuery = this.component.createQuery();
        return await buildDotNetQuery(jsQuery, this.viewId);
    }
}

export async function buildJsFeatureFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureFilterGenerated} = await import('./featureFilter.gb');
    return await buildJsFeatureFilterGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureFilter(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetFeatureFilterGenerated} = await import('./featureFilter.gb');
    return await buildDotNetFeatureFilterGenerated(jsObject, viewId);
}
