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
var router_1 = require("@angular/router");
var model_service_1 = require("../../core/model.service");
var forms_1 = require("@angular/forms");
var ModelDetailComponent = /** @class */ (function () {
    function ModelDetailComponent(route, modelService) {
        var _this = this;
        this.route = route;
        this.modelService = modelService;
        this.model = {};
        this.populate();
        var id = this.route.snapshot.params.id;
        this.modelService.getModel(id).subscribe(function (t) {
            _this.model = t;
            _this.populate();
        });
    }
    ModelDetailComponent.prototype.ngOnInit = function () {
    };
    ModelDetailComponent.prototype.populate = function () {
        this.formGroup = new forms_1.FormGroup({
            'modelId': new forms_1.FormControl(this.model.id),
            'accountId': new forms_1.FormControl(this.model.accountId),
            'namespace': new forms_1.FormControl(this.model.namespace),
            'typename': new forms_1.FormControl(this.model.typeName),
            'jsonSchema': new forms_1.FormControl(this.model.jsonSchema),
            'cSharpSource': new forms_1.FormControl(this.model.cSharpSource)
        });
    };
    ModelDetailComponent = __decorate([
        core_1.Component({
            selector: 'app-model-detail',
            templateUrl: './model-detail.component.html',
            styleUrls: ['./model-detail.component.css']
        }),
        __metadata("design:paramtypes", [router_1.ActivatedRoute, model_service_1.ModelService])
    ], ModelDetailComponent);
    return ModelDetailComponent;
}());
exports.ModelDetailComponent = ModelDetailComponent;
