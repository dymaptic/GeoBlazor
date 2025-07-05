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

const RECORD_FILE = path.resolve('../../.esbuild-record.json');
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

function getCurrentGitBranch() {
    try {
        // Execute git command to get current branch name
        const branch = execSync('git rev-parse --abbrev-ref HEAD', { encoding: 'utf-8' }).trim();
        return branch;
    } catch (error) {
        console.warn('Failed to get git branch name:', error.message);
        return 'unknown';
    }
}

function getLastBuildRecord() {
    if (!fs.existsSync(RECORD_FILE)) return { timestamp: 0, branch: 'unknown' };
    try {
        const data = fs.readFileSync(RECORD_FILE, 'utf-8');
        const parsed = JSON.parse(data);
        return { 
            timestamp: parsed.timestamp || 0, 
            branch: parsed.branch || 'unknown' 
        };
    } catch {
        return { timestamp: 0, branch: 'unknown' };
    }
}

function saveBuildRecord() {
    fs.writeFileSync(RECORD_FILE, JSON.stringify({ 
        timestamp: Date.now(),
        branch: getCurrentGitBranch()
    }), 'utf-8');
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
    const lastBuild = getLastBuildRecord();
    const currentBranch = getCurrentGitBranch();
    const branchChanged = currentBranch !== lastBuild.branch;
    
    if (branchChanged) {
        console.log(`Git branch changed from "${lastBuild.branch}" to "${currentBranch}". Rebuilding...`);
    } else if (!scriptsModifiedSince(lastBuild.timestamp)) {
        console.log('No changes in Scripts folder since last build.');
        
        // check output directory for existing files
        const outputFiles = fs.readdirSync(OUTPUT_DIR);
        if (outputFiles.length > 0) {
            console.log('Output directory is not empty. Skipping build.');
            process.exit(0);
        } else {
            console.log('Output directory is empty. Proceeding with build.');
        }
    } else {
        console.log('Changes detected in Scripts folder. Proceeding with build.');
    }
}

if (isWatch) {
    let ctx = await esbuild.context(options);
    await ctx.watch();
    saveBuildRecord();
} else {
    await esbuild.build(options);
    saveBuildRecord();
}