import { AsyncValidatorFn, ValidationErrors, AbstractControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { ModelService } from './model.service';
import 'rxjs/add/operator/map';

export class CompileValidator
{
    public static create(modelService: ModelService): AsyncValidatorFn {
        return (control: AbstractControl) => {
            var source = control.value;
            return modelService.compileSource(source).map(t=> {
                if (!t.success)
                    return { 'compile': !t.success, 'errors': t.errors };

                return null;
            })
        }

    }
}