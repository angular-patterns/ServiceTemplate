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
var forms_1 = require("@angular/forms");
var model_service_1 = require("../../core/model.service");
var model_validator_1 = require("../../core/model.validator");
var rxjs_1 = require("rxjs");
var compile_validator_1 = require("../../core/compile.validator");
var router_1 = require("@angular/router");
var AddModelComponent = /** @class */ (function () {
    function AddModelComponent(modelService, router, route) {
        this.modelService = modelService;
        this.router = router;
        this.route = route;
        this.accountCtrl = new forms_1.FormControl('');
        this.sourceCtrl = new forms_1.FormControl('', { validators: forms_1.Validators.required, asyncValidators: compile_validator_1.CompileValidator.create(this.modelService, this.onCompileResult.bind(this)) });
        this.typenameCtrl = new forms_1.FormControl('', { asyncValidators: model_validator_1.ModelValidator.create(this.modelService, this.sourceCtrl) }),
            this.hideRules = true;
        this.formGroup = new forms_1.FormGroup({
            'accountId': this.accountCtrl,
            'typename': this.typenameCtrl,
            'source': this.sourceCtrl
        });
    }
    Object.defineProperty(AddModelComponent.prototype, "errors", {
        get: function () {
            if (this.formGroup.get('source').hasError('compile')) {
                return this.formGroup.get('source').errors.errors;
            }
            return [];
        },
        enumerable: true,
        configurable: true
    });
    AddModelComponent.prototype.onCompileResult = function (result) {
        if (result)
            this.typenameCtrl.setValue(this.typenameCtrl.value);
    };
    AddModelComponent.prototype.ngOnInit = function () {
    };
    AddModelComponent.prototype.ngAfterViewInit = function () {
        rxjs_1.merge(rxjs_1.fromEvent(this.source.nativeElement, 'keypress'), rxjs_1.fromEvent(this.typename.nativeElement, 'keypress')).subscribe(function (t) {
            //alert('hey');
        });
    };
    AddModelComponent.prototype.toggleRules = function () {
        this.hideRules = !this.hideRules;
    };
    AddModelComponent.prototype.onAddModel = function (value) {
        var _this = this;
        if (this.formGroup.valid) {
            this.modelService.createModelFromCSharp(value.source, value.typename, value.accountId).subscribe(function (t) {
                _this.router.navigate(['../'], { relativeTo: _this.route });
            });
        }
    };
    __decorate([
        core_1.ViewChild('source'),
        __metadata("design:type", Object)
    ], AddModelComponent.prototype, "source", void 0);
    __decorate([
        core_1.ViewChild('typename'),
        __metadata("design:type", Object)
    ], AddModelComponent.prototype, "typename", void 0);
    AddModelComponent = __decorate([
        core_1.Component({
            selector: 'app-add-model',
            templateUrl: './add-model.component.html',
            styleUrls: ['./add-model.component.css']
        }),
        __metadata("design:paramtypes", [model_service_1.ModelService, router_1.Router, router_1.ActivatedRoute])
    ], AddModelComponent);
    return AddModelComponent;
}());
exports.AddModelComponent = AddModelComponent;
