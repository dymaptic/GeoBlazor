// override generated code in this file
import TopologyValidationJobInfoGenerated from './topologyValidationJobInfo.gb';
import TopologyValidationJobInfo from '@arcgis/core/networks/support/TopologyValidationJobInfo';

export default class TopologyValidationJobInfoWrapper extends TopologyValidationJobInfoGenerated {

    constructor(component: TopologyValidationJobInfo) {
        super(component);
    }
    
}

export async function buildJsTopologyValidationJobInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTopologyValidationJobInfoGenerated } = await import('./topologyValidationJobInfo.gb');
    return await buildJsTopologyValidationJobInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTopologyValidationJobInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTopologyValidationJobInfoGenerated } = await import('./topologyValidationJobInfo.gb');
    return await buildDotNetTopologyValidationJobInfoGenerated(jsObject, layerId, viewId);
}
