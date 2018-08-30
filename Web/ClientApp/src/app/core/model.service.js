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
var graphql_tag_1 = require("graphql-tag");
var apollo_angular_1 = require("apollo-angular");
var core_1 = require("@angular/core");
var CREATE_MODEL = graphql_tag_1.default(templateObject_1 || (templateObject_1 = __makeTemplateObject(["\nmutation CreateModelFromCSharp($source: String!, $typename: String!, $accountId: Int!) {\n    createModel(fromCSharp: {cSharpSource: $source, typeName: $typename, accountId: $accountId}) {\n        id\n    }\n}"], ["\nmutation CreateModelFromCSharp($source: String!, $typename: String!, $accountId: Int!) {\n    createModel(fromCSharp: {cSharpSource: $source, typeName: $typename, accountId: $accountId}) {\n        id\n    }\n}"])));
var COMPILE_SOURCE = graphql_tag_1.default(templateObject_2 || (templateObject_2 = __makeTemplateObject(["\nquery Compile($source: String!) {\n    compile(source: $source) {\n      success\n      errors {\n        code\n        message\n        severity\n        stackTrace\n        location {\n          end\n          fragment\n          isInSource\n          start\n        }\n      }\n    }\n  }\n  \n"], ["\nquery Compile($source: String!) {\n    compile(source: $source) {\n      success\n      errors {\n        code\n        message\n        severity\n        stackTrace\n        location {\n          end\n          fragment\n          isInSource\n          start\n        }\n      }\n    }\n  }\n  \n"])));
var VALIDATE_MODEL = graphql_tag_1.default(templateObject_3 || (templateObject_3 = __makeTemplateObject(["\nquery ValidateModel($source: String!, $typename: String!) {\n    validateModel(source: $source, typename: $typename) {\n      success\n      typeFound\n      compileSucceeded\n      compileErrors {\n        code\n        message\n        severity\n        stackTrace\n        location {\n          end\n          fragment\n          isInSource\n          start\n        }\n      }\n    }\n  }"], ["\nquery ValidateModel($source: String!, $typename: String!) {\n    validateModel(source: $source, typename: $typename) {\n      success\n      typeFound\n      compileSucceeded\n      compileErrors {\n        code\n        message\n        severity\n        stackTrace\n        location {\n          end\n          fragment\n          isInSource\n          start\n        }\n      }\n    }\n  }"])));
var GET_MODELS = graphql_tag_1.default(templateObject_4 || (templateObject_4 = __makeTemplateObject(["\nquery GetModels {\n    models {\n      id\n      accountId\n      namespace\n      typeName\n      jsonSchema\n      cSharpSource\n    }\n  }"], ["\nquery GetModels {\n    models {\n      id\n      accountId\n      namespace\n      typeName\n      jsonSchema\n      cSharpSource\n    }\n  }"])));
var GET_MODEL = graphql_tag_1.default(templateObject_5 || (templateObject_5 = __makeTemplateObject(["\nquery GetModel($id:Int!) {\n    models(id:$id) {\n      id\n      accountId\n      namespace\n      typeName\n      jsonSchema\n      cSharpSource\n    }\n  }"], ["\nquery GetModel($id:Int!) {\n    models(id:$id) {\n      id\n      accountId\n      namespace\n      typeName\n      jsonSchema\n      cSharpSource\n    }\n  }"])));
var ModelService = /** @class */ (function () {
    function ModelService(apollo) {
        this.apollo = apollo;
    }
    ModelService.prototype.createModelFromCSharp = function (source, typename, accountId) {
        return this.apollo.mutate({
            mutation: CREATE_MODEL,
            variables: { source: source, typename: typename, accountId: accountId }
        }).map(function (t) { return t.data; }).map(function (t) { return t.createModel; });
    };
    ModelService.prototype.compileSource = function (source) {
        return this.apollo.query({
            query: COMPILE_SOURCE,
            variables: { source: source }
        }).map(function (t) { return t.data; }).map(function (t) { return t.compile; });
    };
    ModelService.prototype.validateModel = function (source, typename) {
        return this.apollo.query({
            query: VALIDATE_MODEL,
            variables: { source: source, typename: typename }
        }).map(function (t) { return t.data; }).map(function (t) { return t.validateModel; });
    };
    ModelService.prototype.getModels = function () {
        return this.apollo.query({
            query: GET_MODELS,
            fetchPolicy: 'network-only'
        }).map(function (t) { return t.data; }).map(function (t) { return t.models; });
    };
    ModelService.prototype.getModel = function (id) {
        return this.apollo.query({
            query: GET_MODEL,
            variables: { id: id }
        }).map(function (t) { return t.data; }).map(function (t) { return t.models[0]; });
    };
    ModelService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [apollo_angular_1.Apollo])
    ], ModelService);
    return ModelService;
}());
exports.ModelService = ModelService;
var templateObject_1, templateObject_2, templateObject_3, templateObject_4, templateObject_5;
