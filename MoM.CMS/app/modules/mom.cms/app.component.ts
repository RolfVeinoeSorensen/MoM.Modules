import { Component, OnInit } from "@angular/core";
import { Router, Route } from "@angular/router";
// Add the RxJS Observable operators we need in this app.
import "./rxjs-operators";
import { CollapseModule } from "ng2-bootstrap/ng2-bootstrap";
//import { SetupApi } from "./api/setup.api";
//import { SetupService } from "./shared/setup.service";

@Component({
    selector: "app",
    //providers: [SetupApi, SetupService],
    templateUrl: "/app/outlet"
})
export class AppComponent implements OnInit {
    //constructor(private service: SetupService, private api: SetupApi) {
    //    service.installStepsCompleted$.subscribe(completed => {
    //        this.installStepsCompleted = completed;
    //    });
    //}
    constructor(private router: Router) { }
    public isCollapsed: boolean = true;

    public collapsed(event: any): void {
        console.log(event);
    }

    public expanded(event: any): void {
        console.log(event);
    }
    ngOnInit() {
        //console.log(this.router.config);
        //let existing = this.router.config;
        //let home: Route = { path: "home", loadChildren: "app/modules/MoM.CMS/pages/home/home.module#HomeModule" };
        //let services: Route = { path: "services", loadChildren: "app/modules/MoM.CMS/pages/services/services.module#ServicesModule" };
        //existing.push(services);
        //this.router.resetConfig(existing);
        ////this.service.init();
        //console.log("init");
        console.log(this.router);
    }
}