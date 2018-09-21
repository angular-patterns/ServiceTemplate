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
var http_1 = require("@angular/common/http");
var account_service_1 = require("./account.service");
var apollo_angular_1 = require("apollo-angular");
var apollo_angular_link_http_1 = require("apollo-angular-link-http");
var apollo_cache_inmemory_1 = require("apollo-cache-inmemory");
var review_service_1 = require("./review.service");
var application_service_1 = require("./application.service");
var CoreModule = /** @class */ (function () {
    function CoreModule(apollo, httpLink) {
        apollo.create({
            // By default, this client will send queries to the
            // `/graphql` endpoint on the same host
            link: httpLink.create({ uri: 'http://localhost:3697/graphql' }),
            cache: new apollo_cache_inmemory_1.InMemoryCache()
        });
    }
    CoreModule = __decorate([
        core_1.NgModule({
            imports: [
                http_1.HttpClientModule,
                apollo_angular_1.ApolloModule,
                apollo_angular_link_http_1.HttpLinkModule
            ],
            declarations: [],
            bootstrap: [],
            exports: [],
            providers: [
                account_service_1.AccountService,
                review_service_1.ReviewService,
                application_service_1.ApplicationService
            ]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof apollo_angular_1.Apollo !== "undefined" && apollo_angular_1.Apollo) === "function" && _a || Object, typeof (_b = typeof apollo_angular_link_http_1.HttpLink !== "undefined" && apollo_angular_link_http_1.HttpLink) === "function" && _b || Object])
    ], CoreModule);
    return CoreModule;
    var _a, _b;
}());
exports.CoreModule = CoreModule;
