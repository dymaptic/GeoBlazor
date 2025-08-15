import {buildDotNetBarChartMediaInfo, buildJsBarChartMediaInfo} from "./barChartMediaInfo";
import {buildDotNetColumnChartMediaInfo, buildJsColumnChartMediaInfo} from "./columnChartMediaInfo";
import {buildDotNetImageMediaInfo, buildJsImageMediaInfo} from "./imageMediaInfo";
import {buildDotNetLineChartMediaInfo, buildJsLineChartMediaInfo} from "./lineChartMediaInfo";
import {buildDotNetPieChartMediaInfo, buildJsPieChartMediaInfo} from "./pieChartMediaInfo";

export function buildDotNetMediaInfo(mediaInfo: any, viewId: string | null): any {
    switch (mediaInfo?.type) {
        case 'bar-chart':
            return buildDotNetBarChartMediaInfo(mediaInfo, viewId);
        case 'column-chart':
            return buildDotNetColumnChartMediaInfo(mediaInfo, viewId);
        case 'image-media':
            return buildDotNetImageMediaInfo(mediaInfo, viewId);
        case 'line-chart':
            return buildDotNetLineChartMediaInfo(mediaInfo, viewId);
        case 'pie-chart':
            return buildDotNetPieChartMediaInfo(mediaInfo, viewId);
        default:
            throw new Error("Unknown media info type");
    }
}

export function buildJsMediaInfo(dotNetMediaInfo: any, viewId: string | null): any {
    switch (dotNetMediaInfo?.type) {
        case "bar-chart":
            return buildJsBarChartMediaInfo(dotNetMediaInfo, viewId);
        case "column-chart":
            return buildJsColumnChartMediaInfo(dotNetMediaInfo, viewId);
        case "image":
            return buildJsImageMediaInfo(dotNetMediaInfo, viewId);
        case "line-chart":
            return buildJsLineChartMediaInfo(dotNetMediaInfo, viewId);
        case "pie-chart":
            return buildJsPieChartMediaInfo(dotNetMediaInfo, viewId);
        default:
            throw new Error("Unknown media info type");
    }
}
