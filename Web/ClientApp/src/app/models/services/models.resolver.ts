import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { ModelService } from "../../core/model.service";

@Injectable() 
export class ModelsResolver implements Resolve<any[]> {
    constructor(private modelService: ModelService) {}

    resolve(route: ActivatedRouteSnapshot) {
   
      return this.modelService.getModels();
    }
}