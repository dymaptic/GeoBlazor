// override generated code in this file

import {buildJsActionButton} from "./actionButton";
import {buildJsActionToggle} from "./actionToggle";

export function buildJsActionBase(dotNetObject: any): any {
    let jsAction: any = {};
    switch (dotNetObject?.type) {
        case 'button':
            jsAction = buildJsActionButton(dotNetObject);
            
            break;
        case 'toggle':
            jsAction = buildJsActionToggle(dotNetObject);
            
            break;
        default:
            throw new Error(`Unsupported action type: ${dotNetObject?.type}`);
    }
    
    return jsAction;
}

export async function buildDotNetActionBase(jsObject: any): Promise<any> {
    switch (jsObject?.type) {
        case 'button':
            let {buildDotNetActionButton} = await import('./actionButton');
            return await buildDotNetActionButton(jsObject);
        case 'toggle':
            let {buildDotNetActionToggle} = await import('./actionToggle');
            return await buildDotNetActionToggle(jsObject);
        default:
            throw new Error(`Unsupported action type: ${jsObject?.type}`);
    }
}
