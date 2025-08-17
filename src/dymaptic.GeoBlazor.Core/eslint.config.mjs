import globals from "globals";
import pluginJs from "@eslint/js";
import tseslint from "typescript-eslint";
import sonarjs from 'eslint-plugin-sonarjs';

/** @type {import('eslint').Linter.Config[]} */
export default [
  {files: ["Scripts/*.{ts}"]},
  {
      languageOptions: { 
            globals: {
                ...globals.browser,
                "__esri": "readonly",
                "DotNet": "readonly",
                "IHandle": "readonly",
                "HTMLCollectionOf": "readonly"
            }
      }
  },
  pluginJs.configs.recommended,
  ...tseslint.configs.recommended,
  { plugins: { sonarjs },
    rules: {
        "prefer-const": "off",
        "@typescript-eslint/no-explicit-any": "off",
        "@typescript-eslint/no-this-alias": "off",
        "@typescript-eslint/typedef": "error",
        'no-prototype-builtins': 'off',
        "@typescript-eslint/ban-ts-comment": 'off',
        'no-case-declarations': "off",
        '@typescript-eslint/no-unsafe-function-type': "off",
        '@typescript-eslint/no-unused-vars': 'off',
        "no-undef": "error",
        'no-unused-vars': "off",
        'no-useless-catch': 'off',
        //'sonarjs/argument-type': 'error',
        //'sonarjs/no-extra-arguments': 'error',
        //'sonarjs/no-unused-function-argument': 'error'
    }
  }
];