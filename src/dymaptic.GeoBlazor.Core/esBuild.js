import esbuild from 'esbuild';
import {cleanPlugin} from 'esbuild-clean-plugin';
import fs from 'fs';
import path from 'path';
import process from 'process';

const args = process.argv.slice(2);
const isRelease = args.includes('--release');
const OUTPUT_DIR = path.resolve('./wwwroot/js');


let options = {
    entryPoints: [
        './Scripts/geoBlazorCore.ts', // main entry point
        './Scripts/geometryEngine.ts', // logic components
        './Scripts/locationService.ts',
        './Scripts/projectionEngine.ts'
    ],
    chunkNames: 'core_[name]_[hash]',
    bundle: true,
    sourcemap: true,
    format: 'esm',
    outdir: OUTPUT_DIR,
    splitting: true,
    loader: {
        ".woff2": "file"
    },
    metafile: true,
    minify: isRelease,
    plugins: [cleanPlugin()]
}

// check if output directory exists
if (!fs.existsSync(OUTPUT_DIR)) {
    console.log('Output directory does not exist. Creating it.');
    fs.mkdirSync(OUTPUT_DIR, {recursive: true});
}

try {
    await esbuild.build(options);
} catch (err) {
    console.log(`wwwroot file possibly locked. Attempting to build without clean plugin...`);
    // try without clean plugin
    options.plugins = [];
    try {
        await esbuild.build(options);
    } catch (err) {
        console.error(`ESBuild Failed: ${err}`);
        process.exit(1);
    }
}