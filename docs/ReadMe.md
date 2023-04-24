# GeoBlazor Documentation

This folder creates a GitHub Pages website with Jekyll.

To run Jekyll locally, you need to follow the [Jekyll Installation Docs](http://jekyllrb.com/docs/installation/).
Then run `bundle exec jekyll serve --config _config_testing.yml` from this folder.

## XML Class Docs

The `pages\classes` documents are auto-generated from the XML comments in `dymaptic.GeoBlazor.Core`. To update these
documents, add your XML comments in the code, build the Core project, and commit the added files in `pages\classes`.
This should be kept up to date with changes in the core library at all times.