import { Component, OnInit } from "@angular/core";
// Add the RxJS Observable operators we need in this app.
import "./rxjs-operators";

import { SetupApi } from "./api/setup.api";
import { SetupService } from "./shared/setup.service";

@Component({
    selector: "app",
    providers: [SetupApi, SetupService],
    templateUrl: "/setupapp/app"
})
export class AppComponent implements OnInit {
    installStepsCompleted: number = 0;
    constructor(private service: SetupService, private api: SetupApi) {
        service.installStepsCompleted$.subscribe(completed => {
            this.installStepsCompleted = completed;
        });
    }
    ngOnInit() {
        this.service.init();
    }
}