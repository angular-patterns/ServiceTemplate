import { AsyncValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ModelService } from './model.service';
import 'rxjs/add/operator/map';

export class ModelValidator
{
    public static create(modelService: ModelService, sourceCtrl: AbstractControl): AsyncValidatorFn {

        return (control: AbstractControl) => {
            
            var typename = control.value;
            var source = sourceCtrl.value;

            return modelService.validateModel(source, typename).map(t=> {
                console.log(t);
                if (!t.success)
                    return { 
                        'typeNotFound': !t.typeFound,                        
                        'compile': !t.compileSucceeded, 
                        'errors': t.compileErrors 
                    };

                return null;
            })
        }

    }
}