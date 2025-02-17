// override generated code in this file
import {buildDotNetAlgorithmicColorRamp, buildJsAlgorithmicColorRamp } from './algorithmicColorRamp';
import {buildDotNetMultipartColorRamp, buildJsMultipartColorRamp} from './multipartColorRamp';


export function buildJsColorRamp(dotNetObject: any): any {
    switch (dotNetObject?.type) {
        case 'multipart':
            return buildJsMultipartColorRamp(dotNetObject);
        case 'algorithmic':
            return buildJsAlgorithmicColorRamp(dotNetObject);
        default:
            throw new Error(`Unsupported color ramp type: ${dotNetObject?.type}`);
    }
}     

export function buildDotNetColorRamp(jsObject: any): any {
    switch (jsObject?.type) {
        case 'multipart':
            return buildDotNetMultipartColorRamp(jsObject);
        case 'algorithmic':
            return buildDotNetAlgorithmicColorRamp(jsObject);
        default:
            throw new Error(`Unsupported color ramp type: ${jsObject?.type}`);
    }
}
