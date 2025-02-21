import esbuild from 'esbuild';
import eslint from 'esbuild-plugin-eslint';

const args = process.argv.slice(2);
const isDebug = args.includes('--debug');
const isWatch = args.includes('--watch');
const isRelease = args.includes('--release');

let options = {
    entryPoints: ['./Scripts/arcGisJsInterop.ts'],
    bundle: true,
    sourcemap: isDebug || isWatch,
    format: 'esm',
    outdir: 'wwwroot/js',
    splitting: true,
    minify: isRelease,
    plugins: [eslint({
        throwOnError: true
    })]
}

if (isWatch) {
    let ctx = await esbuild.context(options);
    await ctx.watch();
} else {
    await esbuild.build(options);
}