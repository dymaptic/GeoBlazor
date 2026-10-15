import TableListViewModelGenerated from './tableListViewModel.gb';
import TableListViewModel from "@arcgis/core/widgets/TableList/TableListViewModel";

export default class TableListViewModelWrapper extends TableListViewModelGenerated {

    constructor(component: TableListViewModel) {
        super(component);
    }

}

export async function buildJsTableListViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableListViewModelGenerated } = await import('./tableListViewModel.gb');
    return await buildJsTableListViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableListViewModel(jsObject: any): Promise<any> {
    let { buildDotNetTableListViewModelGenerated } = await import('./tableListViewModel.gb');
    return await buildDotNetTableListViewModelGenerated(jsObject);
}

