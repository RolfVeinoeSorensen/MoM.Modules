import { NgModule, OnInit }             from "@angular/core";
import { ReactiveFormsModule }  from "@angular/forms";

import { SharedModule }         from "../../shared/shared.module";
import { DatabaseComponent }    from "./database.component";

@NgModule({
    imports: [SharedModule, ReactiveFormsModule],
    declarations: [DatabaseComponent],
    exports: [DatabaseComponent]
})
export class DatabaseModule implements OnInit {
    ngOnInit() {
        this.init();
    }
    init() { var test; }
}