(function (root) {
  function resolveLayerView(layerId) {
    if (root.getLayerViewByLayerId) return root.getLayerViewByLayerId(layerId);
    const views = root.__geoblazor_views || (root.__map?.views ? [root.__map.views[0]] : []);
    for (const v of views) {
      if (!v?.map?.layers) continue;
      const lyr = v.map.layers.find?.(l => l.id === layerId);
      if (!lyr) continue;
      const lv = v?.whenLayerView ? v.layerViews?.find?.(x => x.layer?.id === layerId) : null;
      return lv || lyr?.views?.[0] || null;
    }
    throw new Error("LayerView not found for layerId: " + layerId);
  }

  root.assertFeatureLayerViewFilterWhere = function (layerId, expectedWhere) {
    const lv = resolveLayerView(layerId);
    const w = lv?.filter?.where ?? "";
    if (String(w) !== String(expectedWhere)) {
      throw new Error(`LayerView.filter.where mismatch. expected=${expectedWhere}, actual=${w}`);
    }
  };

  root.assertFeatureLayerViewMaxFeatures = function (layerId, expected) {
    const lv = resolveLayerView(layerId);
    const v = lv?.maximumNumberOfFeatures;
    if (Number(v) !== Number(expected)) {
      throw new Error(`maximumNumberOfFeatures mismatch. expected=${expected}, actual=${v}`);
    }
  };
})(window);