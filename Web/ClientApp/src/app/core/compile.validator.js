"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("rxjs/add/operator/map");
var CompileValidator = /** @class */ (function () {
    function CompileValidator() {
    }
    CompileValidator.create = function (modelService) {
        return function (control) {
            var source = control.value;
            return modelService.compileSource(source).map(function (t) {
                if (!t.success)
                    return { 'compile': !t.success, 'errors': t.errors };
                return null;
            });
        };
    };
    return CompileValidator;
}());
exports.CompileValidator = CompileValidator;
