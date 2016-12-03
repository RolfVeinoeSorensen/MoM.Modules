import { NgModule }            from "@angular/core";

//import { SharedModule }        from "../shared/shared.module";

import { ServicesComponent } from "./services.component";
import { ServicesRoutingModule } from "./services-routing.module";

@NgModule({
    imports: [ServicesRoutingModule],
    declarations: [
        ServicesComponent
    ]
})
export class ServicesModule { }