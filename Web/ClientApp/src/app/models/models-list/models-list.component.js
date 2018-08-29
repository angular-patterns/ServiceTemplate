"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var model_service_1 = require("../../core/model.service");
var ModelsListComponent = /** @class */ (function () {
    function ModelsListComponent(modelService) {
        var _this = this;
        this.modelService = modelService;
        modelService.getModels().subscribe(function (t) {
            _this.models = t;
        });
    }
    ModelsListComponent.prototype.ngOnInit = function () {
    };
    ModelsListComponent = __decorate([
        core_1.Component({
            selector: 'app-models-list',
            templateUrl: './models-list.component.html',
            styleUrls: ['./models-list.component.css']
        }),
        __metadata("design:paramtypes", [model_service_1.ModelService])
    ], ModelsListComponent);
    return ModelsListComponent;
}());
exports.ModelsListComponent = ModelsListComponent;
