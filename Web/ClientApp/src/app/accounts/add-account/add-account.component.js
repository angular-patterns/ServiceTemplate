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
var account_service_1 = require("../../core/account.service");
var AddAccountComponent = /** @class */ (function () {
    function AddAccountComponent(fb, accountService) {
        this.fb = fb;
        this.accountService = accountService;
        this.initForm();
    }
    AddAccountComponent.prototype.ngOnInit = function () {
    };
    AddAccountComponent.prototype.initForm = function () {
        this.formGroup = this.fb.group({
            username: ['', forms_1.Validators.required],
            password: ['', forms_1.Validators.required]
        });
    };
    AddAccountComponent.prototype.onSubmit = function () {
        var _this = this;
        if (this.formGroup.valid) {
            var account = this.formGroup.value;
            this.accountService.addAccount(account.username, account.password).then(function (t) {
                _this.initForm();
            });
        }
    };
    AddAccountComponent = __decorate([
        core_1.Component({
            selector: 'app-add-account',
            templateUrl: './add-account.component.html',
            styleUrls: ['./add-account.component.css']
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder, account_service_1.AccountService])
    ], AddAccountComponent);
    return AddAccountComponent;
}());
exports.AddAccountComponent = AddAccountComponent;
