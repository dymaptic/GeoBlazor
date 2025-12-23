import {hasValue} from './geoBlazorCore';
import {buildJsEffect} from "./effect";

export async function buildJsFeatureEffect(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }
    
    let featureEffect: any = {};
    
    //if there is a single effect, it's a string, if there are effects based on scale it's an array and has scale and value.
    if (hasValue(dotNetObject.excludedEffect)) {
        if (dotNetObject.excludedEffect.length === 1) {
            featureEffect.excludedEffect = buildJsEffect(dotNetObject.excludedEffect[0]);
        } else {
            featureEffect.excludedEffect = dotNetObject.excludedEffect.map(buildJsEffect);
        }
    }
    featureEffect.excludedLabelsVisible = dotNetObject.excludedLabelsVisible ?? undefined;
    if (hasValue(dotNetObject?.filter)) {
        let { buildJsFeatureFilter } = await import('./featureFilter');
        featureEffect.filter = await buildJsFeatureFilter(dotNetObject.filter, layerId, viewId);
    }

    if (dotNetObject.includedEffect != null) {
        if (dotNetObject.includedEffect.length === 1) {
            featureEffect.includedEffect = buildJsEffect(dotNetObject.includedEffect[0]);
        } else {
            featureEffect.includedEffect = dotNetObject.includedEffect.map(buildJsEffect);
        }
    }

    if (hasValue(dotNetObject.excludedLabelsVisible)) {
        featureEffect.excludedLabelsVisible = dotNetObject.excludedLabelsVisible;
    }
    
    return featureEffect;
}     

export async function buildDotNetFeatureEffect(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureEffectGenerated } = await import('./featureEffect.gb');
    return await buildDotNetFeatureEffectGenerated(jsObject, layerId, viewId);
}
