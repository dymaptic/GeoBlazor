import esbuild from 'esbuild';
import eslint from 'esbuild-plugin-eslint';
import { cleanPlugin } from 'esbuild-clean-plugin';
import fs from 'fs';
import path from 'path';
import process from 'process';
import { execSync } from 'child_process';

const args = process.argv.slice(2);
const isRelease = args.includes('--release');

const RECORD_FILE = path.resolve('../../.esbuild-record.json');
const OUTPUT_DIR = path.resolve('./wwwroot/js');

function getCurrentGitBranch() {
    try {
        const branch = execSync('git rev-parse --abbrev-ref HEAD', { encoding: 'utf-8' }).trim();
        return branch;
    } catch (error) {
        console.warn('Failed to get git branch name:', error.message);
        return 'unknown';
    }
}

function saveBuildRecord() {
    fs.writeFileSync(RECORD_FILE, JSON.stringify({
        timestamp: Date.now(),
        branch: getCurrentGitBranch()
    }), 'utf-8');
}

let options = {
    entryPoints: ['./Scripts/geoBlazorCore.ts'],
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

try {
    await esbuild.build(options);
    saveBuildRecord();
} catch (err) {
    console.error(`ESBuild Failed: ${err}`);
    process.exit(1);
}