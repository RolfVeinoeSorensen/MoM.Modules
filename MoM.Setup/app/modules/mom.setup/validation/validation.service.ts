// articles https://coryrylan.com/blog/angular-2-form-builder-and-validation-management http://theshravan.net/blog/angular2-forms-custom-validators/
export class ValidationService {
    static getValidatorErrorMessage(code: string) {
        let config = {
            "required": "Required",
            "invalidCreditCard": "Is invalid credit card number",
            "invalidEmailAddress": "Invalid email address",
            "invalidPassword": "Invalid password. Password must be at least 6 characters long, and contain a number.",
            "noMatchPassword": "The confirm password does not match the password",
            "mustBeNumber": "You must write a number",
            "requiredIfRequireCredentials": "Required when you have selected Require Credentials",
        };

        return config[code];
    }

    static creditCardValidator(control) {
        // Visa, MasterCard, American Express, Diners Club, Discover, JCB
        if (control.value.match(/^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/)) {
            return null;
        } else {
            return { "invalidCreditCard": true };
        }
    }

    static emailValidator(control) {
        // RFC 2822 compliant regex
        if (control.value.match(/[a-z0-9!#$%&"*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&"*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/)) {
            return null;
        } else {
            return { "invalidEmailAddress": true };
        }
    }

    static passwordValidator(control) {
        // this regex will enforce these rules:
        // at least one upper case english letter
        // at least one lower case english letter
        // at least one digit
        // at least one special character
        // minimum 6 in length
        // maximum 100 in length
        if (control.value.match(/^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{6,100}$/)) {
            return null;
        } else {
            return { "invalidPassword": true };
        }
    }

    static passwordMatchValidator(control) {
        if (control.value === "" || control._parent.controls.password.value === control.value) {
            return null;
        } else {
            return { "noMatchPassword": true };
        }
    }

    static requiredIfRequireCredentialsValidator(control) {
        console.log(control);
        if (control._parent === undefined || (control._parent.controls.requireCredentials.value === false) || (control._parent.controls.requireCredentials.value === true && control.value !== "")) {
            return null;
        } else {
            return { "requiredIfRequireCredentials": true };
        }
    }

    static numberValidator(control) {
        if (control.value.match(/^[0-9]*$/)) {
            return null;
        } else {
            return { "mustBeNumber": true };
        }
    }
}