"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var models_routing_module_1 = require("./models-routing.module");
var add_model_component_1 = require("./add-model/add-model.component");
var models_list_component_1 = require("./models-list/models-list.component");
var model_detail_component_1 = require("./model-detail/model-detail.component");
var ModelsModule = /** @class */ (function () {
    function ModelsModule() {
    }
    ModelsModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                models_routing_module_1.ModelsRoutingModule
            ],
            declarations: [add_model_component_1.AddModelComponent, models_list_component_1.ModelsListComponent, model_detail_component_1.ModelDetailComponent]
        })
    ], ModelsModule);
    return ModelsModule;
}());
exports.ModelsModule = ModelsModule;
