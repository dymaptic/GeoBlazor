import esbuild from 'esbuild';
import eslint from 'esbuild-plugin-eslint';
import { cleanPlugin } from 'esbuild-clean-plugin';
import fs from 'fs';
import path from 'path';

const args = process.argv.slice(2);
const isDebug = args.includes('--debug');
const isWatch = args.includes('--watch');
const isRelease = args.includes('--release');

const TIMESTAMP_FILE = '.esbuild-timestamp.json';
const SCRIPTS_DIR = path.resolve('./Scripts');
const OUTPUT_DIR = path.resolve('./wwwroot/js');

function getAllScriptFiles(dir) {
    let results = [];
    const list = fs.readdirSync(dir);
    list.forEach(function(file) {
        file = path.resolve(dir, file);
        const stat = fs.statSync(file);
        if (stat && stat.isDirectory()) {
            results = results.concat(getAllScriptFiles(file));
        } else {
            results.push(file);
        }
    });
    return results;
}

function getLastBuildTimestamp() {
    if (!fs.existsSync(TIMESTAMP_FILE)) return 0;
    try {
        const data = fs.readFileSync(TIMESTAMP_FILE, 'utf-8');
        return JSON.parse(data).timestamp || 0;
    } catch {
        return 0;
    }
}

function saveBuildTimestamp() {
    fs.writeFileSync(TIMESTAMP_FILE, JSON.stringify({ timestamp: Date.now() }), 'utf-8');
}

function scriptsModifiedSince(lastTimestamp) {
    const files = getAllScriptFiles(SCRIPTS_DIR);
    for (const file of files) {
        const stat = fs.statSync(file);
        if (stat.mtimeMs > lastTimestamp) {
            return true;
        }
    }
    return false;
}

let options = {
    entryPoints: ['./Scripts/arcGisJsInterop.ts'],
    bundle: true,
    sourcemap: true,
    format: 'esm',
    outdir: 'wwwroot/js',
    splitting: true,
    metafile: true,
    minify: isRelease,
    plugins: [eslint({
        throwOnError: true
    }),
        cleanPlugin()]
}

// check if output directory exists
if (!fs.existsSync(OUTPUT_DIR)) {
    console.log('Output directory does not exist. Creating it.');
    fs.mkdirSync(OUTPUT_DIR, { recursive: true });
}

if (!isWatch) {
    const lastTimestamp = getLastBuildTimestamp();
    if (!scriptsModifiedSince(lastTimestamp)) {
        console.log('No changes in Scripts folder since last build.');
        
        // check output directory for existing files
        const outputFiles = fs.readdirSync(OUTPUT_DIR);
        if (outputFiles.length > 0) {
            console.log('Output directory is not empty. Skipping build.');
            process.exit(0);
        } else {
            console.log('Output directory is empty. Proceeding with build.');
        }
    }
}

if (isWatch) {
    let ctx = await esbuild.context(options);
    await ctx.watch();
    saveBuildTimestamp();
} else {
    await esbuild.build(options);
    saveBuildTimestamp();
}