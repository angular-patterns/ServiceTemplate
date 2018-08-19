"use strict";
var __makeTemplateObject = (this && this.__makeTemplateObject) || function (cooked, raw) {
    if (Object.defineProperty) { Object.defineProperty(cooked, "raw", { value: raw }); } else { cooked.raw = raw; }
    return cooked;
};
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
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var apollo_angular_1 = require("apollo-angular");
var graphql_tag_1 = require("graphql-tag");
var operators_1 = require("rxjs/operators");
var AccountService = /** @class */ (function () {
    function AccountService(http, apollo) {
        this.http = http;
        this.apollo = apollo;
        this._accountAdded = new rxjs_1.Subject();
        this.accountAdded$ = this._accountAdded.asObservable();
    }
    AccountService.prototype.getAccounts = function () {
        return this.apollo.query({
            query: graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\n            {\n                accounts {\n                    accountId\n                    username\n                    password\n                }\n            }\n            "], ["\n            {\n                accounts {\n                    accountId\n                    username\n                    password\n                }\n            }\n            "])))
        });
    };
    AccountService.prototype.deleteAccount = function (accountId) {
        return this.apollo.mutate({
            mutation: graphql_tag_1.default(templateObject_2 || (templateObject_2 = __makeTemplateObject(["\n                mutation DeleteAccount($accountId:Int!) {\n                    deleteAccount(id: $accountId)\n                }"], ["\n                mutation DeleteAccount($accountId:Int!) {\n                    deleteAccount(id: $accountId)\n                }"]))),
            variables: {
                'accountId': accountId
            }
        });
    };
    AccountService.prototype.addAccount = function (username, password) {
        return this.apollo.mutate({
            mutation: graphql_tag_1.default(templateObject_3 || (templateObject_3 = __makeTemplateObject(["\n                mutation AddAccount($username:String!, $password:String!) {\n                    createAccount(username: $username, password: $password) {\n                        accountId\n                        username\n                        password\n                    }\n                }\n            "], ["\n                mutation AddAccount($username:String!, $password:String!) {\n                    createAccount(username: $username, password: $password) {\n                        accountId\n                        username\n                        password\n                    }\n                }\n            "]))),
            variables: {
                'username': username,
                'password': password
            }
        }).pipe(operators_1.map(function (t) { return t.data; }));
    };
    AccountService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient, apollo_angular_1.Apollo])
    ], AccountService);
    return AccountService;
}());
exports.AccountService = AccountService;
var templateObject_1, templateObject_2, templateObject_3;
