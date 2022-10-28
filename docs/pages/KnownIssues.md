---
layout: page
title: Known Issues
nav_order: 4
---

# Known Issues

## Navigating between pages with `MapViews`

Reproducible Scenario
- Blazor Server
- Debugger Attached
- Using `NavMenu.razor` links or other internal Blazor navigation between pages with a MapView. For example, toggling
  between the `Navigation` and `Drawing` pages in the `Samples.Server` application.

Results
- The maps do not always render on the page change, yet a full browser refresh will render fine.

Workaround
- Running in any mode without a debugger attached makes the issue go away.
