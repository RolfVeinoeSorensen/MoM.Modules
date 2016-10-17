import { Component, Host } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule } from "@angular/forms";
import { ValidationService } from "./validation.service";
import { Form, NgControl } from "@angular/forms";
@Component({
    selector: "control-messages",
    inputs: ["controlName: control"],
    template: `<div *ngIf="errorMessage !== null" class="form-control alert-danger">{{errorMessage}}</div>`
})
export class ControlMessages {
    control: NgControl;
    constructor( @Host() private _formDir: Form) { }

    get errorMessage() {
        let c = this._formDir.getControl(this.control);

        for (let propertyName in c.errors) {
            if (c.errors.hasOwnProperty(propertyName) && c.touched && !c.pristine) {
                return ValidationService.getValidatorErrorMessage(propertyName);
            }
        }

        return null;
    }
}