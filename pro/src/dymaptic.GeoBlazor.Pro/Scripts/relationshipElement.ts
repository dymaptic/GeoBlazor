import { buildJsRelationshipElementGenerated } from './relationshipElement.gb';
import { buildDotNetRelationshipElementGenerated } from './relationshipElement.gb';

export function buildDotNetRelationshipElement(jsObject: any): any {
    return buildDotNetRelationshipElementGenerated(jsObject);

}

export function buildJsRelationshipElement(dotNetObject: any): any {
    return buildJsRelationshipElementGenerated(dotNetObject);
}
