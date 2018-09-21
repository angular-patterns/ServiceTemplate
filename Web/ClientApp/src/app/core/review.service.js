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
var kendo_data_query_1 = require("@progress/kendo-data-query");
var ReviewService = /** @class */ (function (_super) {
    __extends(ReviewService, _super);
    function ReviewService(apollo) {
        var _this = _super.call(this, null) || this;
        _this.apollo = apollo;
        return _this;
    }
    ReviewService.prototype.reviews = function (state) {
        var _this = this;
        this.fetch(state)
            .subscribe(function (x) {
            var dr = kendo_data_query_1.process(x.data, { group: state.group });
            dr.total = x.total;
            console.log(dr);
            _super.prototype.next.call(_this, dr);
        });
    };
    ReviewService.prototype.fetch = function (state) {
        var _this = this;
        console.log(JSON.stringify(state));
        this.loading = true;
        return this.apollo.query({
            query: graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\nquery GetReviews($state: InputQueryStateType!) {\n  reviews(state: $state) {\n    data {\n      recordCount\n      total\n      percentage\n      businessId\n      message\n      category\n      subCategory\n    }\n    total\n  }\n}"], ["\nquery GetReviews($state: InputQueryStateType!) {\n  reviews(state: $state) {\n    data {\n      recordCount\n      total\n      percentage\n      businessId\n      message\n      category\n      subCategory\n    }\n    total\n  }\n}"]))),
            variables: {
                state: state
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
}(BehaviorSubject_1.BehaviorSubject));
exports.ReviewService = ReviewService;
var templateObject_1;
