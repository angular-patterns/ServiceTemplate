"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var apollo_angular_1 = require("apollo-angular");
var graphql_tag_1 = require("graphql-tag");
var operators_1 = require("rxjs/operators");
var BehaviorSubject_1 = require("rxjs/BehaviorSubject");
var ApplicationService = /** @class */ (function (_super) {
    __extends(ApplicationService, _super);
    function ApplicationService(apollo) {
        var _this = _super.call(this, null) || this;
        _this.apollo = apollo;
        return _this;
    }
    ApplicationService.prototype.applications = function (reviewbusinessId, state) {
        var _this = this;
        this.fetch(reviewbusinessId, state)
            .subscribe(function (x) { return _super.prototype.next.call(_this, x); });
    };
    ApplicationService.prototype.fetch = function (reviewBusinessId, state) {
        var _this = this;
        this.loading = true;
        return this.apollo.query({
            query: graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\n            query GetApplications($reviewBusinessId:String!, $skip: Int!, $take: Int!, $sort: [InputSortDescriptorType]) {\n                applications(reviewBusinessId: $reviewBusinessId, skip: $skip, take: $take, sort: $sort) {\n                  data {\n                    applicationDisplay\n                    applicationStatus\n                    sin\n                    firstName\n                    lastName\n                  }\n                  total\n                }\n              }"], ["\n            query GetApplications($reviewBusinessId:String!, $skip: Int!, $take: Int!, $sort: [InputSortDescriptorType]) {\n                applications(reviewBusinessId: $reviewBusinessId, skip: $skip, take: $take, sort: $sort) {\n                  data {\n                    applicationDisplay\n                    applicationStatus\n                    sin\n                    firstName\n                    lastName\n                  }\n                  total\n                }\n              }"]))),
            variables: {
                reviewBusinessId: reviewBusinessId,
                skip: state.skip,
                take: state.take,
                sort: state.sort
            },
            fetchPolicy: 'network-only'
        })
            .pipe(operators_1.map(function (t) { return t.data; }), operators_1.map(function (t) { return t.applications; }), operators_1.map(function (t) { return ({
            data: t.data,
            total: t.total
        }); }), operators_1.tap(function () { return _this.loading = false; }));
    };
    ApplicationService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [apollo_angular_1.Apollo])
    ], ApplicationService);
    return ApplicationService;
}(BehaviorSubject_1.BehaviorSubject));
exports.ApplicationService = ApplicationService;
var templateObject_1;
