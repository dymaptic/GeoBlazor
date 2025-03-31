// override generated code in this file
import FeaturesViewModelGenerated from './featuresViewModel.gb';
import FeaturesViewModel from '@arcgis/core/widgets/Features/FeaturesViewModel';
import {hasValue} from "./arcGisJsInterop";
import {buildJsWidget} from "./widget";
import Widget from "@arcgis/core/widgets/Widget";

export default class FeaturesViewModelWrapper extends FeaturesViewModelGenerated {

    constructor(component: FeaturesViewModel) {
        super(component);
    }

    async setSpatialReference(spatialReference: any): Promise<void> {
        let {buildJsSpatialReference} = await import('./spatialReference');
        this.component.spatialReference = buildJsSpatialReference(spatialReference) as any;
    }
}

// CodeGenerationIgnore
export async function buildJsFeaturesViewModel(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsFeaturesViewModelGenerated } = await import('./featuresViewModel.gb');
    let jsViewModel = await buildJsFeaturesViewModelGenerated(dotNetObject);
    if (hasValue(dotNetObject.widgetContent)) {
        const widgetContent = await buildJsWidget(dotNetObject.widgetContent, dotNetObject.widgetContent.layerId, viewId);
        if (hasValue(widgetContent)) {
            jsViewModel.content = widgetContent as Widget;
        }
    }

    if (hasValue(dotNetObject.htmlContent)) {
        jsViewModel.content = dotNetObject.htmlContent;
    }

    if (hasValue(dotNetObject.stringContent)) {
        jsViewModel.content = dotNetObject.stringContent;
    }
    
    return jsViewModel;
}     

export async function buildDotNetFeaturesViewModel(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesViewModelGenerated } = await import('./featuresViewModel.gb');
    return await buildDotNetFeaturesViewModelGenerated(jsObject);
}
