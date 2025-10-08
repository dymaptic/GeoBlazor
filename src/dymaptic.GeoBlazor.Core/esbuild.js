import esbuild from 'esbuild';
import eslint from 'esbuild-plugin-eslint';
import { cleanPlugin } from 'esbuild-clean-plugin';
import path from 'path';
import process from 'process';

const args = process.argv.slice(2);
const isDebug = args.includes('--debug');
const isWatch = args.includes('--watch');
const isRelease = args.includes('--release');
const OUTPUT_DIR = path.resolve('./wwwroot/js');

let options = {
    entryPoints: [
        './Scripts/arcGisJsInterop.ts', // main entry point
        './Scripts/geometryEngine.ts', // logic components
        './Scripts/locationService.ts',
        './Scripts/projection.ts'
    ],
    chunkNames: 'core_[name]_[hash]',
    bundle: true,
    sourcemap: true,
    format: 'esm',
    outdir: OUTPUT_DIR,
    splitting: true,
    metafile: true,
    minify: isRelease,
    plugins: [eslint({
        throwOnError: true
    }),
        cleanPlugin()]
}

if (isWatch) {
    let ctx = await esbuild.context(options);
    await ctx.watch();
} else {
    try {
        await esbuild.build(options);
    } catch (err) {
        console.error(`ESBuild Failed: ${err}`);
        process.exit(1);
    }
}