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
var application_service_1 = require("../core/application.service");
var ReviewDetailsComponent = /** @class */ (function () {
    function ReviewDetailsComponent(applicationService) {
        this.applicationService = applicationService;
        this.state = {
            skip: 0,
            take: 5,
            sort: []
        };
    }
    ReviewDetailsComponent.prototype.ngOnInit = function () {
        this.loadItems();
    };
    ReviewDetailsComponent.prototype.loadItems = function () {
        this.applicationService.applications(this.item.businessId, this.state.skip, this.state.take, this.state.sort);
    };
    ReviewDetailsComponent.prototype.dataStateChange = function (state) {
        this.state = state;
        this.applicationService.applications(this.item.businessId, this.state.skip, this.state.take, this.state.sort);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], ReviewDetailsComponent.prototype, "item", void 0);
    ReviewDetailsComponent = __decorate([
        core_1.Component({
            selector: 'app-review-details',
            templateUrl: './review-details.component.html',
            styleUrls: ['./review-details.component.css'],
            providers: [
                application_service_1.ApplicationService
            ]
        }),
        __metadata("design:paramtypes", [application_service_1.ApplicationService])
    ], ReviewDetailsComponent);
    return ReviewDetailsComponent;
}());
exports.ReviewDetailsComponent = ReviewDetailsComponent;
