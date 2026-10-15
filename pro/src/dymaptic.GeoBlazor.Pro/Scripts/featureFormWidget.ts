import FeatureForm from '@arcgis/core/widgets/FeatureForm';
import FeatureFormWidgetGenerated from './featureFormWidget.gb';
import {DotNetGraphic} from "./definitions";
import {buildJsStreamReference, hasValue, lookupJsGraphicById} from './geoBlazorCore';
import { buildJsGraphic } from "./graphic";


export default class FeatureFormWidgetWrapper extends FeatureFormWidgetGenerated {
    
    constructor(widget: FeatureForm) {
        super(widget);
    }
    
    setFeature(feature: DotNetGraphic, layerId: string | null, viewId: string) {
        if (feature === null) {
            return;
        }
        let graphic = lookupJsGraphicById(feature.id as string, layerId, viewId);
        
        if (graphic === null) {
            graphic = buildJsGraphic(feature);
        }
        this.widget.feature = graphic!;
    }
    
    getValues(): any {
        const jsValues = this.widget.getValues();
        const fields = this.widget.layer?.fields;
        return Object.keys(jsValues).map(attr => {
            const typedValue = jsValues[attr];
            let valueType: string | undefined = undefined;
            const field = fields?.find(f => f.name === attr);
            if (hasValue(field)) {
                valueType = field!.type;
            }
            valueType ??= Object.prototype.toString.call(typedValue);
            return {
                key: attr,
                value: typedValue?.toString(),
                valueType: valueType
            }
        });
    }
    
    submit(): void {
        this.widget.submit();
    }
}
export async function buildJsFeatureFormWidget(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureFormWidgetGenerated } = await import('./featureFormWidget.gb');
    let jsObject = await buildJsFeatureFormWidgetGenerated(dotNetObject, layerId, viewId);
    
    if (hasValue(dotNetObject.hasValueChangeListener) && dotNetObject.hasValueChangeListener) {
        let lastUpdateCall: number = 0;
        let eventRateLimit = dotNetObject.eventRateLimitInMilliseconds;
        jsObject.on('value-change', async (evt: any) => {
            if (evt.state === 'active') {
                let now = Date.now();
                if (eventRateLimit !== undefined && eventRateLimit !== null &&
                    lastUpdateCall + eventRateLimit > now) {
                    return;
                }
                lastUpdateCall = now;
            }
            
            let { buildDotNetFeatureFormValueChangeEvent } = await import('./featureFormValueChangeEvent');
            let dnEvent = await buildDotNetFeatureFormValueChangeEvent(evt, layerId, viewId);
            let streamRef = buildJsStreamReference(dnEvent ?? {});
            await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsValueChange', streamRef);
        });
    }

    if (hasValue(dotNetObject.hasSubmitListener) && dotNetObject.hasSubmitListener) {
        jsObject.on('submit', (evt: any) => {
            // requestAnimationFrame was added here as a workaround to https://github.com/dymaptic/GeoBlazor/issues/466
            requestAnimationFrame(async () => {
                let streamRef = buildJsStreamReference(evt ?? {});
                await dotNetObject.dotNetComponentReference.invokeMethodAsync('OnJsSubmit', streamRef);
            });
        });
    }
    
    return jsObject;
}
export async function buildDotNetFeatureFormWidget(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureFormWidgetGenerated } = await import('./featureFormWidget.gb');
    return await buildDotNetFeatureFormWidgetGenerated(jsObject, layerId, viewId);
}
