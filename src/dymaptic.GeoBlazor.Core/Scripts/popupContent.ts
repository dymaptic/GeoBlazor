// override generated code in this file
import PopupContentGenerated from './popupContent.gb';
import Content = __esri.Content;
import {
    DotNetAttachmentsPopupContent, DotNetExpressionPopupContent,
    DotNetFieldsPopupContent,
    DotNetMediaPopupContent,
    DotNetPopupContent,
    DotNetTextPopupContent
} from "./definitions";
import FieldsContent from "@arcgis/core/popup/content/FieldsContent";
import TextContent from "@arcgis/core/popup/content/TextContent";
import MediaContent from "@arcgis/core/popup/content/MediaContent";
import MediaInfo from "@arcgis/core/popup/content/mixins/MediaInfo";
import AttachmentsContent from "@arcgis/core/popup/content/AttachmentsContent";
import ExpressionContent from "@arcgis/core/popup/content/ExpressionContent";

export default class PopupContentWrapper extends PopupContentGenerated {

    constructor(component: Content) {
        super(component);
    }
    
}

export async function buildJsPopupContent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupContentGenerated } = await import('./popupContent.gb');
    return await buildJsPopupContentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupContent(jsObject: any): Promise<any> {
    if (typeof jsObject === "string") {
        return null; // handled in `popupTemplate.ts`
    }
    
    let content = {
        type: jsObject.type
    } as DotNetPopupContent;

    switch (jsObject.type) {
        case "fields":
            let fieldsContent = content as DotNetFieldsPopupContent;
            let jsFieldsContent = jsObject as FieldsContent;
            let { buildDotNetFieldInfo } = await import('./fieldInfo');
            fieldsContent.fieldInfos = await Promise.all(jsFieldsContent.fieldInfos?.map(async f => await buildDotNetFieldInfo(f)));
            fieldsContent.title = (jsObject as FieldsContent).title;
            fieldsContent.description = (jsObject as FieldsContent).description;
            break;
        case "text":
            (content as DotNetTextPopupContent).text = (jsObject as TextContent).text;
            break;
        case "media":
            let mediaContent = content as DotNetMediaPopupContent;
            let jsMediaContent = jsObject as MediaContent;
            let { buildDotNetMediaInfo } = await import('./mediaInfo');
            if (jsMediaContent.mediaInfos instanceof MediaInfo) {
                mediaContent.mediaInfos = [await buildDotNetMediaInfo(jsMediaContent.mediaInfos as any)];
            } else {
                mediaContent.mediaInfos = await Promise.all((jsMediaContent.mediaInfos as MediaInfo[])?.map(async m => await buildDotNetMediaInfo(m)));
            }
            break;
        case "attachments":
            let attachmentsContent = content as DotNetAttachmentsPopupContent;
            let jsAttachmentsContent = jsObject as AttachmentsContent;
            attachmentsContent.description = jsAttachmentsContent.description;
            attachmentsContent.title = jsAttachmentsContent.title;
            attachmentsContent.displayType = jsAttachmentsContent.displayType;
            break;
        case "expression":
            let expressionContent = content as DotNetExpressionPopupContent;
            let jsExpressionContent = jsObject as ExpressionContent;
            let { buildDotNetElementExpressionInfo } = await import('./elementExpressionInfo');
            expressionContent.expressionInfo = await buildDotNetElementExpressionInfo(jsExpressionContent.expressionInfo);
            break;
    }

    return content;
}