// override generated code in this file
import ThemeGenerated from './theme.gb';
import Theme from '@arcgis/core/views/Theme';

export default class ThemeWrapper extends ThemeGenerated {

    constructor(component: Theme) {
        super(component);
    }
    
}              
export async function buildJsTheme(dotNetObject: any): Promise<any> {
    let { buildJsThemeGenerated } = await import('./theme.gb');
    return await buildJsThemeGenerated(dotNetObject);
}
export async function buildDotNetTheme(jsObject: any): Promise<any> {
    let { buildDotNetThemeGenerated } = await import('./theme.gb');
    return await buildDotNetThemeGenerated(jsObject);
}
