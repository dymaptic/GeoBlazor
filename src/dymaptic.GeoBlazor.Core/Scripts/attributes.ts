import {hasValue} from "./arcGisJsInterop";

export function buildJsAttributes(attributes: any): any {
    if (hasValue(attributes)) {
        if (attributes instanceof Array) {
            let graphicAttributes = {};
            attributes.forEach((attr: any) => {
                switch (attr.valueType.toLowerCase().replace('system.', '')) {
                    case "number":
                    case "int32":
                    case "int64":
                    case "double":
                    case "single":
                    case "float":
                    case "int":
                        graphicAttributes[attr.key] = Number(attr.value);
                        break;
                    case "boolean":
                        graphicAttributes[attr.key] = attr.value.toLowerCase() === "true";
                        break;
                    case "object":
                        graphicAttributes[attr.key] = JSON.stringify(attr.value, null, 2);
                        break;
                    default:
                        graphicAttributes[attr.key] = attr.value;
                }
            });
            return graphicAttributes;
        } else {
            return attributes;
        }
    }
}