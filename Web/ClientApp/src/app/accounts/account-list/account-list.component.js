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
var account_service_1 = require("../../core/account.service");
var AccountListComponent = /** @class */ (function () {
    function AccountListComponent(accountService) {
        var _this = this;
        this.accountService = accountService;
        this.accountService.getAccounts().subscribe(function (t) {
            _this.accounts = t.data.accounts.slice();
        });
        this.accountService.accountAdded$.subscribe(function (t) {
            _this.accounts.push(t);
        });
    }
    AccountListComponent.prototype.ngOnInit = function () {
    };
    AccountListComponent.prototype.onDelete = function (item) {
        var _this = this;
        this.accountService.deleteAccount(item.accountId).subscribe(function (t) {
            var i = _this.accounts.indexOf(item);
            if (i >= 0) {
                _this.accounts.splice(i, 1);
            }
        });
    };
    AccountListComponent = __decorate([
        core_1.Component({
            selector: 'app-account-list',
            templateUrl: './account-list.component.html',
            styleUrls: ['./account-list.component.css']
        }),
        __metadata("design:paramtypes", [account_service_1.AccountService])
    ], AccountListComponent);
    return AccountListComponent;
}());
exports.AccountListComponent = AccountListComponent;
