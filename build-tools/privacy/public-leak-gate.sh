#!/usr/bin/env bash
#
# public-leak-gate.sh - refuse to publish private generator or licensing content.
#
# This implements the permanent-privacy invariant: dy-licensing (the key service) and
# dymaptic.GeoBlazor.CodeGen (the code generator) stay private forever, and no part of either may
# reach a public artifact. The boundary it guards is the push to the public remote, not commit time:
# a file that is already tracked on a private branch rides along at publish no matter what
# .gitignore says.
#
# Usage:
#   public-leak-gate.sh                          scan the tree of HEAD
#   public-leak-gate.sh --tree <ref>             scan one commit's tree
#   public-leak-gate.sh --range <base>..<head>   scan every commit, tree, and blob newly reachable
#
# Exit codes: 0 clean, 1 leaks found, 2 bad usage or an unreadable ref.
#
# Two kinds of check run in both modes:
#   - path markers: a tracked path that names a private artifact (a directory or a file name);
#   - content markers: tracked bytes that name the private generator or the licensing service.
# Binary files are scanned for content markers as well, because a compiled build script embeds the
# absolute path of the developer's checkout into its debug directory.
#
# The gate's own machinery is excluded from the content check, because it necessarily contains the
# marker patterns. Only these three paths are excluded, by exact path rather than by prefix, so a
# leak cannot hide under a folder name. A change to any of them is reviewed at pull request time,
# which is the control that covers them.

set -uo pipefail

readonly EXCLUDED_PATHS=(
    'build-tools/privacy/public-leak-gate.sh'
    '.github/workflows/public-publish-gate.yml'
    '.githooks/pre-push'
)

# Path markers, applied to every tracked path. A directory component must match exactly, so the
# source file `GeoBlazorMetaData.cs` is not confused with the generator's cache folder.
readonly PATH_RULES=(
    'CodeGenerationReport.md|generator report'
    '*.binlog|build binary log'
    'ArcGISDefinitions/|generator cache'
    'GeoBlazorMetaData/|generator cache'
    '.history/|editor history'
)

# Content markers, as extended regular expressions, written as "<pattern>|<rule label>".
#
# The dotted form `dymaptic.GeoBlazor.CodeGen` on its own is deliberately NOT a marker: naming the
# assembly in InternalsVisibleTo is an accepted disclosure, because the generator's name is not the
# secret - its contents are. Every rule below therefore requires more than the bare name: a drive
# letter before it, a path separator inside a stack frame, or the private owner/repo form.
#
# The owner/repo rule goes beyond the other marker rules, and is here because the invariant bans
# issue and pull request references outright. A test comment naming issues in a private tracker is
# exactly that.
readonly CONTENT_RULES=(
    '[A-Za-z]:[\\/]+dymaptic\.GeoBlazor\.CodeGen|generator absolute path'
    'dymaptic\.GeoBlazor\.CodeGen[\\/][^:]*\.cs:line|generator stack trace'
    'dymaptic\.Licensing\.|licensing namespace'
    'dymaptic[\\/]dymaptic\.GeoBlazor\.CodeGen|private repository name'
)

die() {
    printf 'public-leak-gate: %s\n' "$1" >&2
    exit 2
}

# Prints "<rule>\t<path>" for every path that names a private artifact. Reads paths on stdin.
match_paths() {
    awk -v rules="$(printf '%s\n' "${PATH_RULES[@]}")" '
        BEGIN {
            count = split(rules, rule, "\n")
            for (i = 1; i <= count; i++) {
                split(rule[i], pair, "|")
                marker[i] = pair[1]
                label[i] = pair[2]
            }
        }
        {
            path = $0
            segments = split(path, part, "/")
            name = part[segments]

            for (i = 1; i <= count; i++) {
                if (marker[i] ~ /^\*\./) {
                    suffix = substr(marker[i], 2)
                    if (length(name) > length(suffix) && substr(name, length(name) - length(suffix) + 1) == suffix) {
                        print label[i] "\t" path
                        next
                    }
                } else if (marker[i] ~ /\/$/) {
                    directory = substr(marker[i], 1, length(marker[i]) - 1)
                    for (j = 1; j < segments; j++) {
                        if (part[j] == directory) {
                            print label[i] "\t" path
                            next
                        }
                    }
                } else if (name == marker[i]) {
                    print label[i] "\t" path
                    next
                }
            }
        }'
}

