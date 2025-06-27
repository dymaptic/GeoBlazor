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
    external: ['./multipoint', './mesh'],
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

if (!isWatch) {
    const lastTimestamp = getLastBuildTimestamp();
    if (!scriptsModifiedSince(lastTimestamp)) {
        console.log('No changes in Scripts folder since last build. Skipping build.');
        process.exit(0);
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