// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .ts file.
import { arcGisObjectRefs, jsObjectRefs, hasValue } from './arcGisJsInterop';
import { buildDotNetISceneViewEnvironmentWeather } from './iSceneViewEnvironmentWeather';

export async function buildJsISceneViewEnvironmentWeatherGenerated(dotNetObject: any): Promise<any> {
    if (!hasValue(dotNetObject)) {
        return null;
    }

    let jsSceneViewEnvironmentWeather: any = {};

    
    jsObjectRefs[dotNetObject.id] = jsSceneViewEnvironmentWeather;
    arcGisObjectRefs[dotNetObject.id] = jsSceneViewEnvironmentWeather;
    
    return jsSceneViewEnvironmentWeather;
}


export async function buildDotNetISceneViewEnvironmentWeatherGenerated(jsObject: any): Promise<any> {
    if (!hasValue(jsObject)) {
        return null;
    }
    
    let dotNetISceneViewEnvironmentWeather: any = {};
    

    return dotNetISceneViewEnvironmentWeather;
}

