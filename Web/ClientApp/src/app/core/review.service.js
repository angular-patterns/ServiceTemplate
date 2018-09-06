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
var apollo_angular_1 = require("apollo-angular");
var graphql_tag_1 = require("graphql-tag");
var operators_1 = require("rxjs/operators");
var ReviewService = /** @class */ (function () {
    function ReviewService(apollo) {
        this.apollo = apollo;
    }
    ReviewService.prototype.getReviews = function (skip, take, sort) {
        var _this = this;
        alert(JSON.stringify(sort));
        this.loading = true;
        return this.apollo.query({
            query: graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\n            query GetReviews($skip: Int!, $take: Int!, $sort: InputSortDescriptorType) {\n                reviews(skip: $skip, take: $take, sort: $sort) {\n                  data {\n                    recordCount\n                    total\n                    percentage\n                    businessId\n                    message\n                    category\n                    subCategory\n                  }\n                  total\n                }\n              }\n              \n              "], ["\n            query GetReviews($skip: Int!, $take: Int!, $sort: InputSortDescriptorType) {\n                reviews(skip: $skip, take: $take, sort: $sort) {\n                  data {\n                    recordCount\n                    total\n                    percentage\n                    businessId\n                    message\n                    category\n                    subCategory\n                  }\n                  total\n                }\n              }\n              \n              "]))),
            variables: {
                skip: skip,
                take: take,
                sort: sort
            },
            fetchPolicy: 'network-only'
        })
            .pipe(operators_1.map(function (t) { return t.data; }), operators_1.map(function (t) { return t.reviews; }), operators_1.map(function (t) { return ({
            data: t.data,
            total: t.total
        }); }), operators_1.tap(function () { return _this.loading = false; }));
    };
    ReviewService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [apollo_angular_1.Apollo])
    ], ReviewService);
    return ReviewService;
}());
exports.ReviewService = ReviewService;
var templateObject_1;
