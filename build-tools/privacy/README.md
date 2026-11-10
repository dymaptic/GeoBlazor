# The public publish gate

`dymaptic.GeoBlazor` (the library) and `dymaptic/GeoBlazor-Samples` are public. Two repositories stay
private permanently: `dy-licensing` (the key service) and `dymaptic.GeoBlazor.CodeGen` (the code
generator, called the generator below). The rule this folder enforces is that no part of either may
reach a public artifact.

## Why a gate and not a `.gitignore`

`.gitignore` protects against an accidental `git add`. It does nothing about a file that is already
tracked on a private branch, which rides along the moment that branch is published. Both of the
gate's first two findings were exactly that case: tracked files that only needed a push to become
permanent.

The generator writes into the library tree by design, so this is a standing hazard rather than a
one-time cleanup. The gate is the control that makes every later step safe to run privately.

## What it refuses

By path, anywhere in a tracked tree:

- the generator's run report, `CodeGenerationReport.md`;
- `*.binlog`, the binary build logs whose command lines carry private values;
- the generator's cache folders, `ArcGISDefinitions/` and `GeoBlazorMetaData/`;
- `.history/`, the local editor history.

By content, in text and in binaries:

- the developer's absolute checkout path of the generator (a drive letter followed by its name);
- a generator stack frame, meaning its name, a separator, a source file, and a line number;
- any reference to the licensing service's namespace;
- the private owner-and-repository form of the generator's name.

The generator's bare assembly name is **not** refused. `InternalsVisibleTo` naming it is an accepted
disclosure under section 0a, because the generator's name is not the secret, its contents are.
Likewise the directory rule matches a folder name, so the public source file `GeoBlazorMetaData.cs`
is not caught by the cache-folder rule.

A compiled build script embeds the absolute path of the developer's checkout in its debug directory,
and a generated runtime config records the absolute path of its entry point. Both are content
findings precisely because they are invisible to a path rule.

## Running it

```bash
# the tree of HEAD
build-tools/privacy/public-leak-gate.sh

# one commit
build-tools/privacy/public-leak-gate.sh --tree v5.0

# every commit, tree, and blob newly reachable from a base, including files added then deleted
build-tools/privacy/public-leak-gate.sh --range origin/main..HEAD
```

The exit code is `0` when clean, `1` when anything is found, and `2` for bad usage. The report groups
findings by file and names every rule that fired, so the fix is obvious from the output alone.

## Where it runs

| Place | Role |
|---|---|
| `.github/workflows/public-publish-gate.yml` | **Authoritative.** A required check on the public release branch. |
| `.githooks/pre-push` | Fast local feedback, only for pushes aimed at a public remote. |

Enable the hook once per clone with `git config core.hooksPath .githooks`. The hook is a
convenience: `git push --no-verify` skips it, which is why the workflow is the enforcement point.

The workflow scans the whole publication range rather than the final tree alone, because publishing a
private branch makes every ancestor and every object reachable from it public. Deleting a sensitive
file today does not make the earlier blob safe.

## Keeping it honest

The scanner, the workflow, and the hook all contain the patterns they search for, so those three
paths are excluded from the content check by exact path. Nothing else is excluded, and a folder-wide
exclusion would be a hole. A change to any of the three is reviewed at pull request time.
