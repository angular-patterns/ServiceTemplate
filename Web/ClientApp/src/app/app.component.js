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
var review_service_1 = require("./core/review.service");
var AppComponent = /** @class */ (function () {
    function AppComponent(reviewService) {
        this.reviewService = reviewService;
        this.groups = [];
        this.state = {
            skip: 0,
            take: 5,
            sort: [],
            group: [],
            // Initial filter descriptor
            filter: {
                logic: 'and',
                filters: []
            }
        };
        this.view = reviewService;
        this.reviewService.reviews(this.state);
    }
    AppComponent.prototype.ngOnInit = function () {
    };
    AppComponent.prototype.groupChange = function (groups) {
        this.state.group = groups;
        this.reviewService.reviews(this.state);
    };
    AppComponent.prototype.dataStateChange = function (state) {
        this.state = state;
        this.reviewService.reviews(this.state);
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css'],
            providers: [
                review_service_1.ReviewService
            ]
        }),
        __metadata("design:paramtypes", [review_service_1.ReviewService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
