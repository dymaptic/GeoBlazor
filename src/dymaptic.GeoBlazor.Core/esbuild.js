import esbuild from 'esbuild';
import eslint from 'esbuild-plugin-eslint';
import { cleanPlugin } from 'esbuild-clean-plugin';
import fs from 'fs';
import path from 'path';
import { execSync } from 'child_process';

const args = process.argv.slice(2);
const isDebug = args.includes('--debug');
const isWatch = args.includes('--watch');
const isRelease = args.includes('--release');

const SCRIPTS_DIR = path.resolve('./Scripts');
const OUTPUT_DIR = path.resolve('./wwwroot/js');

let options = {
    entryPoints: ['./Scripts/arcGisJsInterop.ts'],
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
    await esbuild.build(options);
}