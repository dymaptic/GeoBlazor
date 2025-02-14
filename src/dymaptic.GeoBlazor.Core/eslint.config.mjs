import globals from "globals";
import pluginJs from "@eslint/js";
import tseslint from "typescript-eslint";


/** @type {import('eslint').Linter.Config[]} */
export default [
  {files: ["**/*.{ts}"]},
  {languageOptions: { globals: globals.browser }},
  pluginJs.configs.recommended,
  ...tseslint.configs.recommended,
  {
    rules: {
        "prefer-const": "off",
        "@typescript-eslint/no-explicit-any": "off",
        "@typescript-eslint/typedef": "error",
        'no-prototype-builtins': 'off',
        "@typescript-eslint/ban-ts-comment": 'off',
        'no-case-declarations': "off",
        '@typescript-eslint/no-unsafe-function-type': "off"
    }
  }
];