
export async function buildJsSharedTemplateMetaData(dotNetObject: any): Promise<any> {
    return {
        templateId: dotNetObject.templateId,
        type: dotNetObject.type
    }
}

export async function buildDotNetSharedTemplate(jsObject: any): Promise<any> {
    return {
        templateId: jsObject.templateId,
        type: jsObject.type
    }
}
