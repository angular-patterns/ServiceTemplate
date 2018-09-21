"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var app_component_1 = require("./app.component");
var app_routing_module_1 = require("./app-routing.module");
var core_module_1 = require("./core/core.module");
var accounts_module_1 = require("./accounts/accounts.module");
var animations_1 = require("@angular/platform-browser/animations");
var kendo_angular_grid_1 = require("@progress/kendo-angular-grid");
var review_details_component_1 = require("./review-details/review-details.component");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                app_routing_module_1.AppRoutingModule,
                core_module_1.CoreModule,
                accounts_module_1.AccountsModule,
                animations_1.BrowserAnimationsModule,
                kendo_angular_grid_1.GridModule
            ],
            declarations: [app_component_1.AppComponent, review_details_component_1.ReviewDetailsComponent],
            bootstrap: [app_component_1.AppComponent],
            exports: [app_component_1.AppComponent],
            providers: []
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
