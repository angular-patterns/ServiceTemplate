"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("rxjs/add/operator/map");
var ModelValidator = /** @class */ (function () {
    function ModelValidator() {
    }
    ModelValidator.create = function (modelService, sourceCtrl) {
        return function (control) {
            var typename = control.value;
            var source = sourceCtrl.value;
            return modelService.validateModel(source, typename).map(function (t) {
                console.log(t);
                if (!t.success)
                    return {
                        'typeNotFound': !t.typeFound,
                        'compile': !t.compileSucceeded,
                        'errors': t.compileErrors
                    };
                return null;
            });
        };
    };
    return ModelValidator;
}());
exports.ModelValidator = ModelValidator;