# Prints "<rule>\t<path>" once per rule that fires in one tree. $1 is a commit or a ref.
match_content() {
    local ref="$1" rule pattern matched path
    local -a excludes

    mapfile -t excludes < <(printf ':(exclude)%s\n' "${EXCLUDED_PATHS[@]}")
    for rule in "${CONTENT_RULES[@]}"; do
        pattern="${rule%|*}"
        while IFS= read -r matched; do
            [[ -n "$matched" ]] || continue
            path="${matched#"$ref":}"
            printf '%s\t%s\n' "${rule#*|}" "$path"
        done < <(git grep -l -E -e "$pattern" "$ref" -- . "${excludes[@]}" 2>/dev/null)
    done
}

require_ref() {
    git rev-parse --verify --quiet "$1^{commit}" >/dev/null || die "not a commit: $1"
}

scan_tree() {
    local ref="$1"
    require_ref "$ref"
    report "$(collect "$ref" "$(git ls-tree -r --name-only "$ref")")" "tree $ref"
}

scan_range() {
    local range="$1" commit paths hit
    local -a commits

    mapfile -t commits < <(git rev-list "$range" 2>/dev/null)
    if [[ ${#commits[@]} -eq 0 ]]; then
        printf 'public-leak-gate: range %s holds no commits; nothing to scan.\n' "$range"
        exit 0
    fi

    # Paths come from every commit's diff, so a file added and later deleted inside the range is
    # still seen - which is the case that publishing history makes irreversible. Content comes from
    # every commit's tree, because a blob introduced anywhere in the range is reachable from the
    # commit that introduced it.
    paths=$(git log --name-only --pretty=format: "$range" | grep -v '^$' || true)

    hit="$(
        {
            printf '%s\n' "$paths" | match_paths
            for commit in "${commits[@]}"; do
                match_content "$commit"
            done
        } | sort -u
    )"

    report "$hit" "range $range (${#commits[@]} commits)"
}

# Turns "<rule>\t<path>" lines into one line per path with every rule that fired, and prints a
# clean verdict. $1 is "<rule>\t<path>" lines, $2 names the scope that was scanned.
report() {
    local findings="$1" scope="$2" grouped

    if [[ -z "$findings" ]]; then
        printf 'public-leak-gate: clean - %s holds nothing private.\n' "$scope"
        exit 0
    fi

    grouped=$(
        printf '%s\n' "$findings" \
            | sort -u \
            | awk -F'\t' '{ rules[$2] = (rules[$2] == "" ? $1 : rules[$2] ", " $1); paths[$2] = 1 }
                           END { for (path in paths) print path "\t" rules[path] }' \
            | sort
    )

    printf 'public-leak-gate: REFUSED - %s holds private content:\n\n' "$scope" >&2
    printf '%s\n' "$grouped" \
        | awk -F'\t' '{ printf "  %s\n      %s\n", $1, $2 }' >&2
    printf '\n' >&2
    printf 'Neither dymaptic.GeoBlazor.CodeGen nor dy-licensing may reach a public artifact.\n' >&2
    printf 'Remove the content above, or move it somewhere private, before publishing.\n' >&2
    exit 1
}

# Prints the raw "<rule>\t<path>" findings for one tree. $1 is a ref, $2 is its tracked path list.
collect() {
    local ref="$1" paths="$2"
    {
        printf '%s\n' "$paths" | match_paths
        match_content "$ref"
    } | sort -u
}

main() {
    git rev-parse --git-dir >/dev/null 2>&1 || die "not inside a git repository"

    case "${1:-}" in
        '')        scan_tree HEAD ;;
        --tree)    [[ $# -eq 2 ]] || die "--tree needs exactly one ref"; scan_tree "$2" ;;
        --range)   [[ $# -eq 2 ]] || die "--range needs <base>..<head>"; scan_range "$2" ;;
        -h|--help) sed -n '5,14p' "${BASH_SOURCE[0]}" | sed 's/^# \{0,1\}//' ;;
        *)         die "unknown argument: $1" ;;
    esac
}

main "$@"
