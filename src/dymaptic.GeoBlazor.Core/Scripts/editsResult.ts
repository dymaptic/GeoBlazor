import {hasValue} from "./arcGisJsInterop";
import {buildDotNetGraphic} from "./graphic";
import {buildDotNetSpatialReference} from "./spatialReference";

export function buildDotNetEditsResult(jsResult: any, layerId: string): any {
    let dnResult: any = {
        addFeatureResults: jsResult.addFeatureResults,
        deleteFeatureResults: jsResult.deleteFeatureResults,
        updateFeatureResults: jsResult.updateFeatureResults,
        addAttachmentResults: jsResult.addAttachmentResults,
        updateAttachmentResults: jsResult.updateAttachmentResults,
        deleteAttachmentResults: jsResult.deleteAttachmentResults
    };

    if (hasValue(jsResult.editedFeatureResults)) {
        dnResult.editedFeatureResults = jsResult.editedFeatureResults!.map(r => {
            let dnEditedFeatureResult: any = {
                layerId: r.layerId
            };
            if (hasValue(r.editedFeatures.adds)) {
                dnEditedFeatureResult.adds = r.editedFeatures.adds!.map(f => buildDotNetGraphic(f, layerId, null));
            }
            if (hasValue(r.editedFeatures.deletes)) {
                dnEditedFeatureResult.deletes = r.editedFeatures.deletes!.map(f => buildDotNetGraphic(f, layerId, null));
            }
            if (hasValue(r.editedFeatures.updates)) {
                dnEditedFeatureResult.updates = [];
                for (let i = 0; i < r.editedFeatures.updates!.length; i++) {
                    let jsFeature = r.editedFeatures.updates![i];
                    dnEditedFeatureResult.updates.push({
                        original: jsFeature.original?.map(f => buildDotNetGraphic(f, layerId, null)),
                        current: jsFeature.current?.map(f => buildDotNetGraphic(f, layerId, null))
                    });
                }
            }
            if (hasValue(r.editedFeatures.spatialReference)) {
                dnEditedFeatureResult.spatialReference = buildDotNetSpatialReference(r.editedFeatures.spatialReference!);
            }

            return dnEditedFeatureResult;
        });
    }
    return dnResult;
}