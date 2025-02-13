export async function buildDotNetMediaInfo(mediaInfo) {
    switch (mediaInfo?.type) {
        case 'bar-chart':
            let { buildDotNetBarChartMediaInfo } = await import('./barChartMediaInfo');
            return await buildDotNetBarChartMediaInfo(mediaInfo);
        case 'column-chart':
            let { buildDotNetColumnChartMediaInfo } = await import('./columnChartMediaInfo');
            return await buildDotNetColumnChartMediaInfo(mediaInfo);
        case 'image-media':
            let { buildDotNetImageMediaInfo } = await import('./imageMediaInfo');
            return await buildDotNetImageMediaInfo(mediaInfo);
        case 'line-chart':
            let { buildDotNetLineChartMediaInfo } = await import('./lineChartMediaInfo');
            return await buildDotNetLineChartMediaInfo(mediaInfo);
        case 'pie-chart':
            let { buildDotNetPieChartMediaInfo } = await import('./pieChartMediaInfo');
            return await buildDotNetPieChartMediaInfo(mediaInfo);
        default:
            throw new Error("Unknown media info type");
    }
}