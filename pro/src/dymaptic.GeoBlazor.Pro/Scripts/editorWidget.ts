import Editor from '@arcgis/core/widgets/Editor';
import EditorWidgetGenerated from './editorWidget.gb';
import FeatureLayerWrapper from "./featureLayer";
import * as Core from './geoBlazorCore';
import FeatureLayer from "@arcgis/core/layers/FeatureLayer";
import EditorLayerInfo = __esri.EditorLayerInfo;
import { buildJsGraphic } from './graphic';
import Graphic from "@arcgis/core/Graphic";
import CreateFeaturesCreationInfo = __esri.CreateFeaturesCreationInfo;

export default class EditorWidgetWrapper extends EditorWidgetGenerated {
    
    constructor(widget: Editor) {
        super(widget);
    }
    
    async getActiveWorkflow(): Promise<any> {
        let { buildDotNetIEditorWidgetActiveWorkflow } = await import('./iEditorWidgetActiveWorkflow');
        return await buildDotNetIEditorWidgetActiveWorkflow(this.widget.activeWorkflow, this.layerId, this.viewId);
    }
    
    async setLayerInfos(dotNetLayerInfos: any) {
        let layerInfos: EditorLayerInfo[] = [];
        for (let i = 0; i < dotNetLayerInfos.length; i++) {
            let layerInfo : EditorLayerInfo = {
                layer: Core.arcGisObjectRefs[dotNetLayerInfos[i].id] as FeatureLayer
            };
            if (dotNetLayerInfos[i].formTemplate !== undefined &&
                dotNetLayerInfos[i].formTemplate !== null) {
                let { buildJsFormTemplate } = await import('./formTemplate');
                layerInfo.formTemplate = await buildJsFormTemplate(dotNetLayerInfos[i].formTemplate, this.layerId, this.viewId);
            }
            layerInfos.push(layerInfo);
        }
        this.widget.layerInfos = layerInfos;
    }
    
    async cancelWorkflow() {
        await this.widget.cancelWorkflow();
    }
    
    async deleteFeatures(): Promise<void> {
        await this.widget.deleteFeatures();
    }
    
    async deleteFeatureFromWorkflow() {
        await this.widget.deleteFeatureFromWorkflow();
    }
    
    async startCreateFeaturesWorkflowAtFeatureCreation(featureLayerWrapper: FeatureLayerWrapper, template: any) {
        let creationInfo: CreateFeaturesCreationInfo = {
            layer: featureLayerWrapper.layer,
            template: template
        };
        await this.widget.startCreateFeaturesWorkflowAtFeatureCreation(creationInfo);
    }
    
    async startCreateFeaturesWorkflowAtFeatureTypeSelection() {
        await this.widget.startCreateFeaturesWorkflowAtFeatureTypeSelection();
    }
    
    async startUpdateFeaturesWorkflow(features: any[]): Promise<void> {
        let jsFeatures: Graphic[] = features.map(f => buildJsGraphic(f) as Graphic);
        await this.widget.startUpdateFeaturesWorkflow(jsFeatures);
    }
    
    async startUpdateWorkflowAtFeatureEdit(dotNetFeature: any) {
        let feature = buildJsGraphic(dotNetFeature);
        await this.widget.startUpdateWorkflowAtFeatureEdit(feature!);
    }
    
    async startUpdateWorkflowAtFeatureSelection() {
        await this.widget.startUpdateWorkflowAtFeatureSelection();
    }
    
    async startUpdateWorkflowAtMultipleFeatureSelection(dotNetFeatures: any[]) {
        let features = dotNetFeatures.map(dnf => buildJsGraphic(dnf) as Graphic);
        await this.widget.startUpdateWorkflowAtMultipleFeatureSelection(features);
    }
}
export async function buildJsEditorWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorWidgetGenerated } = await import('./editorWidget.gb');
    return await buildJsEditorWidgetGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetEditorWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetEditorWidgetGenerated } = await import('./editorWidget.gb');
    return await buildDotNetEditorWidgetGenerated(jsObject, layerId, viewId);
}
