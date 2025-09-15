(function (root) {
  function resolveLayerById(id) {
    if (root.getLayerById) return root.getLayerById(id);
    if (root.geoBlazor?.interop?.getLayerById) return root.geoBlazor.interop.getLayerById(id);
    const views = root.__geoblazor_views || (root.__map?.views ? [root.__map.views[0]] : []);
    for (const v of views) {
      if (!v?.map?.layers) continue;
      const lyr = v.map.layers.find?.(l => l.id === id);
      if (lyr) return lyr;
    }
    throw new Error("Layer not found for id: " + id);
  }

  function assertEq(actual, expected, msg) {
    if (Array.isArray(expected)) {
      const pass = Array.isArray(actual) && expected.length === actual.length
        ? expected.every((v, i) => v === actual[i])
        : false;
      if (!pass) throw new Error(msg + ` (expected: ${JSON.stringify(expected)}, actual: ${JSON.stringify(actual)})`);
      return;
    }
    if (actual !== expected) {
      throw new Error(msg + ` (expected: ${JSON.stringify(expected)}, actual: ${JSON.stringify(actual)})`);
    }
  }

  root.assertFeatureLayerBooleanPropEquals = function (id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(!!layer[prop], !!expected, `Boolean property mismatch: ${prop}`);
  };

  root.assertFeatureLayerNumberPropEquals = function (id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(Number(layer[prop]), Number(expected), `Number property mismatch: ${prop}`);
  };

  root.assertFeatureLayerStringPropEquals = function (id, prop, expected) {
    const layer = resolveLayerById(id);
    assertEq(String(layer[prop] ?? ""), String(expected ?? ""), `String property mismatch: ${prop}`);
  };

  root.assertFeatureLayerArrayPropEquals = function (id, prop, expected) {
    const layer = resolveLayerById(id);
    const arr = Array.isArray(layer[prop]) ? layer[prop] : [];
    assertEq(arr, expected, `Array property mismatch: ${prop}`);
  };

  root.assertFeatureLayerRendererType = function (id, expectedType) {
    const layer = resolveLayerById(id);
    const t = layer.renderer?.type;
    if (t !== expectedType) {
      throw new Error(`Renderer type mismatch. expected=${expectedType}, actual=${t}`);
    }
  };

  root.assertFeatureLayerPopupTitle = function (id, expectedTitle) {
    const layer = resolveLayerById(id);
    const t = layer.popupTemplate?.title;
    if (String(t ?? "") !== String(expectedTitle ?? "")) {
      throw new Error(`PopupTemplate.title mismatch. expected=${expectedTitle}, actual=${t}`);
    }
  };

  root.assertFeatureLayerOrderByContains = function (id, field, order) {
    const layer = resolveLayerById(id);
    const items = layer.orderBy || [];
    const hit = items.some(i => i?.field === field && String(i?.order || "").toUpperCase() === String(order).toUpperCase());
    if (!hit) {
      throw new Error(`orderBy missing expected entry: ${field} ${order}`);
    }
  };
})(window);