import {getView} from "./testRunner.js";

export function assertHasContent(methodName) {
    let view = getView(methodName);
    let legendWidget = view.ui._components.find(c => c.widget.declaredClass === 'esri.widgets.Legend')?.widget;
    if (legendWidget?.activeLayerInfos?.items === undefined ||
        legendWidget?.activeLayerInfos?.items.length === 0) {
        throw new Error(`No legend content`);
    }
}