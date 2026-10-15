// override generated code in this file
import * as popupTemplateGenerator from "@arcgis/core/smartMapping/popup/templates.js";
import * as clusterPopupTemplateGenerator from "@arcgis/core/smartMapping/popup/clusters.js";
import {arcGisObjectRefs} from './geoBlazorCore';

export default class PopupTemplateGeneratorWrapper {
    private dotNetRef: any;
    
    constructor(dotNetRef: any) {
        this.dotNetRef = dotNetRef;
    }

    async getTemplates(params: any): Promise<any> {
        try {
            let { buildJsRenderer } = await import('./renderer');
            let results = await popupTemplateGenerator.getTemplates({
                layer: arcGisObjectRefs[params.layer.id] as any,
                renderer: await buildJsRenderer(params.renderer, params.layer.id, params.layer.viewId) ?? undefined
            });
            if (!results) {
                return results;
            }
            
            return {
                primaryTemplate: await this.buildTemplateResult(results.primaryTemplate),
                secondaryTemplates: results.secondaryTemplates?.map(this.buildTemplateResult)
            }
        } catch (error) {
            console.error(error);
            throw error;
        }
    }

    async getClusterTemplates(params: any) {
        let { buildJsRenderer } = await import('./renderer');
        let results = await clusterPopupTemplateGenerator.getTemplates({
            layer: arcGisObjectRefs[params.layer.id] as any,
            renderer: await buildJsRenderer(params.renderer, params.layer.id, params.layer.viewId) ?? undefined
        });
        if (!results) {
            return results;
        }
        return {
            primaryTemplate: await this.buildTemplateResult(results.primaryTemplate),
            secondaryTemplates: await Promise.all(results.secondaryTemplates?.map(async t => await this.buildTemplateResult(t)))
        }
    }

    async buildTemplateResult(result: __esri.Template): Promise<any> {
        let { buildDotNetPopupTemplate } = await import('./popupTemplate');
        return {
            name: result.name,
            title: result.title,
            value: await buildDotNetPopupTemplate(result.value)
        }
    }
}

export async function buildJsPopupTemplateGenerator(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // not used
}     

export async function buildDotNetPopupTemplateGenerator(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    // not used
}
