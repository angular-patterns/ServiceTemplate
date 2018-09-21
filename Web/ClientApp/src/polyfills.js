"use strict";
/***************************************************************************************************
 * BROWSER POLYFILLS
 */
Object.defineProperty(exports, "__esModule", { value: true });
/** IE9, IE10 and IE11 requires all of the following polyfills. **/
require("core-js/es6/symbol");
require("core-js/es6/object");
require("core-js/es6/function");
require("core-js/es6/parse-int");
require("core-js/es6/parse-float");
require("core-js/es6/number");
require("core-js/es6/math");
require("core-js/es6/string");
require("core-js/es6/date");
require("core-js/es6/array");
require("core-js/es6/regexp");
require("core-js/es6/map");
require("core-js/es6/weak-map");
require("core-js/es6/set");
/** IE10 and IE11 requires the following for NgClass support on SVG elements */
// import 'classlist.js';  // Run `npm install --save classlist.js`.
/** Evergreen browsers require these. **/
require("core-js/es6/reflect");
require("core-js/es7/reflect");
require("zone.js/dist/zone");
if (!Element.prototype.matches) {
    Element.prototype.matches = Element.prototype.msMatchesSelector;
}
