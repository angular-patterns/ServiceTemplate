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
Object.defineProperty(exports, "__esModule", { value: true });
var graphql_tag_1 = require("graphql-tag");
var core_1 = require("@angular/core");
var GET_RULESETS = graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\nquery GetRulesets {\n    ruleSets {\n      id\n      title\n      businessId\n      model {\n          namespace\n          typeName          \n      }\n      createdOn\n      modelId\n    }\n  }"], ["\nquery GetRulesets {\n    ruleSets {\n      id\n      title\n      businessId\n      model {\n          namespace\n          typeName          \n      }\n      createdOn\n      modelId\n    }\n  }"])));
var RulesetService = /** @class */ (function () {
    function RulesetService() {
    }
    RulesetService = __decorate([
        core_1.Injectable()
    ], RulesetService);
    return RulesetService;
}());
exports.RulesetService = RulesetService;
var templateObject_1;
