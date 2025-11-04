import {buildDotNetBarChartMediaInfo, buildJsBarChartMediaInfo} from "./barChartMediaInfo";
import {buildDotNetColumnChartMediaInfo, buildJsColumnChartMediaInfo} from "./columnChartMediaInfo";
import {buildDotNetImageMediaInfo, buildJsImageMediaInfo} from "./imageMediaInfo";
import {buildDotNetLineChartMediaInfo, buildJsLineChartMediaInfo} from "./lineChartMediaInfo";
import {buildDotNetPieChartMediaInfo, buildJsPieChartMediaInfo} from "./pieChartMediaInfo";

export function buildDotNetMediaInfo(mediaInfo: any): any {
    switch (mediaInfo?.type) {
        case 'bar-chart':
            return buildDotNetBarChartMediaInfo(mediaInfo);
        case 'column-chart':
            return buildDotNetColumnChartMediaInfo(mediaInfo);
        case 'image-media':
            return buildDotNetImageMediaInfo(mediaInfo);
        case 'line-chart':
            return buildDotNetLineChartMediaInfo(mediaInfo);
        case 'pie-chart':
            return buildDotNetPieChartMediaInfo(mediaInfo);
        default:
            throw new Error("Unknown media info type");
    }
}

export function buildJsMediaInfo(dotNetMediaInfo: any): any {
    switch (dotNetMediaInfo?.type) {
        case "bar-chart":
            return buildJsBarChartMediaInfo(dotNetMediaInfo);
        case "column-chart":
            return buildJsColumnChartMediaInfo(dotNetMediaInfo);
        case "image-media":
            return buildJsImageMediaInfo(dotNetMediaInfo);
        case "line-chart":
            return buildJsLineChartMediaInfo(dotNetMediaInfo);
        case "pie-chart":
            return buildJsPieChartMediaInfo(dotNetMediaInfo);
        default:
            throw new Error("Unknown media info type");
    }
}
